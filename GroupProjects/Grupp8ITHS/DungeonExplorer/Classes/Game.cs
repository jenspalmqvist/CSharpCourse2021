using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace DungeonExplorer
{
    public class Game
    {
        public static List<Item> ItemList { get; set; }
        public static List<NPC> NPCList { get; set; }
        public static NPC npc { get; set; }
        public static Player player { get; set; }
        public static bool[] GameInProgress { get; set; }
        public Game()
        {
            Console.SetWindowSize(120, 40);
            GameInProgress = new bool[2];
            GameInProgress[0] = true;
            GameInProgress[1] = false;

            new UI();
            InitiateGame();
            while (GameInProgress[0])
            {
                Move.MovePlayer();
                UI.RefreshMap();
            }
            if (GameInProgress[1])
            {
                Console.Clear();
                UI.DisplayMap(Map.YouWin);
            }
            else
            {
                Console.Clear();
                UI.DisplayMap(Map.GameOver);
            }
        }
        private static void InitiateGame()
        {
            GenerateItemList();
            GenerateNPCList();
            new Move();
            new Map();
            npc = new NPC();
            player = new Player(CreatePlayer());
            Console.Clear();
            DisplayGameLore();
            DisplayWelcomeMessage(player.Name);
            DisplayGameInstructions();
            UI.RefreshMap();
        }
        private static void GenerateItemList()
        {
            ItemList = new List<Item>();
            Item fruit = new Fruit { HealthIncrease = 10, HungerIncrease = 20, Name = "Fruit" };
            Item berry = new Berry { HealthIncrease = 5, HungerIncrease = 10, Name = "Berry" };
            Item sword = new Sword { Damage = 10, Name = "Sword" };
            Item stone = new Stone { Damage = 3, Name = "Stone" };
            Item pickAxe = new PickAxe { Damage = 7, Name = "PickAxe" };
            Item woodenStick = new WoodenStick { Damage = 4, Name = "WoodenStick" };
            ItemList.Add(fruit);
            ItemList.Add(sword);
            ItemList.Add(stone);
            ItemList.Add(berry);
            ItemList.Add(pickAxe);
            ItemList.Add(woodenStick);
        }
        private static void GenerateNPCList()
        {
            NPCList = new List<NPC>();
            NPC rat = new NPC { Name = "Rat", Health = 20, Damage = 1 };
            NPC caveTroll = new NPC { Name = "Cavetroll", Health = 50, Damage = 5 };
            NPC strayDog = new NPC { Name = "Straydog", Health = 40, Damage = 3 };
            NPCList.Add(rat);
            NPCList.Add(caveTroll);
            NPCList.Add(strayDog);
        }
        private static string CreatePlayer()
        {
            Console.Write("Enter name: ");
            return Console.ReadLine();
        }
        private static void DisplayWelcomeMessage(string name)
        {
            string welcomeMessage = $"Welcome to Dungeon Explorer {name}, try to find your way out of the dungeon without dying!";
            Console.WriteLine($"{welcomeMessage}");
        }
        private static void DisplayGameInstructions()
        {
            Console.WriteLine(UI.InterfaceInstructions);
            Console.WriteLine("Press any key to start the game!");
            Console.ReadKey();
        }
        private static void DisplayGameLore()
        {
            Console.WriteLine("The year is 2042 and the world has become a dystopian place just over the past few decades.");
            Console.WriteLine("In order to survive, humanity - or what's left of it - have sought refuge high above sea level,\nin order to escape the heinous creatures roaming below.");
            Console.WriteLine("\nHowever, due to elevation, the earth is not fertile enough to allow for agriculture...");
            Console.WriteLine("This has led to people scavenging the earth for remains, hunting animals for food and crops,\nwhilst being cautious of the dangers lurking around.");
            Console.WriteLine("\n\nOne day, out on one of these adventures, you catch a glimpse of something shiny.");
            Console.WriteLine("Your curiousness gets the best of you and you find yourself diverting from the group,\nin pursuit of whatever treasure lies ahead.");
            Console.WriteLine("\nJust as you are about to pick up the item, a shiny thing not resembling anything you've seen before,\nthe ground collapses beneath you.");
            Console.WriteLine("\nYou wake up, unsure if it's been minutes, hours, or even days that have passed since you lost consciousness.");
            Console.WriteLine("You brush the dirt off of your clothes and look around - you find yourself in a very dark space, lost and alone...");
            Console.WriteLine("\n\n----- Press any key to continue -----");
            Console.ReadKey();
            Console.Clear();
        }
        public static void DisplayInventory()
        {
            Console.WriteLine("Placeholder for listing inventory.");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}