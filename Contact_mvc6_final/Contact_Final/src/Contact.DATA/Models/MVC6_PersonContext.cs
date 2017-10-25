using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Contact.DATA.Models
{
    public partial class MVC6_PersonContext : DbContext
    {
        public virtual DbSet<Person> Person { get; set; }
        public virtual DbSet<Phone> Phone { get; set; }

        public MVC6_PersonContext(DbContextOptions<MVC6_PersonContext> options):base(options)
        {

        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
        //    //optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=MVC6_Person");
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>(entity =>
            {
                entity.HasKey(e => e.IdPerson)
                    .HasName("PK__Person__A5D4E15B747DBA66");

                entity.Property(e => e.Address).HasColumnType("varchar(200)");

                entity.Property(e => e.City).HasColumnType("varchar(50)");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnType("varchar(150)");

                entity.Property(e => e.Firstname)
                    .IsRequired()
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasColumnType("char(1)");

                entity.Property(e => e.Lastname)
                    .IsRequired()
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.Zipcode).HasColumnType("varchar(5)");
            });

            modelBuilder.Entity<Phone>(entity =>
            {
                entity.HasKey(e => e.IdPhone)
                    .HasName("PK__Phone__7F4A3AF03A2BB7EC");

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasColumnType("varchar(10)");

                entity.HasOne(d => d.IdPersonNavigation)
                    .WithMany(p => p.Phones)
                    .HasForeignKey(d => d.IdPerson)
                    .HasConstraintName("FK_Phone_ToTable");
            });
        }
    }
}