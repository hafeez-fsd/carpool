﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Carpool.Models.DbModels
{
    [Table("Offer")]
    public class Offer
	{
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessage = "Id required")]
        public int Id { get; set; }

        [Required(ErrorMessage = "BookerId required")]
        public int OffererId { get; set; }

        [Required(ErrorMessage = "From required")]
        public int From { get; set; }

        [Required(ErrorMessage = "To required")]
        public int To { get; set; }

        public string Time { get; set; }

        public string Date { get; set; }

        public string Stops { get; set; }

        public int SeatsAvailable { get; set; }

        [Required(ErrorMessage = "OfferedTime required")]
        public string OfferedTime { get; set; }
    }
}

