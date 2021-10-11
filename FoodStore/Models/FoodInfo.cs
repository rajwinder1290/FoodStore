using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FoodStore.Models
{
    public class FoodInfo
    {
        [Key]
        public int FoodID { get; set; }

        [Required]
        [StringLength(200)]
        public string FoodName { get; set; }

        [Required]
        [StringLength(1000)]
        public string Description { get; set; }

        [Required]
        [StringLength(20)]
        public string Extension { get; set; }

        [Required]
        public float Price { get; set; }


        [Required]
        public int CompanyID { get; set; }

        [Required]
        public int CategoryID { get; set; }

        [ForeignKey("CompanyID")]
        [InverseProperty("CompanyFood")]
        public virtual Company Company { get; set; }

        [ForeignKey("CategoryID")]
        [InverseProperty("CategoryFood")]
        public virtual FoodCategory CategoryFood { get; set; }

        public virtual ICollection<FoodOrder> FoodOrders { get; set; }

        [NotMapped]
        public SingleFileUpload File { get; set; }

    }

    public class SingleFileUpload
    {
        [Required]
        [Display(Name = "File")]
        public IFormFile FormFile { get; set; }
    }
}
