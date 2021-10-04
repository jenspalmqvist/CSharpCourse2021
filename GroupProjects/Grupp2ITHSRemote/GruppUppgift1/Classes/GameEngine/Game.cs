using GruppUppgift1.Classes;
using GruppUppgift1.Classes.Characters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;

namespace GruppUppgift1
{
    public class Game
    {
        public List<Enemy> Enemies { get; set; } = new List<Enemy>();
        private List<Enemy> deadEnemies = new List<Enemy>();
        //private CombatHandler combatHandler;
        private ConsoleKeyInfo key;
        private bool exitLoop = false;
        private static List<Key> keys = new List<Key> { new Key(3, 1, ConsoleColor.Yellow, 4, 4, 17, 13, '|') 
                                                      , new Key(3, 1, ConsoleColor.Blue, 34, 11, 27, 16, '|')
                                                      , new Key(2, 1, ConsoleColor.Red, 14, 5, 55, 5, '_')
                                                      , new Key(2, 1, ConsoleColor.Green, 55, 4, 71, 7, '|')
                                                      , new Key(1, 1, ConsoleColor.Cyan, 54, 13, 77, 13, '_')
                                                      , new Key(0, 1, ConsoleColor.DarkMagenta, 3, 3, 66, 12, '_')
                                                      , new Key(0, 1, ConsoleColor.DarkYellow, 67, 12, 73, 13, '_')
        };

        public InventoryManager InventoryManager { get; set; }
        public MovementManager MovementManager { get; set; }
        public List<Map> Maps { get; set; } = Map.GetMaps();
        public Player Player { get; set; } = new Player();
        public int CurrentMap { get; set; } = 0;
        public int nrOfItemsPerMap { get; set; } = 5;

        private MapLoot loot = new MapLoot();

        public void InitGame()
        {
            SpawnEnemies(6, Player);
            InventoryManager = new InventoryManager(this);
            MovementManager = new MovementManager(this);
            loot.Spawn(Maps, CurrentMap, nrOfItemsPerMap);
        }

        public void UpdateGameField()
        {
            if (Player.CurrentHealth <= 0 || Player.McGuffinCounter == Maps.Count)
            {
                exitLoop = true;
              
                if (Player.CurrentHealth <= 0) 
                {
                  Console.ReadKey(true);
                  GameOver();
                }
              
                else 
                {
                  Console.ReadKey(true);
                  Win();
                }
              
                while (true)
                {
                    var input = Console.ReadKey(true).Key;
                    if (input == ConsoleKey.Spacebar)
                        return;
                }
            }
            Maps[CurrentMap].UpdateVisible(Player.PositionX, Player.PositionY);
            Maps[CurrentMap].Draw();
            loot.Run(Player, Maps[CurrentMap]);
            deadEnemies.ForEach(e => e.Draw(Maps[CurrentMap]));
            Maps[CurrentMap].DrawMcGuffin();
            Enemies.ForEach(e => e.Draw(Maps[CurrentMap]));
            UpdateKeys();
            Player.DrawPlayerCharacter();
        }

