using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ModelsLayer;
using RepoLayer;

namespace BusinessLayer
{
    public interface IBusinessLayerClass
    {
        EmpReimbursementClass CastingPostEmpReimbursementSpecific(object ps);
        List<Customer> GetCustomerList();
        List<ReimbursementForm> GetCustomerList2();
        List<ReimbursementForm> GetCustomerList3();
        Customer CustomerRegistration(Customer c);
        Customer CustomerLogin(Customer c);
        ReimbursementForm CustomerReimbursementForm(ReimbursementForm c);
        EmpReimbursementClass PostEmpReimbursement(EmpReimbursementClass p);
        EmpReimbursementSpecific PostEmpReimbursementSpecific(EmpReimbursementSpecific ps);
    }

    public class BusinessLayerClass : IBusinessLayerClass
    {
        private readonly IRepositoryClass _repo;

        public BusinessLayerClass(IRepositoryClass repo)
        {
            _repo = repo;
        }

        public EmpReimbursementClass CastingPostEmpReimbursementSpecific(object ps)
        {
            if (ps is EmpReimbursementClass)// use is to cehck if a type is actually another types.. of a type you want to check for.
            {
                Console.WriteLine($"This object is a {ps.ToString()}");
                EmpReimbursementClass? ps1 = ps as EmpReimbursementClass;// use as to convert to another type.
                ps1.Name = "Did it work";
                return ps1;
            }
            else if (ps is EmpReimbursementSpecific)
            {
                Console.WriteLine($"This object is a {ps.ToString()}");
                return (EmpReimbursementClass)ps;
            }
            else
            {
                Console.WriteLine($"This object is a {ps.ToString()}");
                return (EmpReimbursementClass)ps;
            }
        }

        public List<Customer> GetCustomerList()
        {
            List<Customer> l = this._repo.GetCustomerList();
            

             return l;
        }

        public List<ReimbursementForm> GetCustomerList2()
        {
            List<ReimbursementForm> l = this._repo.GetCustomerList2();
            

            return l;
        }

        public List<ReimbursementForm> GetCustomerList3()
        {
            List<ReimbursementForm> l = this._repo.GetCustomerList3();
            

            return l;
        }

        public Customer CustomerRegistration(Customer c)
        {
            Customer c1 = this._repo.CustomerRegistration(c);
            return c1;
        }

        public Customer CustomerLogin(Customer c)
        {
            Customer c1 = this._repo.CustomerLogin(c);
            return c1;
        }

        public ReimbursementForm CustomerReimbursementForm(ReimbursementForm c)
        {
            ReimbursementForm c1 = this._repo.CustomerReimbursementForm(c);
            return c1;
        }

        


        public EmpReimbursementClass PostEmpReimbursement(EmpReimbursementClass p)
        {
            p.Color = "blue";
            EmpReimbursementClass p1 = _repo.PostEmpReimbursement(p);
            return p1;

        }

        public EmpReimbursementSpecific PostEmpReimbursementSpecific(EmpReimbursementSpecific ps)
        {
            ps.Dexterity++;
            ps.Color = "Blue";

            // Implicitely convert the derived class to the parent class.
            EmpReimbursementClass p = ps;
            Console.WriteLine($"My color is {p.Color}");

            //explicitely cast the parent to the child.
            EmpReimbursementSpecific ps1 = (EmpReimbursementSpecific)p;
            Console.WriteLine($"My color is {p.Color} and Type is  {ps1.EmpReimbursementType} my sentence is\n\t{ps1.SayMyNameEmpReimbursement()}");

            // Liskov Substitution Principle
            int myInt = 220;
            double myDouble = myInt;//implicit conversion because the in will not loose data.
            myDouble += .03;
            Console.WriteLine(myDouble);

            int myInt1 = (int)myDouble;// explicit conversion to a smaller data type
            Console.WriteLine(myInt1);

            EmpReimbursementSpecific ps2 = this._repo.PostEmpReimbursementSpecific(ps);
            return ps2;
        }
    }
}