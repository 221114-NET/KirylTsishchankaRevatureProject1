using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ModelsLayer;
using RepoLayer;

namespace tests.api
{
    public class MockRepoLayer : IRepositoryClass
    {
        public List<Customer> GetCustomerList()
        {
            Customer c1 = new Customer(1, "m1", "m1");
            Customer c2 = new Customer(1, "m2", "m2");
            List<Customer> list = new List<Customer>() { c1, c2};
            return list;

        }

        public List<ReimbursementForm> GetCustomerList2()
        {
            ReimbursementForm c1 = new ReimbursementForm(1, "m1", "m1", "m1", "m1", 1, "m1", "m1");
            ReimbursementForm c2 = new ReimbursementForm(1, "m2", "m2", "m2", "m2", 1, "m2", "m2");
            List<ReimbursementForm> list = new List<ReimbursementForm>() { c1, c2};
            return list;
            
            
            //throw new NotImplementedException();

        }

        public List<ReimbursementForm> GetCustomerList3()
        {
            ReimbursementForm c1 = new ReimbursementForm(1, "m1", "m1", "m1", "m1", 1, "m1", "m1");
            ReimbursementForm c2 = new ReimbursementForm(1, "m2", "m2", "m2", "m2", 1, "m2", "m2");
            List<ReimbursementForm> list = new List<ReimbursementForm>() { c1, c2};
            return list;

        }

        public Customer CustomerRegistration(Customer c)
        {
            throw new NotImplementedException();
        }

        public Customer CustomerLogin(Customer c)
        {
            throw new NotImplementedException();
        }

        public ReimbursementForm CustomerReimbursementForm(ReimbursementForm c)
        {
            throw new NotImplementedException();
        }

        
        public EmpReimbursementClass PostEmpReimbursement(EmpReimbursementClass p)
        {
            throw new NotImplementedException();

        }

        public EmpReimbursementSpecific PostEmpReimbursementSpecific(EmpReimbursementSpecific ps)
        {
            throw new NotImplementedException();

        }


    }
}