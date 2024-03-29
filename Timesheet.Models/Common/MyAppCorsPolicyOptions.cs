namespace Timesheet.Models.Common
{
    public class MyAppCorsPolicyOptions
    {
        public const string MyAppCorsPolicySettings = "MyAppCorsPolicySettings";
        public List<OriginListDTO> Origins { get; set; }
    }

    public class OriginListDTO
    {
        public string Url { get; set; }
    }
}
