namespace WebApplicationApi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Runtime.Serialization;

    //[KnownType(typeof(Usuarios))]
    //[KnownType(typeof(Alimentos))]
    public partial class Calorias
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string email { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string fecha { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(50)]
        public string tipoComida { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int codigoAlimento { get; set; }

        public int? cantidad { get; set; }

        [ForeignKey("codigoAlimento")]
        public virtual Alimentos Alimentos { get; set; }

        public virtual Usuarios Usuarios { get; set; }
    }
}