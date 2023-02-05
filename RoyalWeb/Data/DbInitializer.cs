using System.Diagnostics;
using RoyalWeb.Models;
using System;
using System.Linq;

namespace RoyalWeb.Data
{
    public class DbInitializer
    {

        public static void Initialize(RoyalContext context)
        {
            context.Database.EnsureCreated();

            // Look for any characers.
            if (context.Characters.Any())
            {
                return;   // DB has been seeded
            }

            var characters = new Character[]
            {
            new Character{CharacterId=0, CharacterName="john test", Honor=1, Reputation=1, Appearance=1, Extrovertness=1, Intelligence=1, Sexuality=1, Gender=1, Age=1, Alive=true}

            };
            foreach (Character c in characters)
            {
                context.Characters.Add(c);
            }
            context.SaveChanges();


        }

    }
}
    


