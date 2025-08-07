using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserScheduleAPI.Domain.Entities
{
    public class Visit
    {
        public int VisitId { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public Guid PatientId { get; set; }
        public Patient Patient { get; set; }
        public int ShiftId { get; set; }
        public Shift Shift { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public string? Notes { get; set; }
    }
}
