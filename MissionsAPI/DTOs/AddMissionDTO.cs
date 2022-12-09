using System.ComponentModel.DataAnnotations;

namespace MissionsAPI.DTOs
{
    public class AddMissionDTO
    {
        [Required]
        public string? Mission { get; set; }
    }
}
