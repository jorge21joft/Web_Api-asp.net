namespace WebApi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class notas
    {
        public int id { get; set; }

        [StringLength(50)]
        public string titulo { get; set; }

        [Column(TypeName = "text")]
        public string descripcion { get; set; }

        [Column(TypeName = "date")]
        public DateTime? fecha { get; set; }

        [StringLength(50)]
        public string prioridad { get; set; }
    }
}
