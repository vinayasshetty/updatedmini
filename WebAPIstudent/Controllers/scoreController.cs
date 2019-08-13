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
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class scoreController : ApiController
    {
        [HttpPost]
        public void Post(insertscore sc)
        {
            Adoconnected dal = new Adoconnected();
            dal.Insertscore(sc);
        }
       
    }
}
