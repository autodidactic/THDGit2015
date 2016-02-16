using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SendScheduledEmails.Model
{
    public partial class DataModel :DbContext
    {
        public DataModel()
            : base("DataModel")
        {
            Database.SetInitializer<DataModel>(null);
        }

        public DbSet<EmailDAL.EMAILQUEUE> getEmailqueue { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

           // modelBuilder.HasDefaultSchema("MCDB");
            modelBuilder.Entity<EmailDAL.EMAILQUEUE>().Property(a => a.MESSAGEID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
