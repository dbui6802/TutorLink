namespace DataLayer.Entities;

public class PostRequest
{
    public Guid PostId { get; set; }
    public string Description { get; set; }
    public string Location { get; set; }
    public string Schedule { get; set; }
    public string PreferredTime { get; set; }
    public RequestMode Mode { get; set; }
    public RequestGender Gender { get; set; }
    public RequestStatuses Status { get; set; }
    public string RequestSkill { get; set; }
    public Guid CreatedBy { get; set; }
    public string? AvatarUrl { get; set; }
    public string? CreatedByUsername { get; set; }
    public DateTime CreatedDate { get; set; }
    
    public virtual ICollection<Apply>? Applies { get; set; }
    public virtual ICollection<AppointmentFeedback>? AppointmentFeedbacks { get; set; }
    public virtual Account? Account { get; set; }
    
    
    
}

public enum RequestGender
{
    Female,
    Male,
    Any
}

public enum RequestStatuses
{
    Pending,
    Available,
    Closed,
    Unactived
}

public enum RequestMode
{
    Offline,
    Online
}
