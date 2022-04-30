using System;
using Microsoft.EntityFrameworkCore;
using XUbuntuDatabaseImplement.Models;

#nullable disable

namespace XUbuntuDatabaseImplement
{
    public partial class Database : DbContext
    {
        public Database()
        {
        }

        public Database(DbContextOptions<Database> options)
            : base(options)
        {
        }

        public virtual DbSet<AssignmentToPost> AssingnmentToPosts { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Fullemplinfo> Fullemplinfos { get; set; }
        public virtual DbSet<Post> Posts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Host=192.168.56.105;Port=5432;Database=Labs_DB;Username=postgres;Password=postgres");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "ru_RU.UTF-8");

            modelBuilder.Entity<AssignmentToPost>(entity =>
            {
                entity.ToTable("assingnment_to_post");

                entity.HasComment("Таблица представляющая назначение на должность");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id")
                    .HasComment("ID назначения");

                entity.Property(e => e.Departmentid)
                    .HasColumnName("departmentid")
                    .HasComment("ID отдела");

                entity.Property(e => e.DismissDate)
                    .HasColumnType("date")
                    .HasColumnName("dismiss_date")
                    .HasComment(" Дата увольнения");

                entity.Property(e => e.Employeeid)
                    .HasColumnName("employeeid")
                    .HasComment("ID работника");

                entity.Property(e => e.HiringDate)
                    .HasColumnType("date")
                    .HasColumnName("hiring_date")
                    .HasComment(" Дата приема на работу");

                entity.Property(e => e.Postid)
                    .HasColumnName("postid")
                    .HasComment("ID должности");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.AssingnmentToPosts)
                    .HasForeignKey(d => d.Departmentid)
                    .HasConstraintName("depid_fkey");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.AssingnmentToPosts)
                    .HasForeignKey(d => d.Employeeid)
                    .HasConstraintName("empld_fkey");

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.AssingnmentToPosts)
                    .HasForeignKey(d => d.Postid)
                    .HasConstraintName("postid_fkey");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.ToTable("department");

                entity.HasComment("Таблица представляющая отдел");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id")
                    .HasComment("ID отдела");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("name")
                    .HasComment("Имя отдела");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("employee");

                entity.HasComment("Таблица представляющая работника");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id")
                    .HasComment("ID работника");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("name")
                    .HasComment("Имя работника");

                entity.Property(e => e.Surcharge)
                    .HasColumnName("surcharge")
                    .HasComment("Доплата для работника");
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
                    .HasMaxLength(30)
                    .HasColumnName("empname");

                entity.Property(e => e.HiringDate)
                    .HasColumnType("date")
                    .HasColumnName("hiring_date");

                entity.Property(e => e.Postname)
                    .HasMaxLength(50)
                    .HasColumnName("postname");

                entity.Property(e => e.Salary).HasColumnName("salary");
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.ToTable("post");

                entity.HasComment("Таблица представляющая должность");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id")
                    .HasComment("ID должности");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("name")
                    .HasComment("Название должности");

                entity.Property(e => e.Salary)
                    .HasColumnName("salary")
                    .HasComment("Оклад для должности");
            });

            modelBuilder.HasSequence("assingid");

            modelBuilder.HasSequence("depid");

            modelBuilder.HasSequence("emplid");

            modelBuilder.HasSequence("postid");

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
