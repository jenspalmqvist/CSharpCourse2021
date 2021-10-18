using System;
using System.Collections.Generic;

namespace GenericsAndLinq
{
    class Program
    {
        static List<Mammal> SetupList()
        {
            List<Mammal> allTheAnimals = new List<Mammal>();
            allTheAnimals.Add(new Dolphin(sex: Sex.Male, name: "Dolph", weight: 23, diet: Diet.Carnivore, isHungry: true, maxTimeUnderWater: 8, jumpingHeight: 4));
            allTheAnimals.Add(new Dolphin(sex: Sex.Female, name: "Dolphina", weight: 18, diet: Diet.Carnivore, isHungry: true, maxTimeUnderWater: 8, jumpingHeight: 4));
            allTheAnimals.Add(new Dolphin(sex: Sex.Female, name: "Dolly", weight: 28, diet: Diet.Herbivore, isHungry: false, maxTimeUnderWater: 12, jumpingHeight: 1));
            allTheAnimals.Add(new Dolphin(sex: Sex.Male, name: "Danny", weight: 12, diet: Diet.Carnivore, isHungry: true, maxTimeUnderWater: 5, jumpingHeight: 9));
            allTheAnimals.Add(new Whale(sex: Sex.Female, name: "Wailord", weight: 44600, diet: Diet.Carnivore, isHungry: true, maxTimeUnderWater: 90, jumpingHeight: 2));
            allTheAnimals.Add(new Whale(sex: Sex.Female, name: "Otis", weight: 43952, diet: Diet.Carnivore, isHungry: true, maxTimeUnderWater: 70, jumpingHeight: 3));
            allTheAnimals.Add(new Platypus(sex: Sex.Female, name: "Penny", weight: 2.3, diet: Diet.Carnivore, isHungry: true, maxTimeUnderWater: 10, numberOfEggs: 3));
            allTheAnimals.Add(new Platypus(sex: Sex.Male, name: "Perry", weight: 3, diet: Diet.Carnivore, isHungry: true, maxTimeUnderWater: 10));
            allTheAnimals.Add(new Platypus(sex: Sex.Female, name: "Ploppy", weight: 2.7, diet: Diet.Carnivore, isHungry: true, maxTimeUnderWater: 11, numberOfEggs: 1));
            allTheAnimals.Add(new Platypus(sex: Sex.Male, name: "Poppy", weight: 3.3, diet: Diet.Carnivore, isHungry: false, maxTimeUnderWater: 9));
            allTheAnimals.Add(new Echidna(sex: Sex.Female, name: "Edna", weight: 23, diet: Diet.Carnivore, isHungry: true, numberOfEggs: 8, numberOfSpikes: 123));
            allTheAnimals.Add(new Echidna(sex: Sex.Male, name: "Eddy", weight: 22, diet: Diet.Carnivore, isHungry: true, numberOfSpikes: 120));
            allTheAnimals.Add(new Echidna(sex: Sex.Male, name: "Edd", weight: 26, diet: Diet.Carnivore, isHungry: true, numberOfSpikes: 112));
            allTheAnimals.Add(new Echidna(sex: Sex.Male, name: "Eddie", weight: 21, diet: Diet.Carnivore, isHungry: true, numberOfSpikes: 143));
            allTheAnimals.Add(new Fox(sex: Sex.Female, name: "Ylvis", weight: 9, diet: Diet.Carnivore, isHungry: true, stuffItSays: new List<string>()
                 { "Ring-ding-ding-ding-dingeringeding!", "Wa-pa-pa-pa-pa-pa-pow!", "Hatee-hatee-hatee-ho!", "Joff-tchoff-tchoffo-tchoffo-tchoff!" }));
            allTheAnimals.Add(new Fox(sex: Sex.Male, name: "Elvis", weight: 10.3, diet: Diet.Carnivore, isHungry: true, stuffItSays: new List<string>()
                 { "Uh-uh-uh!", "Blue suede shoes!", "A little less conversation, a little more action!" }));
            allTheAnimals.Add(new Fox(sex: Sex.Male, name: "Tystis", weight: 12, diet: Diet.Carnivore, isHungry: true, stuffItSays: new List<string>()));
            allTheAnimals.Add(new Fox(sex: Sex.Female, name: "Foxxy", weight: 14, diet: Diet.Carnivore, isHungry: true, stuffItSays: new List<string>()));
            allTheAnimals.Add(new Hamster(sex: Sex.Male, name: "Hammer", weight: 3, diet: Diet.Herbivore, isHungry: false));
            allTheAnimals.Add(new Hamster(sex: Sex.Female, name: "Humster", weight: 2, diet: Diet.Herbivore, isHungry: false));
            allTheAnimals.Add(new Kangaroo(sex: Sex.Female, name: "Kängu", weight: 30, diet: Diet.Herbivore, isHungry: true, jumpingHeight: 2, babiesInPouch: new List<IMarsupial>()
                { new Kangaroo(sex: Sex.Female, name: "Mini", weight: 3, diet: Diet.Milk, isHungry: true, jumpingHeight: 0) }));
            allTheAnimals.Add(new Kangaroo(sex: Sex.Female, name: "Kanga", weight: 33, diet: Diet.Herbivore, isHungry: true, jumpingHeight: 2, babiesInPouch: new List<IMarsupial>()
                { new Kangaroo(sex: Sex.Female, name: "Midi", weight: 4.5, diet: Diet.Milk, isHungry: true, jumpingHeight: 0) }));
            allTheAnimals.Add(new Kangaroo(sex: Sex.Male, name: "Ru", weight: 36, diet: Diet.Herbivore, isHungry: true, jumpingHeight: 4));
            allTheAnimals.Add(new Kangaroo(sex: Sex.Male, name: "Roo", weight: 32, diet: Diet.Herbivore, isHungry: true, jumpingHeight: 4));
            allTheAnimals.Add(new Opossum(sex: Sex.Female, name: "Oompa", weight: 3, diet: Diet.Herbivore, isHungry: true, babiesInPouch: new List<IMarsupial>()
                { new Opossum(sex: Sex.Male, name: "Loompa", weight: 1, diet: Diet.Milk, isHungry: false) }));
            allTheAnimals.Add(new Opossum(sex: Sex.Female, name: "Oprah", weight: 4.2, diet: Diet.Herbivore, isHungry: true, babiesInPouch: new List<IMarsupial>()
                { new Opossum(sex: Sex.Male, name: "Winfrey", weight: 1.3, diet: Diet.Milk, isHungry: false),
                  new Opossum(sex: Sex.Female, name: "Winny", weight: 0.9, diet: Diet.Milk, isHungry: true) }));

            return allTheAnimals;
        }

        static void Main(string[] args)
        {
            var allTheAnimals = SetupList();
        }
    }
}