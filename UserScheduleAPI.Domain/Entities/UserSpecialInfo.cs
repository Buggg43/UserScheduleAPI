using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserScheduleAPI.Domain.Entities
{
    public class UserSpecialInfo
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }

        public int SpecialInfoId { get; set; }
        public SpecialInfo SpecialInfo { get; set; }
    }
}
