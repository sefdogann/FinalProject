using FinalProject.Models;
using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models
{
    public class Product : BaseEntity
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name alanı boş olamaz.")]
        public string Name { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Price sıfırdan küçük olamaz.")]
        public decimal Price { get; set; }

        public int Stock { get; set; }
    }
}
