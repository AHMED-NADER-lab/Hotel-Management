using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotalMangment.Bussiness;
using HotelMangment.DAL;
using HotalMangment.Bussiness.HotelMV;

namespace HotalMangment.Bussiness.Bussiness
{
 public   class CustomerBussiness
    {

        HotelMangmentEntities hotel = new HotelMangmentEntities();

        //validation customer
        public Response Validatepatient(CustomerMV viewmodel)
        {
            Response result = new Response();
            if (string.IsNullOrEmpty(viewmodel.customerName))
                result.ErrorMessages.Add("customerName", "not found name");
            if (string.IsNullOrEmpty(viewmodel.ssnNumber))
                result.ErrorMessages.Add("ssnNumber", "not found name");
            if (string.IsNullOrEmpty(viewmodel.Phone))
                result.ErrorMessages.Add("Phone", "not found name");
            result.IsValid = result.ErrorMessages.Count == 0 ? true : false;
            return result;
        }

        //List of customer
        public List<CustomerMV> listofcustomer()
        {
            var customers = hotel.TBLcustomers;
            return customers.Select(c => new CustomerMV
            {
               customerId=c.customerId,
               customerName=c.customerName,
               Email=c.Email,
               ssnNumber=c.ssnNumber,
               Phone=c.Phone


            }).ToList();
        }

        //create new customer
        public Response createnewcustomer (CustomerMV customer)
        {
            Response result = Validatepatient(customer);
            if (result.IsValid == true)
            {
                TBLcustomer customertemp = new TBLcustomer();
                customertemp.customerName = customer.customerName;
                customertemp.Email = customer.Email;
                customertemp.ssnNumber = customer.ssnNumber;
                customertemp.Phone = customer.Phone;
                hotel.TBLcustomers.Add(customertemp);
                hotel.SaveChanges();
                result.SucessMessages.Add("savedate", "save sucess");
            }
            return result;


        }
        //detailes customer
        public CustomerMV Selectcustomer(int id)
        {

            var customer = hotel.TBLcustomers.SingleOrDefault(c => c.customerId == id);
            CustomerMV custtemp = new CustomerMV();
            custtemp.customerId = customer.customerId;
            custtemp.customerName = customer.customerName;
            custtemp.Email = customer.Email;
            custtemp.ssnNumber = customer.ssnNumber;
            custtemp.Phone = customer.Phone;
            return custtemp;
        }

        //Select customer delete
        public Response Selectcustomerdelete(int id)
        {
            Response delresponse = new Response();
            var rescust = hotel.TBLreservations.Where(r => r.customerId == id).ToList();
            if (rescust.Count==0) {
                var customer = hotel.TBLcustomers.FirstOrDefault(c => c.customerId == id);
                hotel.TBLcustomers.Remove(customer);
                hotel.SaveChanges();
                delresponse.IsValid = true;
                delresponse.SucessMessages.Add("deletesucess","delete sucess customer");
                return delresponse;
               
            }
            else
            {
                delresponse.IsValid = false;
                delresponse.ErrorMessages.Add("deletefailed", "delete failed customer");
                return delresponse;
            }




        }


        public Response ubdatecustomer(CustomerMV customer)
        {
            Response result = Validatepatient(customer);
            if (result.IsValid == true)
            {
                var customertemp = hotel.TBLcustomers.Find(customer.customerId);
                customertemp.customerName = customer.customerName;
                customertemp.Email = customer.Email;
                customertemp.ssnNumber = customer.ssnNumber;
                customertemp.Phone = customer.Phone;
              
                hotel.SaveChanges();
                result.SucessMessages.Add("Ubdatedate", "Ubdate sucess");
            }
            return result;


        }




    }
}
