namespace TutorLinkAPI.ViewModel
{
    public class AppointmentFeedbackViewModel
    {
        public int AppointmentId { get; set; }
        public DateTime? ExpiredDate { get; set; }
        public DateTime? AppointmentTime { get; set; }
        public string? Address { get; set; }
        public string? Description { get; set; }
        public bool? IsSuccessful { get; set; }
        public AppStatuses Status { get; set; }
        public Guid? AccountId { get; set; }
        public Guid? TutorId { get; set; }
        public Guid? PostId { get; set; }

        public string? AccountUsername { get; set; }
        public string? AccountAvatarUrl { get; set; }
        public string? TutorUsername { get; set; }
        public string? TutorAvatarUrl { get; set; }
    }
}
