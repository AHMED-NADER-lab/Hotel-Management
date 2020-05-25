using HotelMangment.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotalMangment.Bussiness.HotelMV
{
  public  class RoomReservationMV
    {

        public int id { get; set; }
        public Nullable<int> roomID { get; set; }
        public Nullable<int> reservationID { get; set; }
        public string RoomName { get; set; }

        public virtual TBLreservation TBLreservation { get; set; }
        public virtual TBLroom TBLroom { get; set; }
    }
}
