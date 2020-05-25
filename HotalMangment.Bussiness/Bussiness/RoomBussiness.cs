using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelMangment.DAL;
using HotalMangment.Bussiness.HotelMV;
using HotalMangment.Bussiness.Enum;

namespace HotalMangment.Bussiness.Bussiness
{
  public  class RoomBussiness
    {
        HotelMangmentEntities hotel = new HotelMangmentEntities();


        public Response Validateroom(RoomMV viewmodel)
        {
            Response result = new Response();
          
            if (viewmodel.TypeRoom==0)
                result.ErrorMessages.Add("TypeRoom", "not found name");
           
            result.IsValid = result.ErrorMessages.Count == 0 ? true : false;
            return result;
        }
        //checked Room Number
        //public TBLroom checkroomName(string roomnum)
        //{
        //    var room = hotel.TBLrooms.SingleOrDefault(r => r.roomNumber == roomnum);
        //    return room;
        //}
        public List<RoomMV> listofroom()
        {
            var rooms = hotel.TBLrooms;
            return rooms.Select(c => new RoomMV
            {
                id = c.id,
                roomNumber = c.roomNumber,
                TypeRoom =(TypeRoom) c.typeRoom,
                noOFbed = c.noOFbed,
            }).ToList();
        }
        //Create new room
        public Response createnewroom(RoomMV room)
        {
           
            Response result = Validateroom(room);
            if (result.IsValid == true)
            {
                TBLroom roomtemp = new TBLroom();
                roomtemp.typeRoom = (int)room.TypeRoom;
                roomtemp.noOFbed = room.noOFbed;
                hotel.TBLrooms.Add(roomtemp);
                hotel.SaveChanges();
                result.SucessMessages.Add("savedate", "save sucess");
            }
            return result;


        }



    }
}
