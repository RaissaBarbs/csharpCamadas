using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace csharpCamadas.API.Models
{
    public partial class Motoristum
    {
        [Key]
        [Column("mot_id")]
        public int MotId { get; set; }
        [Column("mot_nome")]
        [StringLength(255)]
        [Unicode(false)]
        public string? MotNome { get; set; }
        [Column("mot_idade")]
        public int? MotIdade { get; set; }
        [Column("vei_id")]
        public int? VeiId { get; set; }

        [ForeignKey(nameof(VeiId))]
        [InverseProperty(nameof(Motoristum.Motorista))]
        public virtual Motoristum? Vei { get; set; }
    }
}
