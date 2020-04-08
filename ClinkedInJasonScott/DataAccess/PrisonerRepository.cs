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
                Services = new List<Services>{ Services.Minister, Services.Matchmaking}
            },

            new Prisoner
            {
                Name = "Hooch",
                Age = 21,
                Id = 2,
                Interests = new List<Interest>{ Interest.Pets, Interest.Crafting, Interest.Laundry },
                Services = new List<Services>{ Services.Shanking, Services.Tatter}
             },

            new Prisoner
            {
                Name = "Buzz",
                Age = 61,
                Id = 3,
                Interests = new List<Interest>{ Interest.Exercise, Interest.Laundry },
                Services = new List<Services>{ Services.Protection, Services.Smuggling, Services.Shanking}
            }
        };

        public List<Prisoner> GetAllPrisoners()
        {
            return _prisoners;
        }

        public void AddPrisoner(Prisoner newPrisoner)
        {
            newPrisoner.Id = _prisoners.Max(x => x.Id) + 1;
            _prisoners.Add(newPrisoner);
        }

        public Prisoner GetByName(string prisonerName)
        {
            return _prisoners.FirstOrDefault(p => p.Name == prisonerName);
        }

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


                /* foreach (var interest in Enum.GetValues(typeof(Interest)))
                 {
                     if (interest.ToString() == prisonerInterest)
                     {
                         prisonersInterests.Add(prisoner.Interest.Contains(interest));

                     }
                 }*/
            }

            return prisonersInterests;
        }
    }
}
