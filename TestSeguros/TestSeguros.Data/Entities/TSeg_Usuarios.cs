namespace TestSeguros.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TSeg_Usuarios
    {
        public long id { get; set; }

        [Required]
        [StringLength(20)]
        public string usuario { get; set; }

        [Required]
        [StringLength(128)]
        public string contrasena { get; set; }

        public short estado { get; set; }
    }
}
