using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Calender_TestCase.Models
{
    public partial class CalenderContext : DbContext
    {
        public CalenderContext()
        {
        }

        public CalenderContext(DbContextOptions<CalenderContext> options)
            : base(options)
        {
        }

        public virtual DbSet<DataTable> DataTables { get; set; } = null!;
        public virtual DbSet<HeaderTable> HeaderTables { get; set; } = null!;
        public virtual DbSet<Meeting> Meetings { get; set; } = null!;
        public virtual DbSet<Test1MeetingTable1> Test1MeetingTable1s { get; set; } = null!;
        public virtual DbSet<Test2Meeting> Test2Meetings { get; set; } = null!;
        public virtual DbSet<TestTable2> TestTable2s { get; set; } = null!;
        public virtual DbSet<TestTable3> TestTable3s { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=LAPTOP-SF5JKCA0\\SQLEXPRESS;Initial Catalog=Calender;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DataTable>(entity =>
            {
                entity.ToTable("DataTable");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.MeetingDetails)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<HeaderTable>(entity =>
            {
                entity.HasKey(e => e.Date)
                    .HasName("PK__HeaderTa__77387D063A1516D5");

                entity.ToTable("HeaderTable");

                entity.Property(e => e.Date).HasColumnType("date");
            });

            modelBuilder.Entity<Meeting>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("meetings");

                entity.Property(e => e.DateOfMeeting).HasColumnType("datetime");

                entity.Property(e => e.MeetingDetails)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Test1MeetingTable1>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Test1_MeetingTable_1");

                entity.Property(e => e.DateOfMeeting).HasColumnType("date");

                entity.Property(e => e.MeetingDetails)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Test2Meeting>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("test2_Meeting");

                entity.Property(e => e._16032023)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("'16/03/2023'");

                entity.Property(e => e._16042023)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("'16/04/2023'");
            });

            modelBuilder.Entity<TestTable2>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("TestTable_2");

                entity.Property(e => e._61023)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("6/10/23");

                entity.Property(e => e._61123)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("6/11/23");

                entity.Property(e => e._61223)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("6/12/23");
            });

            modelBuilder.Entity<TestTable3>(entity =>
            {
                entity.ToTable("TestTable_3");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e._61023)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("6/10/23");

                entity.Property(e => e._61123)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("6/11/23");

                entity.Property(e => e._61223)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("6/12/23");

                entity.Property(e => e._61323)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("6/13/23");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
