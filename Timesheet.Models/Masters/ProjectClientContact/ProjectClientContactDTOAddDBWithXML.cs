namespace Timesheet.Models.Masters.ProjectClientContact
{
    public class ProjectClientContactDTOAddDBWithXML
    {
        public int ProjectId { get; set; }
        public string? ClientContactsXML { get; set; }
        public string? CreatedBy { get; set; }
        public string? CreatedByIpAddress { get; set; }
    }
}
