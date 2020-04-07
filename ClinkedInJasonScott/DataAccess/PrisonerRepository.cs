using ClinkedInJasonScott.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
                Id = 1
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
    }
}
