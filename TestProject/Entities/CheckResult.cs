using System;
namespace TestProject
{
    public class CheckResult
    {
        public int Check_id { get; set; }
        public DateTime Timestamp_utc { get; set; }
        public string Severity { get; set; }
        public int Value { get; set; }
        public string Unit { get; set; }
    }
}
