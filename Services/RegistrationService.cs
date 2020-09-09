using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class RegistrationService
    {
        RegistrationRepository regRepo;
        public RegistrationService()
        {
            regRepo = new RegistrationRepository();
        }
        public int UserRegistration(string fname, string lname, string email, string dob, string phone, string region, string state, string religion, string username, string password)
        {
            return regRepo.Register(fname,lname,email,dob,phone,region,state,religion,username,password);
        }
    }
}
