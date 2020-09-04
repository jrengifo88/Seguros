namespace TestSeguros.Data
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
            TSeg_Clientes_Polizas = new HashSet<TSeg_Clientes_Polizas>();
            TSeg_Tipo_Cubrimiento = new HashSet<TSeg_Tipo_Cubrimiento>();
        }

        public long id { get; set; }

        [Required]
        [StringLength(50)]
        public string nombre { get; set; }

        [StringLength(200)]
        public string descripcion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TSeg_Clientes_Polizas> TSeg_Clientes_Polizas { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TSeg_Tipo_Cubrimiento> TSeg_Tipo_Cubrimiento { get; set; }
    }
}
