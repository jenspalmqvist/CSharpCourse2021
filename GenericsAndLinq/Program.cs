using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericsAndLinq
{
    class Program
    {
        static List<Mammal> SetupList()
        {
            List<Mammal> allTheAnimals = new List<Mammal>();
            allTheAnimals.Add(new Dolphin(sex: Sex.Male, name: "Dolph", weight: 23, diet: Diet.Carnivore, isHungry: true, maxTimeUnderWater: 8, jumpingHeight: 4));
            allTheAnimals.Add(new Dolphin(sex: Sex.Male, name: "Dolph", weight: 23, diet: Diet.Carnivore, isHungry: true, maxTimeUnderWater: 8, jumpingHeight: 4));
            allTheAnimals.Add(new Dolphin(sex: Sex.Female, name: "Dolphy", weight: 28, diet: Diet.Herbivore, isHungry: true, maxTimeUnderWater: 12, jumpingHeight: 1));
            allTheAnimals.Add(new Dolphin(sex: Sex.Male, name: "Dolph", weight: 12, diet: Diet.Carnivore, isHungry: true, maxTimeUnderWater: 5, jumpingHeight: 9));
            allTheAnimals.Add(new Whale(sex: Sex.Female, name: "Wailord", weight: 44600, diet: Diet.Carnivore, isHungry: true, maxTimeUnderWater: 90, jumpingHeight: 2));
            allTheAnimals.Add(new Whale(sex: Sex.Female, name: "Ötis", weight: 43952, diet: Diet.Carnivore, isHungry: true, maxTimeUnderWater: 70, jumpingHeight: 3));
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
            allTheAnimals.Add(new Opossum(sex: Sex.Female, name: "Oprah", weight: 4.2, diet: Diet.Herbivore, isHungry: false, babiesInPouch: new List<IMarsupial>()
                { new Opossum(sex: Sex.Male, name: "Winfrey", weight: 1.3, diet: Diet.Milk, isHungry: false),
                  new Opossum(sex: Sex.Female, name: "Winny", weight: 0.9, diet: Diet.Milk, isHungry: true) }));

            return allTheAnimals;
        }

        static void Main(string[] args)
        {
            var allTheMammals = SetupList();

            /*
             * Pilen ( => ) i linq-metoderna är en så kallad "lambda"
             * Den utför i princip en foreach-loop över listan man använt metoden på
             * där namnet man skriver innan pilen (dvs m i ' m => ')
             * motsvarar variabelnamnet man sätter i en foreach-loop
             */

            // från listan allTheMammals, ta ut elementen där predikatet (dvs. m.Sex == Sex.Male) är true
            var allTheMales = allTheMammals.Where(m => m.Sex == Sex.Male);

            // samma som ovan fast med query-syntax, här behövs ett explicit select-statement till skillnad från i exemplet ovan
            var allTheMales2 = from m in allTheMammals where m.Sex == Sex.Male select m;

            // samma funktionalitet med foreach
            List<Mammal> allTheMales3 = new();
            foreach (var m in allTheMammals)
            {
                if (m.Sex == Sex.Male)
                {
                    allTheMales3.Add(m);
                }
            }

            // från listan allTheMammals, ta ut elementen där predikatet (dvs. m.Sex == Sex.Male && m.Diet == Diet.Herbivore) är true
            var allTheMaleHerbivores = allTheMammals.Where(m => m.Sex == Sex.Male && m.Diet == Diet.Herbivore);

            // från listan allTheMammals, ta ut elementen där predikatet (dvs. m.Sex == Sex.Male || m.Diet == Diet.Herbivore) är true
            var allTheMalesOrHerbivores = allTheMammals.Where(m => m.Sex == Sex.Male || m.Diet == Diet.Herbivore);

            // från listan allTheMammals, ta ut Weight från elementen där predikatet (dvs. m.Sex == Sex.Male) är true
            var allTheMaleWeights = allTheMammals.Where(m => m.Sex == Sex.Male).Select(m => m.Weight);

            // samma som ovan fast med query-syntax, här behövs ett explicit select-statement till skillnad från i exemplet ovan
            var allTheMaleWeights2 = from m in allTheMammals where m.Sex == Sex.Male select m.Weight;

            var sortedByName = allTheMammals.OrderBy(m => m.Name);

            // Tar ut de fem första elementen i listan
            var sortedByNameTakeFirstFive = allTheMammals.OrderBy(m => m.Name).Take(5);

            // Tar ut de fem sista elementen i listan
            var sortedByNameTakeLastFive = allTheMammals.OrderBy(m => m.Name).TakeLast(5);

            // Tar ut allt utom de fem första elementen i listan
            var sortedByNameTakeAllButFirstFive = allTheMammals.OrderBy(m => m.Name).Skip(5);

            // Tar ut det tredje elementet i listan
            var thirdElement = allTheMammals.ElementAt(2);

            // Tar ut det näst sista elementet i listan, '^' betyder att vi räknar från slutet istället för från början
            var secondToLastElement = allTheMammals[^2];

            var malesSortedByName = allTheMammals.Where(m => m.Sex == Sex.Male).OrderBy(m => m.Name);

            // Detta sorterar först eefter namn och sedan inbördes efter vikt och sen efter hunger
            var sortedByNameThenByWeight = allTheMammals.OrderBy(m => m.Name).ThenBy(m => m.Weight).ThenBy(m => m.IsHungry);

            // Detta sorterar enbart efter vikt, då den struntar i ordningen på listan innan
            var sortedByNameByWeight = allTheMammals.OrderBy(m => m.Name).OrderBy(m => m.Weight);

            // Grupperar elementen i listan efter predikatet
            var groupedBySex = allTheMammals.GroupBy(m => m.Sex);

            // Från början av listan, ta alla element tills predikatet inte stämmer längre
            var takeWhileHungry = allTheMammals.TakeWhile(m => m.IsHungry);
            // Denna blir tom då predikatet inte stämmer från början av listan
            var takeWhileNotHungry = allTheMammals.TakeWhile(m => !m.IsHungry);

            // Kollar om predikatet stämmer in på ALLA element i listan
            bool areAllAnimalsHungry = allTheMammals.All(m => m.IsHungry);

            // Kollar om predikatet stämmer in på något element i listan
            bool areAnyAnimalsHungry = allTheMammals.Any(m => m.IsHungry);

            // Summerar vikten av alla element i listan
            double totalWeight = allTheMammals.Sum(m => m.Weight);

            // Snittvikten av alla element i listan
            double averageWeight = allTheMammals.Average(m => m.Weight);

            // Högsta vikten av alla element i listan
            double highestWeight = allTheMammals.Max(m => m.Weight);

            // Lägsta vikten av alla element i listan
            double lowestWeight = allTheMammals.Min(m => m.Weight);

            // Slår ihop alla namn i listan
            var allTheNames = allTheMammals.Aggregate("", (string totalName, Mammal nextMammal) => totalName += nextMammal.Name + " ");

            List<string> list1 = new() { "Ett", "Två", "Tre", "Fyra", "Fem", "Fyra", "Fem" };
            List<string> list2 = new() { "Fyra", "Fem", "Sex", "Sju", "Åtta" };

            // Tar bort dubletter
            var distinctList = list1.Distinct();

            // Tar ut värden ur list1 som INTE finns i list2
            var exceptList = list1.Except(list2);

            // Tar ut värden ur list1 som FINNS i list2
            var intersectList = list1.Intersect(list2);

            // Slår ihop listorna och tar bort dubletter
            var unionList = list1.Union(list2);

            Dictionary<Diet, List<Mammal>> dict = new();
            // Skapar en nyckel 'Diet.Herbivore' som kommer åt värdet i listan av däggdjur som är tilldelad
            dict.Add(Diet.Herbivore, new() { new Kangaroo(sex: Sex.Male, name: "Ru", weight: 36, diet: Diet.Herbivore, isHungry: true, jumpingHeight: 4) });

            Console.WriteLine();
        }
    }
}