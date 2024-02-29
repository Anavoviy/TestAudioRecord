using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAudioRecord.DataBaseFolder
{
    public class DataBase : DbContext
    {
        public DbSet<Patient> Patients { get; set; }
        public DbSet<LDM> LDMs { get; set; }
        public DbSet<VoiceMessage> VoiceMessages { get; set; }

        public DataBase()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string filePath = FileSystem.AppDataDirectory;

            optionsBuilder.UseSqlite("DataSource=" + Path.Combine(filePath, "database.db"));
        }
    }
}
