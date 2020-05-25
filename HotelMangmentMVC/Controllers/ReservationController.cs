using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HotalMangment.Bussiness.Bussiness;
using HotalMangment.Bussiness.HotelMV;
using HotalMangment.Bussiness.Enum;

namespace HotelMangmentMVC.Controllers
{
    public class ReservationController : Controller
    {
        ReservationBussiness reservation = new ReservationBussiness();
        // GET: Reservation
        public ActionResult Index()
        {
            return View(reservation.listofreservation());
        }

        // GET: Reservation/Details/5
        public ActionResult Details(int id)
        {
            return View(reservation.detailesReverstion(id));
        }

        // GET: Reservation/Create
        public ActionResult Create()
        {

            ReservationMV Reservationopen = reservation.openReservationCreate();
            return View(Reservationopen);
        }

        // POST: Reservation/Create
        [HttpPost]
        public ActionResult Createnewreservation(ReservationMV newreservation)
        {
          Response result=  reservation.createnewrevesation(newreservation);
            if (result.IsValid == true) {
                return RedirectToAction("Index");
            }
            else
            {
                newreservation= reservation.openReservationCreate();
                return View("Create", newreservation);

            }

               
          
        }

        // GET: Reservation/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Reservation/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Reservation/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Reservation/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        public ActionResult Getlistroom(DateTime fromdate)
        {
            LookupBussiness lookArea = new LookupBussiness();
            return Json(lookArea.fillroom2fromdate(fromdate));
        }

        public ActionResult Getlistroom3(DateTime fromdate)
        {
            LookupBussiness lookArea = new LookupBussiness();
            return Json(lookArea.fillroom3fromdate(fromdate));
        }

        public ActionResult Getlistsweet(DateTime fromdate)
        {
            LookupBussiness lookArea = new LookupBussiness();
            return Json(lookArea.fillsweetfromdate(fromdate));
        }




        public ActionResult ubdatereservation(int id)
        {

            reservation.ubdatestatus(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult checkdateeveryday(DateTime fromdate,string valstate)
        {
            string res = valstate.Trim();
            if (fromdate.Date == DateTime.Now.Date && res=="Pending")
                return Content("you must change process");
            else
                return Content("no change");
        }
    }
}
