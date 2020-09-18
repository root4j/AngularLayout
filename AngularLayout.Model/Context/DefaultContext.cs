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
        #endregion
    }
}
