using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ModelsLayer
{
    public class Customer
    {
        public Customer()
        {
        }

        public Customer(int customerId, string username, string userpassword)
        {
            CustomerId = customerId;
            UserName=username;
            UserPassword=userpassword;
            
        }

        


        public int CustomerId { get; set; }

        [JsonPropertyName("username")]
        [StringLength(50, ErrorMessage = "That User Name is too long or too short. It should be at least 5 and at most 50 characters long.", MinimumLength = 5)]

        public string UserName { get; set; }
        
        [JsonPropertyName("userpassword")]
        [StringLength(20, ErrorMessage = "That Password is too long or too short. It should be at least 5 and at most 20 characters long.", MinimumLength = 5)]

        public string UserPassword { get; set; }

        
    }




    public class ReimbursementForm
    {
        public ReimbursementForm()
        {
        }

        public ReimbursementForm(int reimbursementformId, string firstName, string lastName, string etitle, string rCategory, decimal totalAmount, string rDescription, string rStatus)
        {
            ReimbursementFormId = reimbursementformId;
            FirstName = firstName;
            LastName = lastName;
            ETitle = etitle;
            RCategory = rCategory;
            TotalAmount = totalAmount;
            RDescription=rDescription;
            RStatus=rStatus;
            
        }

        


        public int ReimbursementFormId { get; set; }

        [JsonPropertyName("firstName")]
        [StringLength(20, ErrorMessage = "That First Name is too long or too short. It should be at least 2 and at most 30 characters long.", MinimumLength = 2)]

        public string FirstName { get; set; }
        
        [JsonPropertyName("lastName")]
        [StringLength(50, ErrorMessage = "That Last Name is too long or too short. It should be at least 2 and at most 30 characters long.", MinimumLength = 2)]

        public string LastName { get; set; }

        [JsonPropertyName("etitle")]
        [StringLength(50, ErrorMessage = "That Title is too long or too short. It should be at least 2 and at most 50 characters long.", MinimumLength = 2)]

        public string ETitle { get; set; }

        [JsonPropertyName("rCategory")]
        [StringLength(50, ErrorMessage = "That Category is too long or too short. It should be at least 2 and at most 50 characters long.", MinimumLength = 2)]

        public string RCategory { get; set; }

        public decimal TotalAmount { get; set; }

        public string RDescription { get; set; }
        public string RStatus { get; set; }
        
        
    }




}