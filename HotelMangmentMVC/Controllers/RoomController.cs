using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HotalMangment.Bussiness.Bussiness;
using HotalMangment.Bussiness.HotelMV;

namespace HotelMangmentMVC.Controllers
{
    public class RoomController : Controller
    {
        RoomBussiness room = new RoomBussiness();
        // GET: Room
        public ActionResult Index()
        {
            return View(room.listofroom());
        }

        // GET: Room/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Room/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Room/Create
        [HttpPost]
        public ActionResult CreateRoom(RoomMV newroom)
        {
            Response result = room.createnewroom(newroom);
            if (result.IsValid == true)
            {

                TempData["roomOPer"] = result.SucessMessages.SingleOrDefault().Value;
                return RedirectToAction("Index");


            }
            else
            {


                foreach (var item in result.ErrorMessages)
                {
                    ModelState.AddModelError(item.Key, item.Value);
                }

                return View("Create", newroom);
            }

            }

        // GET: Room/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Room/Edit/5
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

        // GET: Room/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Room/Delete/5
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
    }
}
