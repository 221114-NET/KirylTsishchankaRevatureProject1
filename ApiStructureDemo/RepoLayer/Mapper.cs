using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using ModelsLayer;

namespace RepoLayer
{
    internal static class Mapper
    {
        internal static Customer DbToCustomer(SqlDataReader sdr)
        {
            Customer c = new Customer();

            try
            {

                
                c.CustomerId = sdr.GetInt32(0);
                c.UserName = sdr.GetString(1);
                c.UserPassword = sdr.GetString(2);
                throw new YourOwnPersonalException();// manually throw an exception
            }
            catch (YourOwnPersonalException ex)
            {
                Console.WriteLine(ex.message);
            }
            return c;
        }
    }


    internal static class Mapper2
    {
        internal static ReimbursementForm DbToCustomer(SqlDataReader sdr)
        {
            ReimbursementForm c = new ReimbursementForm();

            try
            {

                

                c.ReimbursementFormId = sdr.GetInt32(0);
                c.FirstName = sdr.GetString(1);
                c.LastName = sdr.GetString(2);
                c.ETitle = sdr.GetString(3);
                c.RCategory = sdr.GetString(4);
                c.TotalAmount = sdr.GetDecimal(5);
                c.RDescription = sdr.GetString(6);
                c.RStatus = sdr.GetString(7);
                throw new YourOwnPersonalException();// manually throw an exception
            }
            catch (YourOwnPersonalException ex)
            {
                Console.WriteLine(ex.message);
            }
            return c;
        }
    }






}