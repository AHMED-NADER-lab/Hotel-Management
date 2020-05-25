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
   public class ReservationBussiness
    {
        HotelMangmentEntities hotel = new HotelMangmentEntities();


        public Response Validatereservation(ReservationMV viewmodel)
        {
            Response result = new Response();
            if (viewmodel.fromDate==null)
                result.ErrorMessages.Add("fromDate", "not found Date");
            else if(viewmodel.fromDate.Value.Date<DateTime.Now.Date)
                result.ErrorMessages.Add("fromDate2", "not correct date");
            if (viewmodel.numDay == 0)
                result.ErrorMessages.Add("numDay", "not found number of the day");
            result.IsValid = result.ErrorMessages.Count == 0 ? true : false;
            return result;
        }


        public Response createnewrevesation(ReservationMV resvation)
        {
            Response result = Validatereservation(resvation);
            if (result.IsValid == true) { 
            TBLreservation roomtemp = new TBLreservation();
            roomtemp.fromDate = resvation.fromDate;
            roomtemp.toDate = resvation.fromDate.Value.AddDays(resvation.numDay);
            roomtemp.noOFpeople = resvation.noOFpeople;
            roomtemp.typeReservation =(int) resvation.roomtype;
            roomtemp.customerId = resvation.customerId;
                if (resvation.fromDate.Value.Date==DateTime.Now.Date)
                {
                    StatusType tt = StatusType.Prossing;
                    resvation.statereservation = tt;
                    roomtemp.Status =(int) resvation.statereservation;
                }
                else if(resvation.fromDate.Value.Date > DateTime.Now.Date)
                {
                    StatusType tt = StatusType.Pending;
                    resvation.statereservation = tt;
                    roomtemp.Status = (int)resvation.statereservation;
                }
             
                hotel.TBLreservations.Add(roomtemp);
            hotel.SaveChanges();
            var res = hotel.TBLreservations.OrderByDescending(r => r.id).FirstOrDefault();
            if (resvation.selectroom2 !=null)
            {
                for (int i = 0; i < resvation.selectroom2.Count; i++)
                {
                    string nameroom = resvation.selectroom2[i];
                    var room = hotel.TBLrooms.SingleOrDefault(r => r.roomNumber == nameroom);
                    RoomReservationMV room2 = new RoomReservationMV();
                    room2.reservationID = res.id;
                    room2.roomID = room.id;
                    createnewrevesationroom(room2);
                }
            }
            if (resvation.selectroom3 != null)
            {
                for (int i = 0; i < resvation.selectroom3.Count; i++)
                {
                    string nameroom = resvation.selectroom3[i];
                    var room = hotel.TBLrooms.SingleOrDefault(r => r.roomNumber == nameroom);
                    RoomReservationMV room2 = new RoomReservationMV();
                    room2.reservationID = res.id;
                    room2.roomID = room.id;
                    createnewrevesationroom(room2);
                }
            }
            if (resvation.selectsweet!= null)
            {
                for (int i = 0; i < resvation.selectsweet.Count; i++)
                {
                    string nameroom = resvation.selectsweet[i];
                    var room = hotel.TBLrooms.SingleOrDefault(r => r.roomNumber == nameroom);
                    RoomReservationMV room2 = new RoomReservationMV();
                    room2.reservationID = res.id;
                    room2.roomID = room.id;
                    createnewrevesationroom(room2);
                }
            }
            }
            return result;







        }




        public List<ReservationMV> listofreservation()
        {
            var reservation = hotel.TBLreservations;
            return reservation.Select(c => new ReservationMV
            {
                id = c.id,
                 customername= c.TBLcustomer.customerName,
                noOFpeople = c.noOFpeople,
                fromDate = c.fromDate,
                toDate=c.toDate,
                statereservation=(StatusType)c.Status
            }).ToList();
        }


        public void createnewrevesationroom(RoomReservationMV resvationroom)
        {
            TBLroomReservation roomtemp = new TBLroomReservation();
            roomtemp.roomID = resvationroom.roomID;
            roomtemp.reservationID = resvationroom.reservationID;
            hotel.TBLroomReservations.Add(roomtemp);
            hotel.SaveChanges();
        }




        public ReservationMV detailesReverstion(int id)
        {
            var reservation = hotel.TBLreservations.FirstOrDefault(r=>r.id==id);
            ReservationMV singleres = new ReservationMV();
            singleres.fromDate = reservation.fromDate;
            singleres.toDate = reservation.toDate;
            singleres.customername = reservation.TBLcustomer.customerName;
            singleres.TBLroomReservations = reservation.TBLroomReservations.ToList();
            singleres.noOFpeople = reservation.noOFpeople;
            return singleres;

        }


        public void ubdatestatus(int id)
        {
            var reservation = hotel.TBLreservations.FirstOrDefault(r => r.id == id);
            if (reservation.Status == 1)
            {
                reservation.Status = 2;
            }
            else if(reservation.Status == 2)
            {
                reservation.Status = 3;
            }
            hotel.SaveChanges();
        }








        public ReservationMV openReservationCreate( ReservationMV model = null)
        {
            LookupBussiness look = new LookupBussiness();
            if (model == null)
            {
                model = new ReservationMV();

            }
            model.fillcustomer = look.fillcustomer();
            return model;

        }





    }
}
