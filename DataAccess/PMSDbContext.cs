using Microsoft.EntityFrameworkCore;
using PharmacyManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyManagementSystem.DataAccess
{
    public class PMSDbContext : DbContext
    {
        public PMSDbContext(DbContextOptions options) : base(options) { }
        public DbSet<PatientModel> Patient { get; set; }
        public DbSet<DoctorModel> Doctor { get; set; }
        public DbSet<DrugModel> Drug { get; set; }
        public DbSet<ScriptModel> Script { get; set; }
        public DbSet<FillModel> Fill { get; set; }
    }
}
