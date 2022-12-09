using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissionsData.Entities
{
    public class MissionEntity : BaseEntity
    {
#nullable disable
        [Required, MaxLength(80)]
        public string Mission { get; set; }
    }
}
