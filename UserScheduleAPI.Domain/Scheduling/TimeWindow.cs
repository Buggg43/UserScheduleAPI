using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserScheduleAPI.Domain.Scheduling
{
    public readonly record struct TimeWindow(TimeSpan Start, TimeSpan End)
    {
        public bool IsValid => Start < End;
        public TimeSpan Duration => End - Start;
        public override string ToString() => $"[{Start:hh\\:mm}-{End:hh\\:mm}]";
    }
}
