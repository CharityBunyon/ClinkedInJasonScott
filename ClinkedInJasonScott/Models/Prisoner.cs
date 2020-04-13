using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinkedInJasonScott.Models
{
    public class Prisoner
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        //Lists
        public List<Interest> Interests { get; set; }
        public List<Services> Services { get; set; }

       
        public List<int> Friends { get; set; }
        public List<int> Enemies { get; set; }

        // Sentence Time
        public DateTime SentenceComplete { get; set; }
    }

    public enum Interest
    {
        Music,
        Pets,
        Laundry,
        Crafting,
        Stealing,
        Exercise
    }

    public enum Services
    {
        Shanking,
        Smuggling,
        Tatter,
        Protection,
        Matchmaking,
        Minister
    }
    
}
