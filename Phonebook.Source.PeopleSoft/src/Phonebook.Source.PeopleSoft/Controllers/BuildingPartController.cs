﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Phonebook.Source.PeopleSoft.Models;

namespace Phonebook.Source.PeopleSoft.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuildingPartController : ControllerBase
    {
        public ModelContext Context { get; }

        public BuildingPartController(ModelContext context)
        {
            Context = context;
        }
        // GET: api/BuildingPart
        [HttpGet]
        public IEnumerable<BuildingPart> Get()
        {
            return Context.BuildingParts;
        }

        // GET: api/BuildingPart/5
        [HttpGet("{id}")]
        public BuildingPart Get(int id)
        {
            return Context.BuildingParts.First(b => b.Id == id);
        }

        // POST: api/BuildingPart
        [HttpPost]
        public void Post([FromBody] BuildingPart value)
        {
        }

        // PUT: api/BuildingPart/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] BuildingPart value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
