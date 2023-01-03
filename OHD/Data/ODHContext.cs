using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using OHD.Models;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace OHD.Data
{
    public partial class ODHContext : IdentityDbContext<ApplicationUser> //DbContext
    {
        public ODHContext()
        {
        }

        public ODHContext(DbContextOptions<ODHContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblAssignbyAssignto> TblAssignbyAssignto { get; set; }
        public virtual DbSet<TblAssignees> TblAssignees { get; set; }
        public virtual DbSet<TblComplaints> TblComplaints { get; set; }
        public virtual DbSet<TblFacilities> TblFacilities { get; set; }
        public virtual DbSet<TblLab> TblLab { get; set; }
        public virtual DbSet<TblMaintaines> TblMaintaines { get; set; }
        public virtual DbSet<TblStudentCouncil> TblStudentCouncil { get; set; }
        public virtual DbSet<TblFacilityImages> TblFacilityImages { get; set; }
        public virtual DbSet<tblStatus> tblStatus{ get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source = SAQIB\\SAQIB;Initial catalog=ODH;Trusted_connection=yes;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            

            modelBuilder.Entity<TblAssignbyAssignto>(entity =>
            {
                entity.HasKey(e => e.ByToId)
                    .HasName("PK__tbl_assi__49C454DE88E84FCB");

                entity.Property(e => e.ByToId).ValueGeneratedNever();

                entity.Property(e => e.AssignyDate).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Assignby)
                    .WithMany(p => p.TblAssignbyAssignto)
                    .HasForeignKey(d => d.AssignbyId)
                    .HasConstraintName("FK__tbl_assig__assig__3C69FB99");

            });

            modelBuilder.Entity<TblAssignees>(entity =>
            {
                entity.HasKey(e => e.AssiId)
                    .HasName("PK__tbl_assi__7333958E04AA1BBF");

                entity.Property(e => e.AssiName).IsUnicode(false);
            });

            modelBuilder.Entity<TblComplaints>(entity =>
            {
                entity.HasKey(e => e.CompId)
                    .HasName("PK__tbl_comp__531653DD0E7905B6");

                entity.Property(e => e.CompName).IsUnicode(false);

                entity.Property(e => e.CompRequestdate).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CompStatusId).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.CompAssi)
                    .WithMany(p => p.TblComplaints)
                    .HasForeignKey(d => d.CompAssiId)
                    .HasConstraintName("FK__tbl_compl__comp___44FF419A");

                entity.HasOne(d => d.CompFacilitySelected)
                    .WithMany(p => p.TblComplaints)
                    .HasForeignKey(d => d.CompFacilitySelectedId)
                    .HasConstraintName("FK__tbl_compl__comp___4316F928");

            });

            modelBuilder.Entity<TblFacilities>(entity =>
            {
                entity.HasKey(e => e.FaciId)
                    .HasName("PK__tbl_faci__D698B94277AF3BCC");

                entity.Property(e => e.FaciBrifedescription).IsUnicode(false);

                entity.Property(e => e.FaciFacilities).IsUnicode(false);
            });

            modelBuilder.Entity<TblLab>(entity =>
            {
                entity.HasKey(e => e.LabId)
                    .HasName("PK__tbl_lab__66DE64DBF0F4DAFF");

                entity.Property(e => e.LabDescirption).IsUnicode(false);

                entity.Property(e => e.LabName).IsUnicode(false);

                entity.HasOne(d => d.LabFacility)
                    .WithMany(p => p.TblLab)
                    .HasForeignKey(d => d.LabFacilityId)
                    .HasConstraintName("FK__tbl_lab__lab_fac__48CFD27E");
            });

            modelBuilder.Entity<TblMaintaines>(entity =>
            {
                entity.HasKey(e => e.MaintId)
                    .HasName("PK__tbl_main__56128A704B36B56A");

                entity.Property(e => e.MaintStatus).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.MaintLab)
                    .WithMany(p => p.TblMaintaines)
                    .HasForeignKey(d => d.MaintLabId)
                    .HasConstraintName("FK__tbl_maint__maint__4BAC3F29");
            });

            modelBuilder.Entity<TblStudentCouncil>(entity =>
            {
                entity.HasKey(e => e.StuConsId)
                    .HasName("PK__tbl_stud__2D1C5666CFBE55DB");

                entity.Property(e => e.StuConsId).ValueGeneratedNever();

                entity.Property(e => e.StuConsName).IsUnicode(false);

                entity.HasOne(d => d.StuMaintanies)
                    .WithMany(p => p.TblStudentCouncil)
                    .HasForeignKey(d => d.StuMaintaniesId)
                    .HasConstraintName("FK__tbl_stude__stu_m__4F7CD00D");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
