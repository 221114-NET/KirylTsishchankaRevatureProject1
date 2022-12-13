using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModelsLayer
{
    public class EmpReimbursementSpecific : EmpReimbursementClass
    {
        public EmpReimbursementSpecific(string EmpReimbursementType, string name, string color, int strength, int dexterity) : base(name, color, strength, dexterity)
        {
            EmpReimbursementType = EmpReimbursementType;
        }

        public string EmpReimbursementType { get; set; }// fire, water, air, land, 

        public string SayMyNameEmpReimbursement()
        {
            return $"Hi. Mee-sa named {this.Name}.\nI's is {this.Color}.\nMy strength is {this.Strength}";
        }

    }
}