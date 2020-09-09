using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Drawing;
using System.Threading.Tasks;


namespace Services
{
    public class LogInService
    {
        LogInRepository credRepo;
        public LogInService()
        {
            credRepo = new LogInRepository();
        }

        public int LoginValidation(string username, string password)
        {
            return credRepo.Validation(username, password);
           
        }
    }
}
