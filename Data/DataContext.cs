using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GovernmentGrantDisbursementAPI.Models;

namespace GovernmentGrantDisbursementAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Household> Households { get; set; }
        public DbSet<FamilyMember> FamilyMembers { get; set; }
        public DbSet<OccupationType> OccupationTypes { get; set; }
        
    }
}
