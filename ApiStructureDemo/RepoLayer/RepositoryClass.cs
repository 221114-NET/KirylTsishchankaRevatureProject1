using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using ModelsLayer;


namespace RepoLayer
{

    
    public interface IRepositoryClass
    {
        List<Customer> GetCustomerList();
        List<ReimbursementForm> GetCustomerList2();
        List<ReimbursementForm> GetCustomerList3();
        Customer CustomerRegistration(Customer c);
        Customer CustomerLogin(Customer c);
        ReimbursementForm CustomerReimbursementForm(ReimbursementForm c);
        EmpReimbursementClass PostEmpReimbursement(EmpReimbursementClass p);
        EmpReimbursementSpecific PostEmpReimbursementSpecific(EmpReimbursementSpecific ps);
    }

    public class RepositoryClass : IRepositoryClass
    {

        //Giving it a Logger
        private readonly IMyLogger _logger;

        public RepositoryClass(IMyLogger logger)
        {
            _logger = logger;
        }

        public List<Customer> GetCustomerList()
        {
            

            SqlConnection conn = new SqlConnection("Server=tcp:kiryltsishchanka-revature-p1-server.database.windows.net,1433;"+
            "Initial Catalog=RevatureP1Database_kiryl;Persist Security Info=False;"+
            "User ID=kiryl;Password={Password};"+
            "MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

            
            SqlCommand command = new SqlCommand($"SELECT * FROM P1RegistrationTest", conn);
            
            command.Connection.Open();
            SqlDataReader ret = command.ExecuteReader();

            List<Customer> list = new List<Customer>();
            while (ret.Read())
            {
                Customer c = Mapper.DbToCustomer(ret);
                list.Add(c);
            }
            return list;
        }

        public Customer CustomerRegistration(Customer c)
        {
            

            SqlConnection conn = new SqlConnection("Server=tcp:kiryltsishchanka-revature-p1-server.database.windows.net,1433;"+
            "Initial Catalog=RevatureP1Database_kiryl;Persist Security Info=False;"+
            "User ID=kiryl;Password={Password};"+
            "MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");





            SqlCommand command1 = new SqlCommand($"Select * from P1RegistrationTest where UserName =@username", conn);
            command1.Connection.Open();
            
            command1.Parameters.AddWithValue("@UserName", c.UserName);
            

            SqlDataAdapter da = new SqlDataAdapter(command1);
            DataTable dt = new DataTable();
            da.Fill(dt);

            if(dt.Rows.Count>0)
            {
                Console.WriteLine("That Username already exists");
                c.UserName="That Username already exists";

                
                
                return null;
                
                
            }
            else
            {
                
                SqlCommand command2 = new SqlCommand($"INSERT INTO P1RegistrationTest (UserName, UserPassword) VALUES (@UserName,@UserPassword);", conn);
                
                command2.Parameters.AddWithValue("@UserName", c.UserName);
                command2.Parameters.AddWithValue("@UserPassword", c.UserPassword);

                int rowsAffected = command2.ExecuteNonQuery();

                
                if (rowsAffected == 1)
                {
                    
                    conn.Close();
                    c.UserPassword="*****";
                    return c;
                }
                else
                {
                    return null;
                }

                
                
            
            }



        }


        public Customer CustomerLogin(Customer c)
        {
            
            SqlConnection conn = new SqlConnection("Server=tcp:kiryltsishchanka-revature-p1-server.database.windows.net,1433;"+
            "Initial Catalog=RevatureP1Database_kiryl;Persist Security Info=False;"+
            "User ID=kiryl;Password={Password};"+
            "MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");




            SqlCommand command1 = new SqlCommand($"DELETE FROM P1RegistrationTest WHERE UserName=@UserName AND UserPassword=@UserPassword", conn);
            command1.Connection.Open();
            

            
            command1.Parameters.AddWithValue("@UserName", c.UserName);
            command1.Parameters.AddWithValue("@UserPassword", c.UserPassword);
            

            int rowsAffected = command1.ExecuteNonQuery();

            
            
            if (rowsAffected >0)
            {
                
                SqlCommand command2 = new SqlCommand($"INSERT INTO P1RegistrationTest (UserName, UserPassword) VALUES (@UserName,@UserPassword);", conn);
                command2.Parameters.AddWithValue("@UserName", c.UserName);
                command2.Parameters.AddWithValue("@UserPassword", c.UserPassword); 
                command2.ExecuteNonQuery();  
                
                conn.Close();

                Console.WriteLine("Please submit your reimbursement form");
                c.UserPassword="*****";
                
                return c;
            }
            else
            {
                Console.WriteLine("Wrong Username or Password");
                c.UserName="Wrong Username or Password";
                c.UserPassword="Wrong Username or Password";
                
                return null;
            }
        }


        public ReimbursementForm CustomerReimbursementForm(ReimbursementForm c)
        {
            

            SqlConnection conn = new SqlConnection("Server=tcp:kiryltsishchanka-revature-p1-server.database.windows.net,1433;"+
            "Initial Catalog=RevatureP1Database_kiryl;Persist Security Info=False;"+
            "User ID=kiryl;Password={Password};"+
            "MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");


            
            SqlCommand command = new SqlCommand($"INSERT INTO P1ReimbursementFormTest (FirstName, LastName, ETitle, RCategory, TotalAmount, RDescription, RStatus) VALUES (@FirstName,@LastName, @ETitle, @RCategory, @TotalAmount, @RDescription, @RStatus);", conn);
            
            command.Connection.Open();
           

            
            command.Parameters.AddWithValue("@FirstName", c.FirstName);
            command.Parameters.AddWithValue("@LastName", c.LastName);
            command.Parameters.AddWithValue("@ETitle", c.ETitle);
            command.Parameters.AddWithValue("@RCategory", c.RCategory);
            command.Parameters.AddWithValue("@TotalAmount", c.TotalAmount);
            command.Parameters.AddWithValue("@RDescription", c.RDescription);
            command.Parameters.AddWithValue("@RStatus", c.RStatus);
            
            int rowsAffected;
            if (c.RStatus =="Pending")
                {rowsAffected = command.ExecuteNonQuery();}
            else
                {
                    rowsAffected=-1;
                    c.RStatus="Wrong Status";
                }

            
            if (rowsAffected == 1)
            {
                
                conn.Close();
                return c;
            }
            else
            {
                return null;
            }
        }











        public List<ReimbursementForm> GetCustomerList2()
        {
            // user ADO.NET to push the data to the DB.
            /*
            SqlConnection conn = new SqlConnection("Server=tcp:11142022-batch-server.database.windows.net,1433;" +
                "Initial Catalog=111422-batch-db;Persist Security Info=False;" +
                "User ID=mark.moore@revature.com@11142022-batch-server;Password=youneedap1e!;" +
                "MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            */

            SqlConnection conn = new SqlConnection("Server=tcp:kiryltsishchanka-revature-p1-server.database.windows.net,1433;"+
            "Initial Catalog=RevatureP1Database_kiryl;Persist Security Info=False;"+
            "User ID=kiryl;Password={Password};"+
            "MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

            //configure the SQL query along with the connection object
            //SqlCommand command = new SqlCommand($"SELECT * FROM Customers", conn);
            SqlCommand command = new SqlCommand($"SELECT * FROM P1ReimbursementFormTest", conn);
            //Open the Connection - you can access the SqlConnection object directly or through the SqlCommand obj!
            command.Connection.Open();
            SqlDataReader ret = command.ExecuteReader();

            List<ReimbursementForm> list = new List<ReimbursementForm>();
            while (ret.Read())
            {
                ReimbursementForm c = Mapper2.DbToCustomer(ret);
                list.Add(c);
            }
            return list;
        }




        public List<ReimbursementForm> GetCustomerList3()
        {
            // user ADO.NET to push the data to the DB.
            /*
            SqlConnection conn = new SqlConnection("Server=tcp:11142022-batch-server.database.windows.net,1433;" +
                "Initial Catalog=111422-batch-db;Persist Security Info=False;" +
                "User ID=mark.moore@revature.com@11142022-batch-server;Password=youneedap1e!;" +
                "MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            */

            SqlConnection conn = new SqlConnection("Server=tcp:kiryltsishchanka-revature-p1-server.database.windows.net,1433;"+
            "Initial Catalog=RevatureP1Database_kiryl;Persist Security Info=False;"+
            "User ID=kiryl;Password={Password};"+
            "MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

            //configure the SQL query along with the connection object
            //SqlCommand command = new SqlCommand($"SELECT * FROM Customers", conn);
            SqlCommand command1 = new SqlCommand($"UPDATE P1ReimbursementFormTest SET RStatus='Approved'", conn);
            //SqlCommand command2 = new SqlCommand($"SELECT * FROM P1ReimbursementFormTest", conn);
            //Open the Connection - you can access the SqlConnection object directly or through the SqlCommand obj!
            command1.Connection.Open();
            //command1.ExecuteReader();
            SqlDataReader ret = command1.ExecuteReader();

            List<ReimbursementForm> list = new List<ReimbursementForm>();
            while (ret.Read())
            {
                ReimbursementForm c = Mapper2.DbToCustomer(ret);
                list.Add(c);
            }
            return list;
        }


        public EmpReimbursementClass PostEmpReimbursement(EmpReimbursementClass p)
        {
            p.Dexterity = 100;
            if (File.Exists("EmpReimbursementList.json"))
            {
                string oldPlist = File.ReadAllText("EmpReimbursementList.json");

                // do the file saving
                List<EmpReimbursementClass> plist = JsonSerializer.Deserialize<List<EmpReimbursementClass>>(oldPlist)!;// the ! is to permanently denot tht I know it may be a null value

                plist.Add(p);

                string pliststr = JsonSerializer.Serialize(plist);

                File.WriteAllText("EmpReimbursementList.json", pliststr);

                _logger.LogStuff(p);

                return p;
            }
            else
            {
                List<EmpReimbursementClass> plist = new List<EmpReimbursementClass>();
                plist.Add(p);

                string pliststr = JsonSerializer.Serialize(plist);

                File.WriteAllText("EmpReimbursementList.json", pliststr);
                _logger.LogStuff(p);
                return p;
            }

        }

        public EmpReimbursementSpecific PostEmpReimbursementSpecific(EmpReimbursementSpecific ps)
        {
            ps.Name = ps.Name + "-gatherer";
            return ps;
        }

        

    }
}