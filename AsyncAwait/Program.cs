using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

namespace AsyncAwait
{
    class Program
    {
        private static async Task Main(string[] args)
        {
            var client = new HttpClient();

            // här användar jag inte await, då får vi tillbaka en Task<string>
            // "just nu är jag en Task, men i framtiden när anropet är klart blir jag en sträng"
            var iAmATask = client.GetStringAsync(@"https://coinlib.io/");

            // här användar jag await, då får vi tillbaka en string.
            // "jag väntar här tills vi har fått svar"
            var iAmAString = await client.GetStringAsync(@"https://coinlib.io/");

            // simulera ett tungt arbete i 1000 millisekunder
            await Task.Delay(1000);

            // kör metod i en ny tråd med Task.Run
            await Task.Run(() => HeavyWork());

            // Task.WhenAll används för att vänta tills flera tasks är klara
            var tasks = new List<Task>();
            tasks.Add(HeavyWorkAsync());
            tasks.Add(HeavyWorkAsync());
            tasks.Add(HeavyWorkAsync());
            Console.WriteLine("Waiting for tasks for complete");
            await Task.WhenAll(tasks);
            Console.WriteLine("Tasks completed");
        }

        private static void HeavyWork()
        {
            for (int i = 0; i < 2000000000; i++)
            {
            }
        }

        private static async Task HeavyWorkAsync()
        {
            await Task.Run(() => HeavyWork());
        }

        //static async Task Main(string[] args)
        //{
        //    await MakeTeaAsync();

        //    //try
        //    //{
        //    //    HttpClient client = new HttpClient();
        //    //    Stopwatch stopWatch = new Stopwatch();

        //    //    stopWatch.Start();
        //    //    var coinlib = client.GetStringAsync(@"https://coinlib.io/");
        //    //    var google = client.GetStringAsync(@"https://google.com:81");
        //    //    var github = client.GetStringAsync(@"https://www.github.com/");

        //    //    var allSites = await Task.WhenAll(coinlib, google, github);
        //    //    stopWatch.Stop();
        //    //    Console.WriteLine($"Det tog {stopWatch.ElapsedMilliseconds} ms att hämta informationen");
        //    //}
        //    //catch (Exception)
        //    //{
        //    //    Console.WriteLine("Timeout!");
        //    //}
        //}

        //public async static Task MakeTeaAsync()
        //{
        //    var boilingWater = BoilWaterAsync();

        //    await Task.Delay(10);
        //    Console.WriteLine("3. Ta ut koppar");

        //    Console.WriteLine("4. Lägg tepåsar i kopparna");

        //    await boilingWater;

        //    Console.WriteLine("6. Fyll kopparna med kokande vatten");
        //}

        //public async static Task BoilWaterAsync()
        //{
        //    Console.WriteLine("1. Starta vattenkokaren");

        //    Console.WriteLine("2. Vänta på att vattnet kokar");

        //    await Task.Delay(5000);

        //    Console.WriteLine("5. Vattnet kokar!");
        //}
    }
}