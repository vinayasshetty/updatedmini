using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using studentlib;
namespace WebAPIstudent.Controllers
{
    
    public class branchController : ApiController
    {
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        //public subject Get(string branchid, int semester)
        //{
        //    Adoconnected dal = new Adoconnected();
        //    subject sbb = dal.selectsubid(branchid, semester);

        //    return sbb;
        //}
        public IEnumerable<string> Get(string branchid,int semester)
        {
            Adoconnected dal = new Adoconnected();
            List<string> stdLst = dal.selectsubid(branchid, semester);
            return stdLst;
        }
    }
}
