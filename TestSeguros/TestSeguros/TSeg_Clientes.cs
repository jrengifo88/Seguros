namespace TestSeguros
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TSeg_Clientes
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TSeg_Clientes()
        {
            TSeg_Polizas = new HashSet<TSeg_Polizas>();
        }

        public long id { get; set; }

        [Required]
        [StringLength(6)]
        public string tipo_identificacion { get; set; }

        [Required]
        [StringLength(100)]
        public string identificacion { get; set; }

        [Required]
        [StringLength(50)]
        public string nombres { get; set; }

        [Required]
        [StringLength(50)]
        public string apellidos { get; set; }

        [StringLength(12)]
        public string telefono { get; set; }

        [StringLength(30)]
        public string direccion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TSeg_Polizas> TSeg_Polizas { get; set; }
    }
}
