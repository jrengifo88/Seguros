namespace TestSeguros.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TSeg_Tipo_Cubrimiento
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TSeg_Tipo_Cubrimiento()
        {
            TSeg_Polizas = new HashSet<TSeg_Polizas>();
        }

        public long id { get; set; }

        [Required]
        [StringLength(50)]
        public string nombre { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TSeg_Polizas> TSeg_Polizas { get; set; }
    }
}
