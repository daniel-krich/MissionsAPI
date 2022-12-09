using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MissionsAPI.DTOs;
using MissionsAPI.Services;
using MissionsData.Entities;

namespace MissionsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MissionsController : ControllerBase
    {
        private readonly MissionsService _missionService;

        public MissionsController(MissionsService missionService)
        {
            _missionService = missionService;
        }

        [HttpGet]
        public async Task<IEnumerable<MissionEntity>> GetAllMissions()
        {
            return await this._missionService.GetMissions();
        }

        [HttpGet("{id}")]
        public async Task<MissionEntity?> GetMissionById(int id)
        {
            MissionEntity? mission = await _missionService.GetMission(id);
            if (mission is null)
                Response.StatusCode = 404;
            return mission;
        }

        [HttpPut("{id}")]
        public async Task<bool> UpdateMissionById(int id, [FromBody] UpdateMissionDTO updateMission)
        {
            return await _missionService.UpdateMission(id, updateMission.UpdatedMission!);
        }

        [HttpDelete("{id}")]
        public async Task<bool> DeleteMissionById(int id)
        {
            return await _missionService.RemoveMission(id);
        }

        [HttpPost]
        public async Task<MissionEntity> CreateMission([FromBody] AddMissionDTO addMission)
        {
            return await _missionService.AddMission(addMission.Mission!);
        }
    }
}
