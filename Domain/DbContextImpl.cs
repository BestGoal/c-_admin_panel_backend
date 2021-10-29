using Domain.Models;
using EventsManagemtns;
using EventsManagemtns.Controllers;
using EventsManagemtns.Models;
using System.Data.Entity;

namespace Domain
{
    public class DbContextImpl : DbContext
    {

        public DbContextImpl(string constring) : base(constring)
        {
        }

        public DbSet<AttachmentProp> AttachmentProps { get; set; }
        public DbSet<APT> Apts { get; set; }
        public DbSet<Country> Countries { get; set; }

        public DbSet<StatusType> statusTypes { get; set; }

        public DbSet<Incident> incidents { get; set; }

        public DbSet<Section> sections { get; set; }

        public DbSet<Employee> employees { get; set; }

        public DbSet<Category> categories { get; set; }
        public DbSet<Saverity> saverities { get; set; }
        public DbSet<Urgancey> urganceys { get; set; }
        public DbSet<Status> statuses { get; set; }
        public DbSet<Sector> sectors { get; set; }
        public DbSet<Organization> organizations { get; set; }

        public DbSet<Tasks> Tasks { get; set; }
        public DbSet<Comment> Comment { get; set; }

        public DbSet<CloseReport> closeReports { get; set; }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Country>()
                .HasMany(c => c.targeted)
                .WithMany(a => a.TargetedCountries)
                .Map(sd => sd.ToTable("TargetedCountries"));

            modelBuilder.Entity<APT>()
                .HasMany(a => a.Attachments)
                .WithMany(att => att.apts)
                .Map(sd => sd.ToTable("AptAttachments"));


            modelBuilder.Entity<Country>()
                .HasMany(c => c.origin)
                .WithMany(a => a.OriginCountries)
                .Map(sd => sd.ToTable("OriginCountries"));

            base.OnModelCreating(modelBuilder);
        }
    }


    public class CodeConfig : DbConfiguration
    {
        public CodeConfig()
        {
            SetProviderServices("System.Data.SqlClient",
                System.Data.Entity.SqlServer.SqlProviderServices.Instance);
        }

    }
}