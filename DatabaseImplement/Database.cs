using Microsoft.EntityFrameworkCore;
using DatabaseImplement.Models;

namespace DatabaseImplement
{
    public partial class Database : DbContext
    {
        public virtual DbSet<AssignmentToPost> AssingnmentToPosts { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Emplinfosal20> Emplinfosal20s { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Fullemplinfo> Fullemplinfos { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<Shortemplinfo> Shortemplinfos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=Predpriyatie;Username=postgres;Password=postgres");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Russian_Russia.1251");

            modelBuilder.Entity<AssignmentToPost>(entity =>
            {
                entity.ToTable("assignment_to_post");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Departmentid).HasColumnName("departmentid");

                entity.Property(e => e.DismissDate)
                    .HasColumnType("date")
                    .HasColumnName("dismiss_date");

                entity.Property(e => e.Employeeid).HasColumnName("employeeid");

                entity.Property(e => e.HiringDate)
                    .HasColumnType("date")
                    .HasColumnName("hiring_date");

                entity.Property(e => e.Postid).HasColumnName("postid");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.AssingnmentToPosts)
                    .HasForeignKey(d => d.Departmentid)
                    .HasConstraintName("departmentid_int_fk");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.AssingnmentToPosts)
                    .HasForeignKey(d => d.Employeeid)
                    .HasConstraintName("employeeid_int_fk");

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.AssingnmentToPosts)
                    .HasForeignKey(d => d.Postid)
                    .HasConstraintName("postid_int_fk");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.ToTable("department");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Emplinfosal20>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("emplinfosal20");

                entity.Property(e => e.Department)
                    .HasMaxLength(30)
                    .HasColumnName("department");

                entity.Property(e => e.DismissDate)
                    .HasColumnType("date")
                    .HasColumnName("dismiss_date");

                entity.Property(e => e.Empname)
                    .HasMaxLength(15)
                    .HasColumnName("empname");

                entity.Property(e => e.HiringDate)
                    .HasColumnType("date")
                    .HasColumnName("hiring_date");

                entity.Property(e => e.Postname)
                    .HasMaxLength(40)
                    .HasColumnName("postname");

                entity.Property(e => e.Salary).HasColumnName("salary");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("employee");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasColumnName("name");

                entity.Property(e => e.Surcharge).HasColumnName("surcharge");
            });

            modelBuilder.Entity<Fullemplinfo>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("fullemplinfo");

                entity.Property(e => e.Department)
                    .HasMaxLength(30)
                    .HasColumnName("department");

                entity.Property(e => e.DismissDate)
                    .HasColumnType("date")
                    .HasColumnName("dismiss_date");

                entity.Property(e => e.Empname)
                    .HasMaxLength(15)
                    .HasColumnName("empname");

                entity.Property(e => e.HiringDate)
                    .HasColumnType("date")
                    .HasColumnName("hiring_date");

                entity.Property(e => e.Postname)
                    .HasMaxLength(40)
                    .HasColumnName("postname");

                entity.Property(e => e.Salary).HasColumnName("salary");
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.ToTable("post");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("name");

                entity.Property(e => e.Salary).HasColumnName("salary");
            });

            modelBuilder.Entity<Shortemplinfo>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("shortemplinfo");

                entity.Property(e => e.Department)
                    .HasMaxLength(30)
                    .HasColumnName("department");

                entity.Property(e => e.Empname)
                    .HasMaxLength(15)
                    .HasColumnName("empname");

                entity.Property(e => e.Postname)
                    .HasMaxLength(40)
                    .HasColumnName("postname");

                entity.Property(e => e.Salary).HasColumnName("salary");
            });

            modelBuilder.HasSequence("assingid");

            modelBuilder.HasSequence("emplid").StartsAt(15);

            modelBuilder.HasSequence("postid");

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
