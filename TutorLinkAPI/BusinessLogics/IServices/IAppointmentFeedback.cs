using DataLayer.Entities;
using TutorLinkAPI.Controllers;
using TutorLinkAPI.ViewModel;

namespace TutorLinkAPI.BusinessLogics.IServices
{
    public interface IAppointmentFeedback
    {
        void BookAppointmentDate(BookAppointmentViewModel bookAppointmentViewModel);
        void NotifyTutorAboutAppointment(Guid? TutorId, DateTime AppointmentTime, string Address);
        //void HandleTutorConfirmation(Guid? TutorId, bool canGoToAppointment);
        void HandleTutorConfirmation(Guid? TutorId, int AppointmentId, bool canGoToAppointment);
        void SendFeedbackFormToParent(int AppointmentId, Guid? AccountId);
        void SendReviewReminderToParent(int AppointmentId, DateTime AppointmentTime);

        Task<List<AppointmentFeedbackViewModel>> GetAllAppointments();
        Task<AppointmentFeedbackViewModel> GetAppointmentById(int appointmentId);
        Task<List<AppointmentFeedbackViewModel>> GetAppointmentsByAccountId(Guid accountId);
        Task<List<AppointmentFeedbackViewModel>> GetAppointmentsByTutorId(Guid tutorId);
    }
}
