using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MunicipalServicesApp
{
    public class IssueReport
    {
        public string Location { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public string AttachedFilePath { get; set; }
        public DateTime ReportDate { get; set; }
    }

    public static class DataManager
    {
        public static List<IssueReport> ReportedIssues = new List<IssueReport>();
    }
}