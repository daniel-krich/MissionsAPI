using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MissionsData.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissionsData.Context
{
    public class MissionDbContext : DbContext
    {
#nullable disable
        public DbSet<MissionEntity> Missions { get; set; }
#nullable enable

        protected readonly IConfiguration Configuration;

        public MissionDbContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(Configuration.GetConnectionString("MissionsDatabase"));
        }
    }
}
