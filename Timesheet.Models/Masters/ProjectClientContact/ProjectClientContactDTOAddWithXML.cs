namespace Timesheet.Models.Masters.ProjectClientContact
{
    public class ProjectClientContactDTOAddWithXML
    {
        public int ProjectId { get; set; }
        public string? ClientContactsXML { get; set; }
    }

    public class ClientContact
    {
        public int ClientContactId { get; set; }
        public string? Description { get; set; }
    }

}
