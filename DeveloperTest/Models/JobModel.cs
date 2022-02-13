using System;

namespace DeveloperTest.Models
{
    public class JobModel
    {
        public int JobId { get; set; }

        public string Engineer { get; set; }

        public DateTime When { get; set; }

        public string CustName { get; set; }

        public string CustType { get; set; }

        public int CustID { get; set; }
    }
}
