﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;

namespace SampleApp.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        // GET: api/values        
        [HttpGet]
        public object Get()
        {
            return new
            {
                theFirstValue = "This is the first value",
                aSecondValue = "This is a second value",
                WebSiteURL = "http://www.sorting.se",
                IPhoneDeviceTokenID = Guid.NewGuid()
            };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id, [FromQuery]string postName = "")
        {
            return "value: " + postName;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
