namespace TestSeguros.Data
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model2 : DbContext
    {
        public Model2()
            : base("name=Model2")
        {
        }

        public virtual DbSet<TSeg_Clientes> TSeg_Clientes { get; set; }
        public virtual DbSet<TSeg_Clientes_Polizas> TSeg_Clientes_Polizas { get; set; }
        public virtual DbSet<TSeg_Polizas> TSeg_Polizas { get; set; }
        public virtual DbSet<TSeg_Tipo_Cubrimiento> TSeg_Tipo_Cubrimiento { get; set; }
        public virtual DbSet<TSeg_Usuarios> TSeg_Usuarios { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TSeg_Clientes>()
                .Property(e => e.tipo_identificacion)
                .IsUnicode(false);

            modelBuilder.Entity<TSeg_Clientes>()
                .Property(e => e.identificacion)
                .IsUnicode(false);

            modelBuilder.Entity<TSeg_Clientes>()
                .Property(e => e.nombres)
                .IsUnicode(false);

            modelBuilder.Entity<TSeg_Clientes>()
                .Property(e => e.apellidos)
                .IsUnicode(false);

            modelBuilder.Entity<TSeg_Clientes>()
                .Property(e => e.telefono)
                .IsUnicode(false);

            modelBuilder.Entity<TSeg_Clientes>()
                .Property(e => e.direccion)
                .IsUnicode(false);

            modelBuilder.Entity<TSeg_Clientes>()
                .HasMany(e => e.TSeg_Clientes_Polizas)
                .WithRequired(e => e.TSeg_Clientes)
                .HasForeignKey(e => e.id_cliente)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TSeg_Clientes_Polizas>()
                .Property(e => e.cobertura)
                .HasPrecision(18, 0);

            modelBuilder.Entity<TSeg_Clientes_Polizas>()
                .Property(e => e.precio)
                .HasPrecision(18, 0);

            modelBuilder.Entity<TSeg_Clientes_Polizas>()
                .Property(e => e.riesgo)
                .IsUnicode(false);

            modelBuilder.Entity<TSeg_Polizas>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<TSeg_Polizas>()
                .Property(e => e.descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<TSeg_Polizas>()
                .HasMany(e => e.TSeg_Clientes_Polizas)
                .WithRequired(e => e.TSeg_Polizas)
                .HasForeignKey(e => e.id_poliza)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TSeg_Polizas>()
                .HasMany(e => e.TSeg_Tipo_Cubrimiento)
                .WithMany(e => e.TSeg_Polizas)
                .Map(m => m.ToTable("TSeg_Polizas_Tipo_Cubrimiento").MapLeftKey("id_poliza").MapRightKey("id_tipo_cubrimiento"));

            modelBuilder.Entity<TSeg_Tipo_Cubrimiento>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<TSeg_Usuarios>()
                .Property(e => e.usuario)
                .IsUnicode(false);

            modelBuilder.Entity<TSeg_Usuarios>()
                .Property(e => e.contrasena)
                .IsUnicode(false);
        }
    }
}
