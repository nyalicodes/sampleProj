using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Domain
{
    public class Graduate
    {
        public Guid GraduateId { get; set; }
        public string GraduateName { get; set; }
        public string Gender { get; set; }
        public string JobTitle { get; set; }
        public IList<AcademicHistory> AcademicHistory { get; set; }

    }
}
