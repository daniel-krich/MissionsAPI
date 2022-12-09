using System.ComponentModel.DataAnnotations;

namespace MissionsAPI.DTOs
{
    public class UpdateMissionDTO
    {
        [Required]
        public string? UpdatedMission { get; set; }
    }
}
