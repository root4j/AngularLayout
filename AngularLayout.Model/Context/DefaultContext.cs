using AngularLayout.Model.Entities.General;
using Microsoft.EntityFrameworkCore;

namespace AngularLayout.Model.Context
{
    public class DefaultContext : DbContext
    {
        public DefaultContext(DbContextOptions<DefaultContext> options) : base(options)
        {
        }

        #region Definition of DbSets
        public virtual DbSet<ValueList> ValueLists { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<State> States { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Definition of Foreign Keys
            modelBuilder.Entity<State>()
                .HasOne(e => e.Country)
                .WithMany()
                .HasForeignKey(e => e.CountryCode);

            modelBuilder.Entity<City>()
                .HasOne(e => e.State)
                .WithMany()
                .HasForeignKey(e => e.StateCode);
            #endregion
        }
    }
}