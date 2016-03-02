using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Datalus.Web.Domain
{
    public class Employments
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string CompanyName { get; set; }
        public string JobTitle { get; set; }
        public string Department { get; set; }
        public string Location { get; set; }
        public string SummaryOfJob { get; set; }

    }
}
