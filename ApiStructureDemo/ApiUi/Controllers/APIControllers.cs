using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ModelsLayer;
using BusinessLayer;
using System.Text.Json;


namespace ApiUi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmpReimbursement : ControllerBase
    {
        private readonly IBusinessLayerClass _ibus;

        public EmpReimbursement(IBusinessLayerClass ibus)
        {
            this._ibus = ibus;
        }

        


        [HttpPost("CustomerRegistration")]
        public ActionResult<Customer> CustomerRegistration(Customer c)
        {
            if (ModelState.IsValid)
            {
                Customer c1 = this._ibus.CustomerRegistration(c);
            }
            else
            {
                return NotFound("that modelbinding did't work");
            }
            return Created($"https://localhost:7007/api/EmpReimbursement/getcustomer/{c.CustomerId}", c);
        }


        [HttpPost("CustomerLogin")]
        public ActionResult<Customer> CustomerLogin(Customer c)
        {
            if (ModelState.IsValid)
            {
                Customer c1 = this._ibus.CustomerLogin(c);
                
            }
            else
            {
                return NotFound("that modelbinding did't work");
            }
            return Created($"https://localhost:7007/api/EmpReimbursement/getcustomer/{c.CustomerId}", c);
        }


        
        [HttpPost("CustomerReimbursementForm")]
        public ActionResult<ReimbursementForm> CustomerReimbursementForm(ReimbursementForm c)
        {
            if (ModelState.IsValid)
            {
                ReimbursementForm c1 = this._ibus.CustomerReimbursementForm(c);
                
            }
            else
            {
                return NotFound("that modelbinding did't work");
            }
            return Created($"https://localhost:7007/api/EmpReimbursement/getcustomer/{c.ReimbursementFormId}", c);
        }


        

        [HttpGet("GetReimbursementForms")]
        public ActionResult<List<ReimbursementForm>> Customers2(int? id)
        {
            //checkif the id is null or 0
            if (id == null || id == 0)
            {
                //get the whole list.
                List<ReimbursementForm> customerList2 = this._ibus.GetCustomerList2();
                if (customerList2 == null)
                {
                    return Problem("It's not you. It's us.... We cannot deliver.");
                }
                else return Ok(customerList2);
            }
            else
            {
                return null;// TODO
            }
        }


        
        [HttpGet("ManagerApprovesRequests")]
        public ActionResult<List<ReimbursementForm>> Customers3(int? id)
        {
            //checkif the id is null or 0
            if (id == null || id == 0)
            {
                //get the whole list.
                List<ReimbursementForm> customerList3 = this._ibus.GetCustomerList3();
                if (customerList3 == null)
                {
                    return Problem("It's not you. It's us.... We cannot deliver.");
                }
                else return Ok(customerList3);
            }
            else
            {
                return null;// TODO
            }
        }




    }
}