using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Project2.Models
{
    public class PriceQuotation
    {
        [Required]
        [Range(0.01, Double.PositiveInfinity, ErrorMessage ="Subtotal must be greater than zero.")]
        public double? Subtotal { get; set; }

        [Required]
        [Range(0, 100)]
        public double? DiscountPercent { get; set; }

        public double DiscountAmount =>
            Subtotal * (DiscountPercent / 100.0) ?? 0.0;

        public double Total =>
            Subtotal - DiscountAmount ?? 0.0;
    }
}
