namespace TestSeguros.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TSeg_Clientes_Polizas
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long id_cliente { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long id_poliza { get; set; }

        public DateTime fecha_inicio { get; set; }

        public short? meses_cobertura { get; set; }

        public decimal? cobertura { get; set; }

        public decimal? precio { get; set; }

        [StringLength(10)]
        public string riesgo { get; set; }

        public virtual TSeg_Clientes TSeg_Clientes { get; set; }

        public virtual TSeg_Polizas TSeg_Polizas { get; set; }
    }
}
