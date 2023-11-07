using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CalculatorAPI.Domain
{
    public class Calculation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Value1 { get; set; }
        public int Value2 { get; set; }
        public string? Operation { get; set; }
        public int Result { get; set; }
    }
}