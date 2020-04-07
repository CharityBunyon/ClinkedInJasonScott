﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinkedInJasonScott.DataAccess;
using ClinkedInJasonScott.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinkedInJasonScott.Controllers
{
    [Route("api/chaingang")]
    [ApiController]
    public class ChainGangController : ControllerBase
    {
        PrisonerRepository _repository = new PrisonerRepository();

        //api/chaingang
        [HttpPost]
        public IActionResult AddPrisoner(Prisoner prisonerToAdd)
        {
            var existingPrisoner = _repository.GetByName(prisonerToAdd.Name);
            if (existingPrisoner == null)
            {
                _repository.AddPrisoner(prisonerToAdd);
                return Created("", prisonerToAdd);
            }

            return NotFound("Prisoner already exists");
        }

        // api/chaingang
        [HttpGet]
        public IActionResult GetAllPrisoners()
        {
            var allPrisoners = _repository.GetAllPrisoners();

            return Ok(allPrisoners);
        }
    }
}