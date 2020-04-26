using MyAPI.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyAPI.Controllers
{
    public class MemberController : ApiController
    {
        private IMemberService MemberService;

        public MemberController(IMemberService memberService)
        {
            this.MemberService = memberService;
        }

        [Route("Member")]
        public IHttpActionResult Get()
        {
            var t = MemberService.Get();
            return Ok();
        }
    }
}
