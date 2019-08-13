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
    public class ManjunathaswamiController : ApiController
    {   
        public IEnumerable<score> Get(string usn)
        {
            Adoconnected dal = new Adoconnected();
            List<score> scorelst = dal.searchscore(usn);
            return scorelst;
        }
    }
}
