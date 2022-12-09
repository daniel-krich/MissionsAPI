using Microsoft.EntityFrameworkCore;
using MissionsData.Context;
using MissionsData.Entities;

namespace MissionsAPI.Services
{
    public class MissionsService
    {
        private readonly IDbContextFactory<MissionDbContext> _missionDbFactory;

        public MissionsService(IDbContextFactory<MissionDbContext> missionDbFactory)
        {
            _missionDbFactory = missionDbFactory;
        }

        public async Task<IEnumerable<MissionEntity>> GetMissions()
        {
            using (var context = _missionDbFactory.CreateDbContext())
            {
                return await context.Missions.ToArrayAsync();
            }
        }

        public async Task<MissionEntity?> GetMission(int id)
        {
            using (var context = _missionDbFactory.CreateDbContext())
            {
                return await context.Missions.FindAsync(id);
            }
        }

        public async Task<MissionEntity> AddMission(string mission)
        {
            using (var context = _missionDbFactory.CreateDbContext())
            {
                var missionEntity = new MissionEntity
                {
                    Mission = mission
                };

                context.Missions.Add(missionEntity);

                await context.SaveChangesAsync();

                return missionEntity;
            }
        }

        public async Task<bool> UpdateMission(int id, string updatedMission)
        {
            using (var context = _missionDbFactory.CreateDbContext())
            {
                var mission = await context.Missions.FindAsync(id);
                if (mission is not null)
                {
                    mission.Mission = updatedMission;
                    await context.SaveChangesAsync();
                    return true;
                }
                else return false;
            }
        }

        public async Task<bool> RemoveMission(int id)
        {
            using (var context = _missionDbFactory.CreateDbContext())
            {
                var mission = await context.Missions.FindAsync(id);
                if (mission is not null)
                {
                    context.Missions.Remove(mission);
                    await context.SaveChangesAsync();
                    return true;
                }
                else return false;
            }
        }

    }
}