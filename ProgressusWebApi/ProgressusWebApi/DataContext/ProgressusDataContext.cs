﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProgressusWebApi.Model;
using ProgressusWebApi.Models.PlanEntrenamientoModels;

namespace ProgressusWebApi.DataContext
{
    public class ProgressusDataContext : IdentityDbContext
    {
        public ProgressusDataContext(DbContextOptions<ProgressusDataContext> options) : base(options)
        {

        }
        public DbSet<PlanDeEntrenamiento> PlanesDeEntrenamiento { get; set; }
        public DbSet<DiaDePlan> DiasDePlan { get; set; }
        public DbSet<EjercicioEnDiaDelPlan> EjerciciosDelDia { get; set; }
        public DbSet<SerieDeEjercicio> SeriesDeEjercicio { get; set; }
        public DbSet<Ejercicio> Ejercicios { get; set; }
        public DbSet<MusculoDeEjercicio> MusculosDeEjercicio { get; set; }
        public DbSet<Musculo> Musculos { get; set; }
        public DbSet<GrupoMuscular> GruposMusculares { get; set; }
        public DbSet<AsignacionDePlan> AsignacionDePlan { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuración de la clave compuesta para MusculoDeEjercicio (COMPLETAR!!!!!!!!!!!!!!!!!!!!)
            modelBuilder.Entity<MusculoDeEjercicio>()
                .HasKey(me => new { me.EjercicioId, me.MusculoId });

            modelBuilder.Entity<AsignacionDePlan>()
                .HasKey(ap => new { ap.SocioId, ap.PlanDeEntrenamientoId });

            // Configuración de las relaciones entre las entidades
            modelBuilder.Entity<MusculoDeEjercicio>()
                .HasOne(me => me.Ejercicio)
                .WithMany(e => e.MusculosDeEjercicio)
                .HasForeignKey(me => me.EjercicioId);

            modelBuilder.Entity<PlanDeEntrenamiento>()
                .HasOne(m => m.ObjetivoDelPlan)
                .WithMany()
                .HasForeignKey(m => m.ObjetivoDelPlanId);

            modelBuilder.Entity<MusculoDeEjercicio>()
                .HasOne(me => me.Musculo)
                .WithMany(m => m.MusculosDeEjercicio)
                .HasForeignKey(me => me.MusculoId);

            modelBuilder.Entity<DiaDePlan>()
                .HasOne(dp => dp.PlanDeEntrenamiento)
                .WithMany(p => p.DiasDelPlan)
                .HasForeignKey(dp => dp.PlanDeEntrenamientoId);

            modelBuilder.Entity<EjercicioEnDiaDelPlan>()
                .HasOne(ed => ed.DiaDePlan)
                .WithMany(dp => dp.EjerciciosDelDia)
                .HasForeignKey(ed => ed.DiaDePlanId);

            modelBuilder.Entity<EjercicioEnDiaDelPlan>()
                .HasOne(ed => ed.Ejercicio)
                .WithMany()
                .HasForeignKey(ed => ed.EjercicioId);

            modelBuilder.Entity<SerieDeEjercicio>()
                .HasOne(se => se.EjercicioDelDia)
                .WithMany(ed => ed.SeriesDeEjercicio)
                .HasForeignKey(se => se.EjercicioDelDiaId);

            modelBuilder.Entity<Musculo>()
                .HasOne(m => m.GrupoMuscular)
                .WithMany(gm => gm.MusculosDelGrupo)
                .HasForeignKey(m => m.GrupoMuscularId);

        }
    }
}
