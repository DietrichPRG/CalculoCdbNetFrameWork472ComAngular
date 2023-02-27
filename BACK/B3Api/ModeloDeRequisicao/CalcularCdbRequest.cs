using System.ComponentModel.DataAnnotations;

namespace B3Api.ModeloDeRequisicao
{
    public class CalcularCdbRequest
    {
        [Required]
        [Range(1, float.MaxValue, ErrorMessage = "O valor do investimento deve ser maior que zero.")]
        public float Valor { get; set; }

        [Required]
        [Range(2, uint.MaxValue, ErrorMessage = "O prazo do investimento deve ser maior que um mês.")]
        public uint QuantidadeDeMeses { get; set; }
    }
}