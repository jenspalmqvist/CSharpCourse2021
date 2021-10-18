using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsAndLinq
{
    public static class MammalMethods
    {
        public static string AnimalFeeding(Mammal mammal, Diet diet)
        {
            return mammal.Feed(diet);
        }

        public static List<string> AnimalFeeding(List<Mammal> mammals, Diet diet)
        {
            List<string> responses = new List<string>();
            foreach (Mammal mammal in mammals)
            {
                responses.Add(mammal.Feed(diet));
            }
            return responses;
        }

        public static List<string> AnimalFeeding(List<Mammal> mammals, List<Diet> diet)
        {
            List<string> responses = new List<string>();

            for (int i = 0; i < mammals.Count; i++)
            {
                responses.Add(mammals[i].Feed(diet[i]));
            }

            return responses;
        }

        public static List<IAquatic> FindAllAquatics(List<Mammal> allTheAnimals)
        {
            throw new NotImplementedException();
        }

        public static List<IMonotreme> HatchAllEggs(List<IMonotreme> monotremes, List<string> names, List<Sex> sexes)
        {
            List<IMonotreme> babies = new List<IMonotreme>();
            foreach (var monotreme in monotremes)
            {
                if (monotreme.NumberOfEggs == 0)
                {
                    continue;
                }

                babies.AddRange(monotreme.HatchEggs(names.Take(monotreme.NumberOfEggs).ToList(), sexes.Take(monotreme.NumberOfEggs).ToList()));
                names.RemoveRange(0, monotreme.NumberOfEggs);
                sexes.RemoveRange(0, monotreme.NumberOfEggs);
            }
            return babies;
        }

        public static List<IMarsupial> TransformBabiesToAdults(List<IMarsupial> marsupials)
        {
            List<IMarsupial> newAdults = new List<IMarsupial>();
            foreach (var marsupial in marsupials)
            {
                if (marsupial.BabiesInPouch.Count == 0)
                {
                    continue;
                }

                newAdults.AddRange(marsupial.TransformBabyToAdult(true));
            }
            marsupials.AddRange(newAdults);
            return marsupials;
        }

        public static void DiveWithAll(List<IAquatic> aquatics, int numberOfMinutes)
        {
            foreach (var aquatic in aquatics)
            {
                aquatic.Dive(numberOfMinutes);
            }
        }

        public static List<string> JumpWithAll(List<IJumpable> jumpers, int height)
        {
            List<string> responses = new List<string>();
            foreach (var jumper in jumpers)
            {
                responses.Add(jumper.Jump(height));
            }
            return responses;
        }

        public static List<string> JumpWithThoseWhoCan(List<Mammal> mammals, int height)
        {
            var jumpers = mammals.OfType<IJumpable>();
            List<string> responses = new List<string>();
            foreach (var jumper in jumpers)
            {
                responses.Add(jumper.Jump(height));
            }
            return responses;
        }

        public static List<IAquatic> GetAquaticsAndSortByWeight(List<Mammal> mammals)
        {
            var aquatics = mammals.OfType<IAquatic>();
            var sortedAquatics = aquatics.OrderBy(a => (a as Mammal).Weight).ToList();
            return sortedAquatics;
        }

        public static List<string> ListenToTheFoxes(List<Mammal> mammals)
        {
            List<string> response = new List<string>();
            foreach (var mammal in mammals)
            {
                if (mammal is Fox)
                {
                    int numberOfThingsItSays = (mammal as Fox).StuffItSays.Count;
                    for (int i = 0; i < numberOfThingsItSays; i++)
                    {
                        response.Add((mammal as Fox).WhatDoesItSay());
                    }
                    if (numberOfThingsItSays == 0)
                    {
                        response.Add("It is silent");
                    }
                }
            }
            return response;
        }

        public static List<string> FeedMarsupialBabies(List<Mammal> mammals, Diet diet)
        {
            List<string> response = new List<string>();
            List<IMarsupial> marsupials = mammals.OfType<IMarsupial>().ToList();
            foreach (var marsupial in marsupials)
            {
                if (marsupial.BabiesInPouch is null)
                {
                    continue;
                }

                response.AddRange(marsupial.FeedBabies(diet));
            }
            return response;
        }

        public static List<string> FeedAllTheAnimalsAndBabies(List<Mammal> mammals, Diet diet)
        {
            List<string> response = new List<string>();
            foreach (Mammal mammal in mammals)
            {
                response.Add(mammal.Feed(diet));
                if (mammal is IMarsupial && (mammal as IMarsupial).BabiesInPouch is not null)
                {
                    response.AddRange((mammal as IMarsupial).FeedBabies(diet));
                }
            }
            return response;
        }
    }
}