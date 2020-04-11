using System;
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

        [HttpGet("interest/{interests}")]
        public IActionResult GetPrisonerInterests(string interests)
        {
            var allInterests = _repository.GetByInterest(interests);
            if (allInterests.Count > 0)
            {
                return Ok(allInterests);
            }

            return NotFound("Prisoner doesn't have similar interests.");
        }

        [HttpGet("service/{services}")]
        public IActionResult GetPrisonerServices(string services)
        {
            var allServices = _repository.GetByServices(services);
            if (allServices.Count > 0)
            {
                return Ok(allServices);
            }

            return NotFound("Prisoner doesn't have similar services.");

        }

        //api/chaingang
        [HttpGet("friendshipforever/{id2:int}/{id:int}")]
        public IActionResult AddFriend(int id2, int id)
        {
            var friend = _repository.GetPrisonerById(id);
            var currentPrisoner = _repository.GetPrisonerById(id2);
            if (currentPrisoner.Id != id && friend != null)
            {
                _repository.AddFriend(currentPrisoner, friend);
                return Ok(currentPrisoner);
            }

            return NotFound("Could not find your Friend.");
        }

        [HttpGet("enemies/{id2:int}/{id:int}")]
        public IActionResult AddEnemy(int id2, int id)
        {
            var enemy = _repository.GetPrisonerById(id);
            var currentPrisoner = _repository.GetPrisonerById(id2);
            if (currentPrisoner.Id != id && enemy != null)
            {
                _repository.AddEnemy(currentPrisoner, enemy);
                return Ok(currentPrisoner);
            }

            return NotFound("Could not find your Enemy.");
        }

        [HttpGet("sentence/{id}")]
        public IActionResult GetPrisonerSentence(int id)
        {
            var remainingDays = _repository.GetRemainingDays(id);
            return Ok(remainingDays);
        }
    }
}