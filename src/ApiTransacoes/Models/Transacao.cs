using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiTransacoes.Models
{
    [Table("transacoes")]
    public class Transacao
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("descricao")]
        public string Descricao { get; set; } = null!;

        [Column("valor")]
        public decimal Valor { get; set; }

        [Column("data_transacao")]
        public DateTime? DataTransacao { get; set; }
    }
}
