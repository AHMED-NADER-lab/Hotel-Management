﻿using HotelMangment.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotalMangment.Bussiness.HotelMV
{
   public class CustomerMV
    {
        public int customerId { get; set; }
        [DisplayName(@"customer Name")]
        public string customerName { get; set; }
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Please enter correct email")]
        public string Email { get; set; }
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Please enter correct phone")]
        [StringLength(12)]
        public string Phone { get; set; }
        [DisplayName(@"ssn Number")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Please enter correct phone")]
        [StringLength(14)]
        public string ssnNumber { get; set; }

     
        public virtual List<TBLreservation> TBLreservations { get; set; }
    }
}
