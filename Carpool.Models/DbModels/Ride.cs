﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Carpool.Models.DbModels
{
    [Table("Ride")]
    public class Ride
	{
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessage = "Id required")]
        public int Id { get; set; }

        [Required(ErrorMessage = "BookingId required")]
        public int BookingId { get; set; }

        [Required(ErrorMessage = "OfferId required")]
        public int OfferId { get; set; }

        public string TripStart { get; set; }

        public string TripEnd { get; set; }

        public float Price { get; set; }

        public float Distance { get; set; }
    }
}
    
