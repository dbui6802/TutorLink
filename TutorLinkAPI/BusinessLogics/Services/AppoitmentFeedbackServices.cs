using TutorLinkAPI.BusinessLogics.IServices;
using Amazon.SimpleNotificationService;
using Amazon.SimpleNotificationService.Model;
using DataLayer.Entities;
using Microsoft.Identity.Client;
using Microsoft.Data.SqlClient;
using Amazon;
using Amazon.Runtime;
using System.Numerics;
using DataLayer.DAL;
using TutorLinkAPI.Controllers;
using DataLayer.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using TutorLinkAPI.ViewModel;
using AutoMapper;
#pragma warning disable CS8603
namespace TutorLinkAPI.BusinessLogics.Services
{
    public class AppoitmentFeedbackServices : IAppointmentFeedback
    {
        private readonly IConfiguration _configuration;
        private readonly AmazonSimpleNotificationServiceClient _snsClient;
        private readonly TutorDbContext _context;
        private readonly AppointmentFeedbackRepository _appointmentFeedbackRepository;
        private readonly IMapper _mapper;
        public AppoitmentFeedbackServices(IConfiguration configuration, TutorDbContext context, AppointmentFeedbackRepository appointmentFeedbackRepository, IMapper mapper)
        {
            /*_configuration = configuration;
            string awsAccessKeyId = "";
            string awsSecretAccessKey = "";
            BasicAWSCredentials awsCredentials = new BasicAWSCredentials(awsAccessKeyId, awsSecretAccessKey);
            _snsClient = new AmazonSimpleNotificationServiceClient(RegionEndpoint.);*/
            _configuration = configuration;
            _context = context;
            _appointmentFeedbackRepository = appointmentFeedbackRepository;
            _mapper = mapper;

            var awsAccessKeyId = _configuration.GetValue<string>("AKIAQ3EGRT57GWN3HYWF");
            var awsSecretAccessKey = _configuration.GetValue<string>("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");
            var awsRegion = _configuration.GetValue<string>("ap-southeast-2");

            var awsCredentials = new BasicAWSCredentials(awsAccessKeyId, awsSecretAccessKey);
            _snsClient = new AmazonSimpleNotificationServiceClient(awsCredentials, Amazon.RegionEndpoint.GetBySystemName("ap-southeast-2"));
        }
        /*--------------------------------------------------------------------------*/
        #region Book Appointment
        /*public void BookAppointmentDate(BookAppointmentViewModel bookAppointmentViewModel)
        {
            try
            {

                var appointment = new AppointmentFeedback
                {
                    AppointmentTime = bookAppointmentViewModel.AppointmentTime,
                    Address = bookAppointmentViewModel.Address,
                    AccountId = bookAppointmentViewModel.AccountId,
                    TutorId = bookAppointmentViewModel.TutorId,
                    PostId = bookAppointmentViewModel.PostId,
                    Status = AppStatuses.Pending // default status
                };

                _context.AppointmentFeedbacks.Add(appointment);
                _context.SaveChanges();
                bookAppointmentViewModel.AppointmentId = appointment.AppointmentId;

                Console.WriteLine($"Appointment booked successfully. AppointmentId: {appointment.AppointmentId}, AppointmentTime: {appointment.AppointmentTime}, Address: {appointment.Address}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error booking appointment. Error: {ex.Message}");
            }
        }*/
        public void BookAppointmentDate(BookAppointmentViewModel bookAppointmentViewModel)
        {
            try
            {
                if (bookAppointmentViewModel.AppointmentTime.HasValue)
                {
                    var inputDateTime = DateTime.SpecifyKind(bookAppointmentViewModel.AppointmentTime.Value, DateTimeKind.Utc); // Specify the input datetime kind as UTC

                    // Convert the input datetime to Vietnam timezone (Indochina Time, ICT)
                    TimeZoneInfo vietnamTimeZone = TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time"); // Vietnam timezone
                    var inputDateTimeVietnam = TimeZoneInfo.ConvertTimeFromUtc(inputDateTime, vietnamTimeZone);

                    if (inputDateTimeVietnam > DateTime.Now)
                    {
                        var appointment = new AppointmentFeedback
                        {
                            AppointmentTime = inputDateTime, // Store the appointment time in UTC
                            Address = bookAppointmentViewModel.Address,
                            AccountId = bookAppointmentViewModel.AccountId,
                            TutorId = bookAppointmentViewModel.TutorId,
                            PostId = bookAppointmentViewModel.PostId,
                            Status = AppStatuses.Pending // default status
                        };

                        _context.AppointmentFeedbacks.Add(appointment);
                        _context.SaveChanges();
                        bookAppointmentViewModel.AppointmentId = appointment.AppointmentId;

                        Console.WriteLine($"Appointment booked successfully. AppointmentId: {appointment.AppointmentId}, AppointmentTime (UTC): {appointment.AppointmentTime}, AppointmentTime (ICT): {inputDateTimeVietnam}, Address: {appointment.Address}");
                    }
                    else
                    {
                        Console.WriteLine("Invalid appointment date/time. Please enter a future date/time.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error booking appointment. Error: {ex.Message}");
            }
        }
        #endregion

        #region Notify tutor
        public void NotifyTutorAboutAppointment(Guid? TutorId, DateTime AppointmentTime, string Address)
        {
            var message = $"Appointment scheduled on {AppointmentTime}. Address: {Address}";
            PublishRequest publishRequest = new PublishRequest
            {
                TargetArn = $"arn:aws:sns:us-east-1:123456789012:TutorTopic_{TutorId}",
                Message = message
            };
            _snsClient.PublishAsync(publishRequest);
        }
        #endregion
        /*--------------------------------------------------------------------------*/
        #region Handle confirm of tutor
        public void HandleTutorConfirmation(Guid? tutorId, int appointmentId, bool canGoToAppointment)
        {
            try
            {
                var appointment = _context.AppointmentFeedbacks.FirstOrDefault(a => a.AppointmentId == appointmentId && a.TutorId == tutorId);
                if (appointment == null)
                {
                    throw new Exception($"Appointment with ID {appointmentId} for Tutor {tutorId} not found.");
                }

                if (canGoToAppointment)
                {
                    appointment.Status = AppStatuses.Scheduled;
                    Console.WriteLine($"Appointment {appointmentId} scheduled successfully.");
                }
                else
                {
                    appointment.Status= AppStatuses.Completed;
                    Console.WriteLine($"Appointment {appointmentId} remains pending.");
                }

                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error handling tutor confirmation for appointment {appointmentId}. Error: {ex.Message}");
            }
        }
        #endregion

        #region SendFeedback to Parent
        public void SendFeedbackFormToParent(int AppointmentId, Guid? AccountId)
        {
            if (AccountId.HasValue)
            {
                string Phone = RetrieveParentPhoneNumberFromDatabase(AccountId.Value);
                var feedbackLink = "https://forms.office.com/r/La0LUdhKRM";
                PublishRequest feedbackRequest = new PublishRequest
                {
                    Message = $"Please provide feedback for the tutor: {feedbackLink}",
                    PhoneNumber = Phone
                };
                _snsClient.PublishAsync(feedbackRequest);
            }
            else
            {
                Console.WriteLine("Invalid accountId provided.");
            }
        }
        private string RetrieveParentPhoneNumberFromDatabase(Guid? AccountId)
        {
            if (AccountId.HasValue)
            {
                string connectionString = _configuration.GetConnectionString("MyAzureDatabaseConnection");
                string query = "SELECT Phone FROM ParentTable WHERE AccountId = @AccountId";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@AccountId", AccountId);
                        string Phone = command.ExecuteScalar() as string;
                        if (!string.IsNullOrEmpty(Phone))
                        {
                            return Phone;
                        }
                        else
                        {
                            Console.WriteLine("Phone number not found for the provided accountId.");
                            return "";
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("Invalid accountId provided.");
                return "";
            }
        }
        #endregion
        /*--------------------------------------------------------------------------*/
        #region Other
       
        public void SendReviewReminderToParent(int AppointmentId, DateTime AppointmentTime)
        {
            var ExpiredDate = AppointmentTime.AddDays(1);
            if (DateTime.Now.Date >= ExpiredDate.Date)
            {
                Guid AccountId = GetParentAccountIdForAppointment(AppointmentId);
                if (AccountId != Guid.Empty)
                {
                    string Phone = RetrieveParentPhoneNumberFromDatabase(AccountId);
                    if (!string.IsNullOrEmpty(Phone))
                    {
                        var feedbackLink = "https://forms.office.com/r/La0LUdhKRM";
                        PublishRequest reviewReminderRequest = new PublishRequest
                        {
                            Message = $"Please review the tutor by filling out this form: {feedbackLink}",
                            PhoneNumber = Phone
                        };
                        _snsClient.PublishAsync(reviewReminderRequest);
                    }
                }
                else
                {
                    Console.WriteLine("Phone number not found for the parent accountId.");
                }

            }
            else
            {
                Console.WriteLine("Parent account ID not found for the given appointment");
            }

        }
        private Guid GetParentAccountIdForAppointment(int AppointmentId)
        {
            Guid AccountId = Guid.Empty;
            try
            {
                string connectionString = _configuration.GetConnectionString("MyDatabaseConnection");
                string query = "SELECT AccountId FROM Appointments WHERE AppointmentId = @AppointmentId";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@AppointmentId", AppointmentId);

                        object result = command.ExecuteScalar();

                        if (result != null)
                        {
                            AccountId = (Guid)result;
                        }
                    }
                }
            }
            catch (Exception ex) { Console.WriteLine($"Error: {ex.Message}"); }
            return AccountId;
        }
        #endregion

        #region Get Appointment
       
        public async Task<List<AppointmentFeedbackViewModel>> GetAllAppointments()
        {
            try
            {
                var appointments = await _appointmentFeedbackRepository.GetAllWithIncludeAsync(
                    a => true,
                    a => a.Account,
                    a => a.Tutor
                );

                var appointmentViewModels = _mapper.Map<List<AppointmentFeedbackViewModel>>(appointments);
                return appointmentViewModels;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving Appointments: {ex.Message}", ex);
            }
        }

        public async Task<AppointmentFeedbackViewModel> GetAppointmentById(int appointmentId)
        {
            try
            {
                var appointments = await _appointmentFeedbackRepository.GetAllWithIncludeAsync(
                    a => a.AppointmentId == appointmentId,
                    a => a.Account,
                    a => a.Tutor
                    );
                var appointment = appointments.SingleOrDefault();
                if (appointment == null)
                {
                    throw new Exception($"Appointment with ID {appointmentId} not found.");
                }
                var appointmentViewModel = _mapper.Map<AppointmentFeedbackViewModel>(appointment);
                return appointmentViewModel;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving Appointment by ID: {ex.Message}", ex);
            }
        }
        #endregion

        #region Get Appointment by Tutor
        
        public async Task<List<AppointmentFeedbackViewModel>> GetAppointmentsByTutorId(Guid tutorId)
        {
            try
            {
                var appointments = await _appointmentFeedbackRepository.GetAllWithIncludeAsync(
                    a => a.TutorId == tutorId,
                    a => a.Account,
                    a => a.Tutor
                );

                var appointmentViewModels = _mapper.Map<List<AppointmentFeedbackViewModel>>(appointments);
                return appointmentViewModels;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving Appointments by Tutor ID: {ex.Message}", ex);
            }
        }
        #endregion

        #region Get Appointment by Account
        

        public async Task<List<AppointmentFeedbackViewModel>> GetAppointmentsByAccountId(Guid accountId)
        {
            try
            {
                var appointments = await _appointmentFeedbackRepository.GetAllWithIncludeAsync(
                    a => a.AccountId == accountId,
                    a => a.Account,
                    a => a.Tutor
                );

                var appointmentViewModels = _mapper.Map<List<AppointmentFeedbackViewModel>>(appointments);
                return appointmentViewModels;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving Appointments by Account ID: {ex.Message}", ex);
            }
        }
        #endregion

    }
}
