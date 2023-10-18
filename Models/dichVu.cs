using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace clonePetService.Models
{
    public class DichVu
    {
        public int ID { get; set; }
        [Required]
        public string TenBaiHat { get; set; }
        [Required]
        public int IDNS { get; set; }
        [Required]
        public int IDTL { get; set; }

    }
}