        private void GameOver()
        {
            Console.Clear();
            Console.CursorVisible = false;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(@"                                                                          
                  @@@@@@@@     @@@@@@@@     @@@     @@@   @@@@@@@@   
                 @@@@@@@@@    @@@@@@@@@@   @@@@@   @@@@@  @@@@@@@@   
                 !@@          @@!    !@@   @@!@@!@!@@@!@  @@!        
                 !@!          !@!    @!@   !@!  !@!  @@!  !@!        
                 !@! @!@!@    !!@!@!@!@!   @!@       !@!  @!!!:!     
                 !!! !!@!!    !@!!!@!@!!   !@!       !!!  !!!!!:     
                 :!!   !!:    !!:    !!!   !!:       !!!  !!:        
                 :!:   !::    :!:    !:!   :!:       !:!  :!:        
                  ::: ::::    :::    :::   :::       :::   :: ::::   
                  :: :: :      :      :     :         :   : :: ::    
                                                                                     
                   @@@@@@    @@@       @@@   @@@@@@@@   @@@@@@@
                  @@@@@@@@   @@@       @@@   @@@@@@@@   @@@@@@@@@
                  @@!  @@@   @@!       @@!   @@!        @@!    !@@
                  !@!  @!@   !@!       !@!   !@!        !@!    @!@
                  @!@  !@!   !!@       !!@   @!!!:!     !!@!@!@!@
                  !@!  !!!   !!!       !!!   !!!!!:     !@!!!@!@!
                  !!:  !!!    !!:     !!:    !!:        !!:    !!!
                  :!:  !:!     !!:   :!:     :!:        :!:    !:!
                  ::::: ::      ::: :::       :: ::::   :::    :::
                   : :  :        : :::       : :: ::     :      :                                  
                              
                 


                         Press space to continue...");
        }
        private void Win()
        {
            Console.Clear();
            Console.CursorVisible = false;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(@"
                            @@@  @@@  @@@  @@@  @@@  @@@  
                            @@@  @@@  @@@  @@@  @@@@ @@@  
                            @@!  @@!  @@!  @@!  @@!@!@@@  
                            !@!  !@!  !@!  !@!  !@!!@!@!  
                            @!!  !!@  @!@  !!@  @!@ !!@!  
                            !@!  !!!  !@!  !!!  !@!  !!!  
                            !!:  !!:  !!:  !!:  !!:  !!!  
                            :!:  :!:  :!:  :!:  :!:  !:!  
                             :::: :: :::    ::   ::   ::  
                              :: :  : :    :    ::    :   




                             Press space to continue...");

        }

        public void Loop()
        {
            Player.PositionX = Maps[CurrentMap].StartPosition.Item1;
            Player.PositionY = Maps[CurrentMap].StartPosition.Item2;
            UpdateGameField();
            UpdateUI();
            while (!exitLoop)
            {
                if (Console.KeyAvailable)
                {
                    CombatHandler.ResetCombatHandler();
                    key = Console.ReadKey(true);
                    KeyboardHandler(key);
                    if (!exitLoop)
                    {
                        UpdateUI();
                    }
                }
            }
        }

        public void UpdateKeys()
        {
            for (int i = 0; i < keys.Count; i++)
            {
                if (keys[i].Map == CurrentMap)
                {
                    keys[i].Draw(Maps[CurrentMap], Player);
                }
            }
        }

        private void UpdateUI()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(Maps[CurrentMap].map[0].Length - 9, Maps[CurrentMap].map.Length);
            Console.Write($"Floor: {CurrentMap}".PadLeft(9));
            Console.SetCursorPosition(Maps[CurrentMap].map[0].Length - 16, Maps[CurrentMap].map.Length + 1);
            Console.Write($"McGuffins: {Player.McGuffinCounter}/{Maps.Count}".PadLeft(16));
            Console.SetCursorPosition(0, Maps[CurrentMap].map.Length);
            Console.WriteLine($"HP: {Player.CurrentHealth}/{Player.MaxHealth}".PadRight(9));
            Console.WriteLine($"Inventory: {Player.Inventory.SatchelSlotsCurrentlyOccupied}/{Player.Inventory.SatchelSize}");
            Console.WriteLine($"Player Total Damage: {Player.Damage}");
            Console.WriteLine($"Player Total Defense: {Player.Defense}");
            Console.WriteLine($"Weapon: {Player.EquipedWeapon}");
            Console.WriteLine($"Shield: {Player.EquipedShield}");
        }

        public void ChangeMap(int mapNumber)
        {
            if (mapNumber == 1)
            {
                CurrentMap += 1;
                Player.PositionX = Maps[CurrentMap].StartPositionDown.Item1;
                Player.PositionY = Maps[CurrentMap].StartPositionDown.Item2;
            }
            if (mapNumber == -1)
            {
                CurrentMap -= 1;
                Player.PositionX = Maps[CurrentMap].StartPositionUp.Item1;
                Player.PositionY = Maps[CurrentMap].StartPositionUp.Item2;
            }
            deadEnemies.Clear();
            InitGame();
            UpdateGameField();
        }

        public void KeyboardHandler(ConsoleKeyInfo key)
        {
            switch (key.Key)
            {
                case ConsoleKey.LeftArrow:
                case ConsoleKey.A:
                    MovementManager.CheckMovement(-1, 0);
                    break;
                case ConsoleKey.RightArrow:
                case ConsoleKey.D:
                    MovementManager.CheckMovement(1, 0);
                    break;
                case ConsoleKey.UpArrow:
                case ConsoleKey.W:
                    MovementManager.CheckMovement(0, -1);
                    break;
                case ConsoleKey.DownArrow:
                case ConsoleKey.S:
                    MovementManager.CheckMovement(0, 1);
                    break;
                case ConsoleKey.I: // öppna inventory
                    InventoryManager.OpenInventory(Player);
                    break;
                case ConsoleKey.C:
                    InventoryManager.EquipmentMenu(Player);
                    break;
                case ConsoleKey.F1:
                    HelpMenu();
                    break;
                case ConsoleKey.Enter: // Vänta en turn
                    Enemies.ForEach(enemy => MovementManager.MoveEnemy(Maps[CurrentMap], enemy));
                    UpdateGameField();
                    break;
                case ConsoleKey.H: // Debug
                    Dialog d = new Dialog(Player.PositionX, Player.PositionY, $"X: {Player.PositionX}, Y: {Player.PositionY}", ConsoleColor.Red, false, Maps[CurrentMap]);
                    d.Print();
                    break;
                case ConsoleKey.Spacebar:
                    if (Maps[CurrentMap].map[Player.PositionY][Player.PositionX] == 'D')
                    {
                        ChangeMap(1);
                    }
                    else if (Maps[CurrentMap].map[Player.PositionY][Player.PositionX] == 'U')
                    {
                        ChangeMap(-1);
                    }
                    //else
                    //{
                    //    var killedEnemy = Player.AttackInstantKill(Enemies, Player); // Instant-döda fiender vid spelaren.

                    //    if (killedEnemy != null)
                    //        killedEnemy.Die();

                    //    UpdateGameField();
                    //}
                    break;
                case ConsoleKey.Escape:
                    exitLoop = true;
                    break;
            }
        }

        public void HelpMenu()
        {
            ConsoleKey input;

            do
            {
                Console.Clear();
                Console.WriteLine(@"



                                    --- Help ---
                           F1 - Help menu


                                    --- Interaction ---
                           WASD/ Arrow keys - Movement
                           Combat - Move toward enemy to attack
                           I - Inventory menu
                           C - Equipment menu
                           Space - Move (U)p/(D)own
                           Esc - Exit game


                                    --- Map ledger ---
                           Enemies - g, %, Ö, K
                           Ground loot - $
                           Keys - £
                           McGuffin - ¤ (Collect them all to win!)

                                            Press Enter to continue...");
                
                input = Console.ReadKey(true).Key;

            } while (input != ConsoleKey.Enter);
            Console.Clear();
        }

        public void SpawnEnemies(int numberOfEnemies, Player player)
        {
            Random random = new Random();
            int x, y;
            Enemies.Clear();
            for (int i = 0; i < numberOfEnemies; i++)
            {
                do
                {
                    x = random.Next(0, Maps[CurrentMap].map[0].Length);
                    y = random.Next(0, Maps[CurrentMap].map.Length);

                } while (Maps[CurrentMap].map[y][x] != ' ' && !Enemies.Exists(e => e.PositionX == x && e.PositionY == y));

                int spawnType = random.Next(1, 21);
                if(spawnType >= 1 && spawnType <= 11)
                {
                    Enemies.Add(new Goblin(x, y, player, Enemies, deadEnemies));
                }
                else if (spawnType > 11 && spawnType <= 17)
                {
                    Enemies.Add(new Skeleton(x, y, player, Enemies, deadEnemies));
                }
                else if (spawnType > 18 && spawnType <= 19)
                {
                    Enemies.Add(new BlindKnight(x, y, player, Enemies, deadEnemies));
                }
                else if (spawnType == 20)
                {
                    Enemies.Add(new Troll(x, y, player, Enemies, deadEnemies));
                }

            }
        }
    }
}
