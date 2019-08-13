using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace studentlib
{
    public class Admin
    {
        public string username { get; set; }
        public string password { get; set; }
        public string verifyLogin(string username,string password)
        {
            if(username=="vinaya" && password=="amma9686")
            {
               return "success";
            }
            else
            {
                return "failed";
            }
           
        }
    }
    
}
