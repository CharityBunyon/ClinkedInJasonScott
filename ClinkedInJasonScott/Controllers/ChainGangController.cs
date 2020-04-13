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

        //List where all prisoners are housed
        PrisonerRepository _repository = new PrisonerRepository();


        //api/chaingang
        // Add Prisoner
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
        //Get all prisoners
        [HttpGet]
        public IActionResult GetAllPrisoners()
        {
            var allPrisoners = _repository.GetAllPrisoners();

            return Ok(allPrisoners);
        }


        //api/chaingang
        //Adding a Friend
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


        // Viewing Friends
        [HttpGet("viewfriends/{id}")]
        public IActionResult ViewFriends(int id)
        {
            var friendsList = _repository.GetFriendsById(id);
            return Ok(friendsList);
        }





        // Adding an Enemy
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


        // Viewing Enemies
        [HttpGet("viewenemies/{id}")]
        public IActionResult ViewEnemeis(int id)
        {
            var enemiesList = _repository.GetEnemiesById(id);
            return Ok(enemiesList);
        }




        // Getting the similar interests
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


        // Add Interest
        [HttpGet("addinterest/{id}/{interest}")]
        public IActionResult AddInterest(int id, Interest interest)
        {
            var updateInterest = _repository.AddInterest(id, interest);

            return Ok(updateInterest);
        }

        //Remove Interest
        [HttpGet("removeinterest/{id}/{interest}")]
        public IActionResult RemoveInterest(int id, Interest interest)
        {
            var updateInterest = _repository.RemoveInterest(id, interest);

            return Ok(updateInterest);
        }





        // Getting the similar services
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


        // Add Service
        [HttpGet("addservice/{id}/{service}")]
        public IActionResult AddService(int id, Services service)
        {
            var updateService = _repository.AddService(id, service);

            return Ok(updateService);
        }

        // Remove Service
        [HttpGet("removeservice/{id}/{service}")]
        public IActionResult RemoveService(int id, Services service)
        {
            var updateService = _repository.RemoveService(id, service);

            return Ok(updateService);
        }


        // Get sentence Date
        [HttpGet("sentence/{id}")]
        public IActionResult GetPrisonerSentence(int id)
        {
            var remainingDays = _repository.GetRemainingDays(id);
            return Ok(remainingDays);
        }
    }
}