using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserScheduleAPI.Domain.Entities
{
    public class PatientSpecialInfo
    {
        public Guid Id { get; set; }
        public Guid PatientId { get; set; }
        public Patient Patient { get; set; }
        public int SpecialInfoId { get; set; }
        public SpecialInfo SpecialInfo { get; set; }
    }
}
