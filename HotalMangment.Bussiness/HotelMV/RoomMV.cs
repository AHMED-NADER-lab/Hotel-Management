using HotelMangment.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotalMangment.Bussiness.Enum;

namespace HotalMangment.Bussiness.HotelMV
{
  public  class RoomMV
    {

        public int id { get; set; }
        public string roomNumber { get; set; }
        public Nullable<int> noOFbed { get; set; }
        public TypeRoom  TypeRoom { get; set; }


        public virtual List<TBLroomReservation> TBLroomReservations { get; set; }
    }
}
