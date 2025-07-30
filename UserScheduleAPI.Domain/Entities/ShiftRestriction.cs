using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserScheduleAPI.Domain.Entities
{
    public class ShiftRestriction
    {
        public int Id { get; set; }
        public int ShiftId {  get; set; }
        public Shift Shift { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public string? Reason { get; set; }
    }
}
