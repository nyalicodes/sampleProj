using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Domain
{
    public class AcademicHistory
    {
        public Guid AcademicHistoryId { get; set; }
        public string Institution { get; set; }
        public int StartYear { get; set; }
        public int EndYear { get; set; }
        public string Course { get; set; }

    }
}
