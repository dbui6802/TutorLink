using Microsoft.AspNetCore.Mvc;
using TutorLinkAPI.BusinessLogics.IServices;

namespace TutorLinkAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AppointmentFeedbackController : Controller
    {
        private readonly IAppointmentFeedback _appointmentFeedbackService;
        public AppointmentFeedbackController(IAppointmentFeedback appointmentFeedbackService)
        {
            _appointmentFeedbackService = appointmentFeedbackService;
        }

        #region booking
        [HttpPost("book-appointment")]
        public IActionResult BookAppointment([FromBody] BookAppointmentViewModel bookAppointmentViewModel)
        {
            try
            {
                if (bookAppointmentViewModel.AppointmentTime <= DateTime.Now)
                {
                    return BadRequest("Appointment time must be in the future.");
                }
                _appointmentFeedbackService.BookAppointmentDate(bookAppointmentViewModel);
                return Ok(new { Message = "Appointment booked successfully.", AppointmentId = bookAppointmentViewModel.AppointmentId });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Error booking appointment.", Error = ex.Message });
            }
        }
        #endregion

        #region notify tutor
        [HttpPost("notify-tutor")]
        public IActionResult NotifyTutor(Guid? TutorId, DateTime AppointmentTime, string Address)
        {
            _appointmentFeedbackService.NotifyTutorAboutAppointment(TutorId, AppointmentTime, Address);
            return Ok("Tutor notified about the appointment.");
        }
        #endregion

        #region handle confirm
        [HttpPost("handle-tutor-confirmation")]
        public IActionResult HandleTutorConfirmation(Guid? tutorId, int appointmentId, bool canGoToAppointment)
        {
            try
            {
                _appointmentFeedbackService.HandleTutorConfirmation(tutorId, appointmentId, canGoToAppointment);
                return Ok("Tutor confirmation handled successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Error handling tutor confirmation.", Error = ex.Message });
            }
        }
        #endregion

        #region send feedback
        [HttpGet("send-feedback-form")]
        public IActionResult SendFeedbackForm(Guid AccountId, int AppointmentId)
        {
            _appointmentFeedbackService.SendFeedbackFormToParent(AppointmentId, AccountId);
            return Ok("Feedback form sent to parent.");
        }
        #endregion


        #region send review
        [HttpPost("send-review-reminder")]
        public IActionResult SendReviewReminder(int AppointmentId, DateTime AppointmentTime)
        {
            _appointmentFeedbackService.SendReviewReminderToParent(AppointmentId, AppointmentTime);
            return Ok("Review reminder sent to parent.");
        }
        #endregion

        #region get appointment
        [HttpGet("appointments")]
        public async Task<IActionResult> GetAllAppointments()
        {
            /*var appointments = _appointmentFeedbackService.GetAllAppointments();
            return Ok(appointments);*/
            try
            {
                var appointments = await _appointmentFeedbackService.GetAllAppointments();
                return Ok(appointments);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Error retrieving appointments.", Error = ex.Message });
            }
        }

        [HttpGet("appointment/{id}")]
        public async Task<IActionResult> GetAppointmentById(int id)
        {
            var appointment = await _appointmentFeedbackService.GetAppointmentById(id);
            if (appointment == null)
            {
                return NotFound("Appointment not found.");
            }
            return Ok(appointment);
        }

        [HttpGet("appointments/account/{accountId}")]
        public async Task<IActionResult> GetAppointmentsByAccountId(Guid accountId)
        {
            /*var appointments = _appointmentFeedbackService.GetAppointmentsByAccountId(accountId);
            return Ok(appointments);*/
            try
            {
                var appointments = await _appointmentFeedbackService.GetAppointmentsByAccountId(accountId);
                return Ok(appointments);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Error retrieving appointments by account ID.", Error = ex.Message });
            }
        }

        [HttpGet("appointments/tutor/{tutorId}")]
        public async Task<IActionResult> GetAppointmentsByTutorId(Guid tutorId)
        {
            /*var appointments = _appointmentFeedbackService.GetAppointmentsByTutorId(tutorId);
            return Ok(appointments);*/
            try
            {
                var appointments = await _appointmentFeedbackService.GetAppointmentsByTutorId(tutorId);
                return Ok(appointments);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Error retrieving appointments by tutor ID.", Error = ex.Message });
            }
        }
        #endregion




    }

    public class BookAppointmentViewModel
    {
        public DateTime? AppointmentTime { get; set; }
        public string? Address { get; set; }
        public Guid? AccountId { get; set; }
        public Guid? TutorId { get; set; }
        public Guid? PostId { get; set; }
        public int AppointmentId { get; set; }
    }
}
