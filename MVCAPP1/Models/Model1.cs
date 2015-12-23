namespace MVCAPP1.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Data.Entity.ModelConfiguration.Conventions;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
            Database.SetInitializer<Model1>(null);
        }


        public DbSet<APPMAN_APPLICATION> GetAppInventory { get; set; }

        public DbSet<APPMAN_NOTETYPE> GetNoteType { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("MCDB");
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

        }
    }
}
