using System;
using ClinkedInJasonScott.Models;
using System.Collections.Generic;
using System.Linq;

namespace ClinkedInJasonScott.DataAccess
{
    public class PrisonerRepository
    {

        static List<Prisoner> _prisoners = new List<Prisoner>
        {
            new Prisoner
            {
                Name = "Bones",
                Age = 47,
                Id = 1,
                Interests = new List<Interest>{ Interest.Crafting, Interest.Music, Interest.Pets, Interest.Stealing },
                Services = new List<Services>{ Services.Minister, Services.Matchmaking},
                Friends = new List<int>(),
                Enemies = new List<int>(),
                SentenceComplete = new DateTime(2020,12,25)
            },

            new Prisoner
            {
                Name = "Hooch",
                Age = 21,
                Id = 2,
                Interests = new List<Interest>{ Interest.Pets, Interest.Crafting, Interest.Laundry },
                Services = new List<Services>{ Services.Shanking, Services.Tatter},
                Friends = new List<int>(),
                Enemies = new List<int>(),
                SentenceComplete = new DateTime(2025,1,22)
             },

            new Prisoner
            {
                Name = "Buzz",
                Age = 61,
                Id = 3,
                Interests = new List<Interest>{ Interest.Exercise, Interest.Laundry },
                Services = new List<Services>{ Services.Protection, Services.Smuggling, Services.Shanking},
                Friends = new List<int>(),
                Enemies = new List<int>(),
                SentenceComplete = new DateTime(2021,2,5)
            },

            new Prisoner
            {
                Name = "Fred",
                Age = 40,
                Id = 4,
                Interests = new List<Interest>{ Interest.Crafting, Interest.Music, Interest.Pets, Interest.Stealing },
                Services = new List<Services>{ Services.Minister, Services.Matchmaking},
                Friends = new List<int>(),
                Enemies = new List<int>(),
                SentenceComplete = new DateTime(2050,8,14)
            },
            
        };

        // Get all prisoners
        public List<Prisoner> GetAllPrisoners()
        {
            return _prisoners;
        }


        // Get prisoner by ID
        public Prisoner GetPrisonerById(int prisonerId)
        {
            return _prisoners.First(p => p.Id == prisonerId);
        }

        // Get prisoner by Name
        public Prisoner GetByName(string prisonerName)
        {
            return _prisoners.FirstOrDefault(p => p.Name == prisonerName);
        }

        // Add a prisoner
        public void AddPrisoner(Prisoner newPrisoner)
        {
            newPrisoner.Id = _prisoners.Max(x => x.Id) + 1;
            _prisoners.Add(newPrisoner);
        }



        // Add a friend
        public void AddFriend(Prisoner prisoner, Prisoner friend)
        {
            prisoner.Friends.Add(friend.Id);
            friend.Friends.Add(prisoner.Id);
        }

        //Viewing A Prisoners Friends - pass in prisoner id and put all friends in myfriends list
        public List<Prisoner> GetFriendsById(int id)
        {
            var prisoner = GetPrisonerById(id);
            var myFriends = new List<Prisoner>();
            foreach ( var friend in prisoner.Friends)
            {
                myFriends.Add(GetPrisonerById(friend));
            }
            return myFriends;
        }


        // Adding an Enemy

        public void AddEnemy(Prisoner prisoner, Prisoner enemy)
        {
            prisoner.Enemies.Add(enemy.Id);
            enemy.Enemies.Add(prisoner.Id);
        }


        // Viewing an prisoner enemies
        public List<Prisoner> GetEnemiesById(int id)
        {
            var prisoner = GetPrisonerById(id);
            var myEnemies = new List<Prisoner>();
            foreach (var enemy in prisoner.Enemies)
            {
                myEnemies.Add(GetPrisonerById(enemy));
            }
            return myEnemies;
        }

        

        // Get all prisoners with similar interests
        public List<Prisoner> GetByInterest(string prisonerInterest)
        { 
            List<Prisoner> prisonersInterests = new List<Prisoner>();

            foreach (var prisoner in _prisoners)
            {
                foreach (var interest in prisoner.Interests)
                {
                    if (interest.ToString() == prisonerInterest)
                    {
                        prisonersInterests.Add(prisoner);
                    }
                }
            }
            return prisonersInterests;
         
        }

        // Add interests
        public Prisoner AddInterest(int id, Interest interestId)
        {
            var prisonerToUpdate = GetPrisonerById(id);
            prisonerToUpdate.Interests.Add(interestId);
            List<Interest> uniqueInterests = prisonerToUpdate.Interests.Distinct().ToList();
            prisonerToUpdate.Interests = uniqueInterests;
            return prisonerToUpdate;
        }

        // Remove interests
        public Prisoner RemoveInterest(int id, Interest interestId)
        {
            var prisonerToUpdate = GetPrisonerById(id);
            prisonerToUpdate.Interests.Remove(interestId);
            return prisonerToUpdate;
        }



        // Get all prisoners with similar services
        public List<Prisoner> GetByServices(string prisonerService)
        {
            List<Prisoner> prisonersServices = new List<Prisoner>();

            foreach (var prisoner in _prisoners)
            {
                foreach (var service in prisoner.Services)
                {
                    if (service.ToString() == prisonerService)
                    {
                        prisonersServices.Add(prisoner);
                    }
                }
            }
            return prisonersServices;
        }



        //Add services
        public Prisoner AddService(int id, Services serviceId)
        {
            var prisonerToUpdate = GetPrisonerById(id);
            prisonerToUpdate.Services.Add(serviceId);
            List<Services> uniqueServices = prisonerToUpdate.Services.Distinct().ToList();
            prisonerToUpdate.Services = uniqueServices;
            return prisonerToUpdate;
        }


        // Remove services
        public Prisoner RemoveService(int id, Services serviceId)
        {
            var prisonerToUpdate = GetPrisonerById(id);
            prisonerToUpdate.Services.Remove(serviceId);
            return prisonerToUpdate;
        }


        // Get a Prisoners remaining days in prison
        public string GetRemainingDays(int id)
        {
            DateTime today = DateTime.Today;

            var prisoner = GetPrisonerById(id);

            int daysDiff = ((TimeSpan)(prisoner.SentenceComplete - today)).Days;

            return ($"{prisoner.Name} has {daysDiff} days left to complete their sentence.");
        }
    }
}
