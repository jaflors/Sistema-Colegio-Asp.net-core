using System;
using ColegioApp.Models;
using ColegioApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

#nullable disable

namespace ColegioApp.Data
{
    public partial class ControlNotasColegioContext : IdentityDbContext<UsuarioAplicacion>
    {
        public ControlNotasColegioContext()
        {
        }

        public ControlNotasColegioContext(DbContextOptions<ControlNotasColegioContext> options)
            : base(options)
        {
        }

        //public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        //public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; }
        //public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        //public virtual DbSet<UsuarioAplicacion> UsuarioAplicacions { get; set; }
        //public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        //public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        //public virtual DbSet<AspNetUserRole> AspNetUserRoles { get; set; }
        //public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; }
       
        public virtual DbSet<Estudiante> Estudiantes { get; set; }
        public virtual DbSet<EstudianteGrado> EstudianteGrados { get; set; }
        public virtual DbSet<Grado> Grados { get; set; }
        public virtual DbSet<MateriaProfesor> MateriaProfesors { get; set; }
        public virtual DbSet<Materium> Materia { get; set; }
        public virtual DbSet<Calificacion> Calificacions { get; set; }

        public virtual DbSet<Periodo> Periodos { get; set; }
        public virtual DbSet<Profesor> Profesors { get; set; }

       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<AspNetRole>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetRoleClaim>(entity =>
            {
                entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

                entity.Property(e => e.RoleId).IsRequired();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            

            //modelBuilder.Entity<UsuarioAplicacion>()
            //.HasOne(b => b.AspNetUserNavigation)
            //.WithOne(i => i.UsuarioAplicacionNavigation)
            //.HasForeignKey<AspNetUser>(b => b.IdAspUser);

            //modelBuilder.Entity<AspNetUser>(entity =>
            //{

            //    entity.HasKey(e => e.Id)
            //    .HasName("PK_AspNetUsers");
            //    entity.ToTable("AspNetUsers");

            //    //entity.HasOne(e => e.UsuarioAplicacionNavigation)
            //    //.WithOne(u => u.AspNetUserNavigation);



            //    entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

            //    entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
            //        .IsUnique()
            //        .HasFilter("([NormalizedUserName] IS NOT NULL)");

            //    entity.Property(e => e.Email).HasMaxLength(256);

            //    entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

            //    entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

            //    entity.Property(e => e.UserName).HasMaxLength(256);
            //});




            modelBuilder.Entity<AspNetUserClaim>(entity =>
            {
                entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogin>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRole>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId, "IX_AspNetUserRoles_RoleId");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserToken>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.Name).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

           

            modelBuilder.Entity<Estudiante>(entity =>
            {
                entity.HasKey(e => e.IdEstudiante);

                entity.ToTable("Estudiante");

                entity.Property(e => e.IdUser)
                    .IsRequired()
                    .HasMaxLength(450);

                
                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.Estudiantes)
                    .HasForeignKey(d => d.IdUser)
                    .HasConstraintName("fk_User_Estudiante");
            });

            modelBuilder.Entity<EstudianteGrado>(entity =>
            {
                entity.HasKey(e => e.IdEstudianteGrado)
                    .HasName("PkEstudianteGrado");

                entity.ToTable("EstudianteGrado");

                entity.Property(e => e.Año)
                    .IsRequired()
                    .HasMaxLength(4);

                entity.Property(e => e.FkEstudiante).HasColumnName("Fk_Estudiante");

                entity.Property(e => e.FkGrado).HasColumnName("Fk_Grado");

                entity.HasOne(d => d.FkEstudianteNavigation)
                    .WithMany(p => p.EstudianteGrados)
                    .HasForeignKey(d => d.FkEstudiante)
                    .HasConstraintName("FK_EstudianteGrado_Estudiante");

                entity.HasOne(d => d.FkGradoNavigation)
                    .WithMany(p => p.EstudianteGrados)
                    .HasForeignKey(d => d.FkGrado)
                    .HasConstraintName("FK_EstudianteGrado_Grado");
            });

            

            modelBuilder.Entity<Grado>(entity =>
            {
                entity.HasKey(e => e.IdGrado);

                entity.ToTable("Grado");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MateriaProfesor>(entity =>
            {
                entity.HasKey(e => new { e.FkMateria, e.FkProfesor })
                    .HasName("PkMateriaProfesor");

                entity.ToTable("MateriaProfesor");

                entity.Property(e => e.FkProfesor).HasColumnName("Fk_Profesor");

                entity.HasOne(d => d.FkMateriaNavigation)
                    .WithMany(p => p.MateriaProfesors)
                    .HasForeignKey(d => d.FkMateria)
                    .HasConstraintName("FK_MateriaProfesor_Materia");

                entity.HasOne(d => d.FkProfesorNavigation)
                    .WithMany(p => p.MateriaProfesors)
                    .HasForeignKey(d => d.FkProfesor)
                    .HasConstraintName("FK_MateriaProfesor_Profesor");
            });

            modelBuilder.Entity<Materium>(entity =>
            {
                entity.HasKey(e => e.IdMateria);

                entity.Property(e => e.FkGrado).HasColumnName("fkGrado");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.FkGradoNavigation)
                    .WithMany(p => p.Materia)
                    .HasForeignKey(d => d.FkGrado)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Materia_Grado");
            });

            modelBuilder.Entity<Calificacion>(entity =>
            {
                entity.HasKey(e => e.IdCalificacion);

                entity.ToTable("Calificacion");

                entity.Property(e => e.FkEstudiante).HasColumnName("Fk_Estudiante");

                entity.Property(e => e.FkMateria).HasColumnName("Fk_Materia");

                entity.Property(e => e.FkPeriodo).HasColumnName("Fk_Periodo");

                entity.HasOne(d => d.FkEstudianteNavigation)
                    .WithMany(p => p.Calificacions)
                    .HasForeignKey(d => d.FkEstudiante)
                    .HasConstraintName("FK_Calificacion_Estudiante");

                entity.HasOne(d => d.FkMateriaNavigation)
                    .WithMany(p => p.Calificacions)
                    .HasForeignKey(d => d.FkMateria)
                    .HasConstraintName("FK_Calificacion_Materia");

                entity.HasOne(d => d.FkPeriodoNavigation)
                    .WithMany(p => p.Calificacions)
                    .HasForeignKey(d => d.FkPeriodo)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Calificacion_Periodo");
            });

            modelBuilder.Entity<Periodo>(entity =>
            {
                entity.HasKey(e => e.IdPeriodo);

                entity.ToTable("Periodo");

                entity.Property(e => e.Año)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.FechaFin)
                    .HasColumnType("date")
                    .HasColumnName("Fecha_Fin");

                entity.Property(e => e.FechaInicio)
                    .HasColumnType("date")
                    .HasColumnName("Fecha_inicio");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Profesor>(entity =>
            {
                entity.HasKey(e => e.IdProfesor);

                entity.ToTable("Profesor");

                entity.Property(e => e.IdUser)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.Profesors)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_User");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
