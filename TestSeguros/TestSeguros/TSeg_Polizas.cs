namespace TestSeguros
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TSeg_Polizas
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TSeg_Polizas()
        {
            TSeg_Clientes = new HashSet<TSeg_Clientes>();
            TSeg_Tipo_Cubrimiento = new HashSet<TSeg_Tipo_Cubrimiento>();
        }

        public long id { get; set; }

        [Required]
        [StringLength(50)]
        public string nombre { get; set; }

        [StringLength(200)]
        public string descripcion { get; set; }

        public decimal? cobertura { get; set; }

        public DateTime fecha_inicio { get; set; }

        public short? meses_cobertura { get; set; }

        public decimal? precio { get; set; }

        [StringLength(10)]
        public string riesgo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TSeg_Clientes> TSeg_Clientes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TSeg_Tipo_Cubrimiento> TSeg_Tipo_Cubrimiento { get; set; }
    }
}
