using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace Common.ViewModels
    {
    public class ProductVM
        {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        [Display(Name = "Price")]
        [Range(1, 1000, ErrorMessage = "Price must be between 1 and 1000")]
        public float? Price { get; set; }
        [Required]
        [Range(1, 1000, ErrorMessage = "weight must be between 1 and 1000")]
        [Display(Name = "weight(in mg)")]
        public float? Weight { get; set; }
        public string Image { get; set; }
        [Required]
        public HttpPostedFileBase ImageFile { get; set; }

        [Required]
        public string Manufacturer { get; set; }
        [Range(5, 90, ErrorMessage = "discount must be between 5 and 90")]
        public float? Discount { get; set; }
        public int RemarkId { get; set; }
        [Required]
        [Display(Name ="Remark Name")]
        public string RemarkName { get; set; }
        public List<RemarkVM> RemarkList { get; set; }
        [Required]
        [Range(1, 100, ErrorMessage = "stock must be greater than 0 and less than 100")]
        public int? Stock { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? ExpiryDate { get; set; }
        public RemarkVM Remark { get; set; }
        public float FinalAmount { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        }
    }
