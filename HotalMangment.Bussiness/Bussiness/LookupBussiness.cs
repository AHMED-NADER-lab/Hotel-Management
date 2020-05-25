using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelMangment.DAL;
using HotalMangment.Bussiness.HotelMV;

namespace HotalMangment.Bussiness.Bussiness
{
  public  class LookupBussiness
    {
        HotelMangmentEntities hotel = new HotelMangmentEntities();

        //List of customer
        public List<LookUpMV> fillcustomer()
        {
            var customer = hotel.TBLcustomers;

            return customer.Select(e => new LookUpMV
            {
                id = e.customerId,
                name = e.customerName,
            }).ToList();
        }


        //public List<LookUpMV> fillroom2()
        //{
        //    //var roomres = hotel.TBLroomReservations.Select(r=>r.roomID).ToList();
        //    var roomress= hotel.TBLroomReservations.Join(
        //             hotel.TBLrooms,  
        //              rr=>rr.roomID ,    
        //              r=>r.id ,  
        //              (rr, r) => new  
        //              {
        //                  r.id,
        //                  r.roomNumber,
                         
        //              });
        //    var room2 = hotel.TBLrooms.Where(ro=>ro.noOFbed==2).Select(ro =>new { ro.id,ro.roomNumber });
        //    var fiiroom =room2.Except(roomress).Select(ro => new { ro.id, ro.roomNumber });

        //    return fiiroom.Select(e => new LookUpMV
        //    {
        //        id = e.id,
        //        name = e.roomNumber,
        //    }).ToList();
        //}


        public List<LookUpMV> fillroom2fromdate(DateTime fromdate)
        {
            var fullEntries = hotel.TBLreservations
                            .Join(
                        hotel.TBLroomReservations,
                          re=>re.id,
                         ro => ro.reservationID,
                     (re, ro) => new { ro.roomID, re.toDate }
                            ).Where(r=>r.toDate> fromdate)
                            .Join(
                            hotel.TBLrooms,
                         r=>r.roomID,
                             rr => rr.id,
                         (r, rr) => new
                                   {
                     rr.roomNumber,
                     rr.id,
                     rr.noOFbed,
                     
                    
                    
                                       }
                         
                                      )
                         .Where(r=>r.noOFbed==2);

            var room2 = hotel.TBLrooms.Where(ro => ro.noOFbed == 2).Select(ro => new { ro.roomNumber, ro.id ,ro.noOFbed });
            var fiiroom = room2.Except(fullEntries).Select(ro => new { ro.id, ro.roomNumber });

            return fiiroom.Select(e => new LookUpMV
            {
                id = e.id,
                name = e.roomNumber,
            }).ToList();



        }




        //public List<LookUpMV> fillroom3()
        //{
        //    var room3 = hotel.TBLrooms.Where(r => r.noOFbed == 3);

        //    return room3.Select(e => new LookUpMV
        //    {
        //        id = e.id,
        //        name = e.roomNumber,
        //    }).ToList();
        //}



        public List<LookUpMV> fillroom3fromdate(DateTime fromdate)
        {
            var fullEntries = hotel.TBLreservations
                            .Join(
                        hotel.TBLroomReservations,
                          re => re.id,
                         ro => ro.reservationID,
                     (re, ro) => new { ro.roomID, re.toDate }
                            ).Where(r => r.toDate > fromdate)
                            .Join(
                            hotel.TBLrooms,
                         r => r.roomID,
                             rr => rr.id,
                         (r, rr) => new
                         {
                             rr.roomNumber,
                             rr.id,
                             rr.noOFbed,



                         }

                                      )
                         .Where(r => r.noOFbed == 3);

            var room3 = hotel.TBLrooms.Where(ro => ro.noOFbed == 3).Select(ro => new { ro.roomNumber, ro.id, ro.noOFbed }).Except(fullEntries).Select(ro => new { ro.id, ro.roomNumber });
            //var fiiroom = room2.Except(fullEntries).Select(ro => new { ro.id, ro.roomNumber });

            return room3.Select(e => new LookUpMV
            {
                id = e.id,
                name = e.roomNumber,
            }).ToList();



        }




        //public List<LookUpMV> fillsweet()
        //{
        //    var sweet = hotel.TBLrooms.Where(r => r.noOFbed == null);

        //    return sweet.Select(e => new LookUpMV
        //    {
        //        id = e.id,
        //        name = e.roomNumber,
        //    }).ToList();
        //}





        public List<LookUpMV> fillsweetfromdate(DateTime fromdate)
        {
            var fullEntries = hotel.TBLreservations
                            .Join(
                        hotel.TBLroomReservations,
                          re => re.id,
                         ro => ro.reservationID,
                     (re, ro) => new { ro.roomID, re.toDate }
                            ).Where(r => r.toDate > fromdate)
                            .Join(
                            hotel.TBLrooms,
                         r => r.roomID,
                             rr => rr.id,
                         (r, rr) => new
                         {
                             rr.roomNumber,
                             rr.id,
                             rr.noOFbed,



                         }

                                      )
                         .Where(r => r.noOFbed == null);

            var sweet = hotel.TBLrooms.Where(ro => ro.noOFbed == null).Select(ro => new { ro.roomNumber, ro.id, ro.noOFbed }).Except(fullEntries).Select(ro => new { ro.id, ro.roomNumber });
            //var fiiroom = room2.Except(fullEntries).Select(ro => new { ro.id, ro.roomNumber });

            return sweet.Select(e => new LookUpMV
            {
                id = e.id,
                name = e.roomNumber,
            }).ToList();



        }
    }
}
