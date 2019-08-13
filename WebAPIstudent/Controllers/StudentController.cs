using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using studentlib;
using System.Web.Http.Cors;

namespace WebAPIstudent.Controllers
{
    [EnableCors(origins:"*",headers:"*",methods:"*")]
    public class StudentController : ApiController
    {
        
        public string VerifyLogin(Admin adm)
        {
            Admin ad = new Admin();
            return (ad.verifyLogin(adm.username, adm.password));
        }
        //public string VerifyLogina()
        //{
        //    return "hello";
        //}

        // GET api/values
        public IEnumerable<student> Get(int semester)
        {
            Adoconnected dal = new Adoconnected();
            List<student> stdLst = dal.SelectAllstudents(semester);
            return stdLst;
        }
        // PUT api/values/5
        public void Put(string usn, [FromBody]score s)
        {
            Adoconnected dal = new Adoconnected();
            dal.Updatscore(usn, s.marks);

        }

    }

}
