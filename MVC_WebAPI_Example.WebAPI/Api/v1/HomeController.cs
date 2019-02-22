﻿using System.Collections.Generic;
using System.Web.Http;
using MVC_WebAPI_Example.BLL.Common.Interfaces;

namespace MVC_WebAPI_Example.WebAPI.Api.v1
{
    public class HomeController : ApiController
    {
        private readonly ITestService service;

        public HomeController(ITestService service)
        {
            this.service = service;
        }

        // GET: api//v1/Home
        public IEnumerable<string> Get()
        {
            var result = service.Method1();

            return result;
        }

        // GET: api//v1/Home/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/v1/Home
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/v1/Home/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/v1/Home/5
        public void Delete(int id)
        {
        }
    }
}