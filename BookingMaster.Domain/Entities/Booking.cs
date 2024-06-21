﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingMaster.Domain.Entities
{
    public class Booking
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }

        [Required]
        public string VillaId { get; set; }
        [ForeignKey("VillaId")]
        public Villa Villa { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        public string? Phone { get; set; }

        [Required]
        public double TotalCost { get; set; }
        public int Nights { get; set; }
        public string? Status { get; set; }


        [Required]
        public DateTime BookingDate { get; set; }

        [Required]
        public DateTime ChechInDate { get; set; }

        [Required]
        public DateTime ChechOutDate { get; set; }

        public bool IsPaymentSuccessful { get; set; } = false;
        public DateTime PaymentDate { get; set; }

        public string? StripeSessionId { get; set; }
        public string? StripePaymentIntentId { get; set; }

        public DateTime ActualChechInDate { get; set; }
        public DateTime ActualChechOutDate { get; set; }

        public int VillaNumber {  get; set; }
    }
}
