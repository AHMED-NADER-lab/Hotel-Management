using HotelMangment.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotalMangment.Bussiness.Enum;
using System.ComponentModel.DataAnnotations;

namespace HotalMangment.Bussiness.HotelMV
{
   public class ReservationMV
    {

        public int id { get; set; }
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> fromDate { get; set; }
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> toDate { get; set; }
        public Nullable<int> noOFpeople { get; set; }
        //public Nullable<int> typeReservation { get; set; }
        public Nullable<double> TotalPrice { get; set; }
        //public Nullable<int> Status { get; set; }
        public Nullable<int> customerId { get; set; }
        public string customername { get; set; }

        public virtual TBLcustomer TBLcustomer { get; set; }
        public List<LookUpMV> fillroom2 { get; set; }
        public List<LookUpMV> fillroom3 { get; set; }
        public List<LookUpMV> fillsweet { get; set; }
        public List<string> selectroom2 { get; set; }
        public List<string> selectroom3 { get; set; }
        public List<string> selectsweet { get; set; }
        public TypeRoom roomtype { get; set; }
        public List<LookUpMV> fillcustomer { get; set; }
        public int numDay { get; set; }
        public StatusType statereservation { get; set; }



        public virtual List<TBLroomReservation> TBLroomReservations { get; set; }
    }
}
