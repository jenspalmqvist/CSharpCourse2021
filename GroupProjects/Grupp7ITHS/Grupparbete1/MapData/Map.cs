using Grupparbete1.GameObjects;
using Grupparbete1.Tiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Grupparbete1.MapData
{
    /// <summary>
    /// Innehåller all information om spelkartan, och rendererar den bild som visas för spelaren.
    /// </summary>
    public class Map
    {
        // Själva spelkartan i form av Tiles, där varje Tile innehåller information om den går att gå på eller inte, och vilket tecken som representerar den rutan.
        public TileBase[][] TileGrid { get; private set; }

        public List<Room> Rooms { get; private set; }

        // Alla spelobjekt som existerar på planen, dvs spelaren, alla fiender och items.
        public List<GameObject> GameObjects { get; set; }

        // Det objekt som kontrolleras av spelaren.
        public Player Player { get; set; }

        public RiddleTablet CurrentRiddleTablet { get; set; }

        public Room CurrentRoom { get => Rooms.Where(r => r.Area.Contains(new Point(Player.X, Player.Y))).FirstOrDefault(); }
        public int Width { get; }
        public int Height { get; }

        // Används för att slumpa fram koordinater för nya spelobjekt.
        private readonly Random _rng;

        public Map(int width, int height)
        {
            Width = width;
            Height = height;

            _rng = new Random();

            TileGrid = new TileBase[width][];
            GameObjects = new List<GameObject>();

            Rooms = new List<Room>();

            for (int x = 0; x < width; x++)
            {
                TileGrid[x] = new TileBase[height];
            }
        }

        // Genererar en ny spelkarta när spelet startas, och lägger till spelare och fiender.
        public void Init()
        {
            CreateRiddleTablets();
            Player = CreatePlayer("Player");
            GameObjects.Add(Player);

            DrawMap();
        }

        /// <summary>
        /// Används för att kolla om det finns ett GameObject av en viss typ på de angivna koordinater.
        /// Används bland annat när spelaren flyttas, för att kolla om det finns en fiende att attackera på den Tile som spelaren försöker gå till.
        /// </summary>
        /// <typeparam name="T">Den typ av GameObject som eftersöks.</typeparam>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public T GetEntityAtLoc<T>(int x, int y) where T : GameObject
        {
            return GameObjects.Where(e => e.X == x && e.Y == y && e is T).FirstOrDefault() as T;
        }

        public List<T> GetAllEntitiesAtLoc<T>(Coord location) where T : GameObject
        {
            return GameObjects.Where(e => e.X == location.X && e.Y == location.Y && e is T).ToList() as List<T>;
        }

        /// <summary>
        /// Slumpar fram koordinater tills en Tile som går att gå på slumpas fram, och skapar spelaren på den rutan.
        /// </summary>
        /// <param name="name">Namnet på spelaren som ska skapas.</param>
        /// <returns></returns>
        private Player CreatePlayer(string name)
        {
            int tempX;
            int tempY;

            do
            {
                tempX = _rng.Next(Rooms[0].Area.Left, Rooms[0].Area.Right);
                tempY = _rng.Next(Rooms[0].Area.Top, Rooms[0].Area.Bottom);
            } while (!TileGrid[tempX][tempY].IsWalkable);

            return new Player(tempX, tempY, name);
        }

        /// <summary>
        /// Skapar ett antal fiender på slumpade koordinater i varje rum. Det högsta antalet fiender som kan skapas per rum ökar vart annat rum.
        /// </summary>
        /// <param name="countLowerBound">Det lägsta antalet fiender som kan slumpas fram i ett givet rum.</param>
        /// /// <param name="countUpperBound">Det högsta antalet fiender som kan slumpas fram i ett givet rum.</param>
        private void CreateEnemies(int countLowerBound, int countUpperBound)
        {
            int count;
            int tempX;
            int tempY;

            for (int i = 0; i < Rooms.Count; i++)
            {
                countUpperBound += i % 2 != 0 ? 1 : 0;

                count = _rng.Next(countLowerBound, countUpperBound + 1);

                for (int j = 0; j < count; j++)
                {
                    do
                    {
                        tempX = _rng.Next(Rooms[i].Area.Left, Rooms[i].Area.Right);
                        tempY = _rng.Next(Rooms[i].Area.Top, Rooms[i].Area.Bottom);
                    } while (!TileGrid[tempX][tempY].IsWalkable);

                    GameObjects.Add(new Enemy(tempX, tempY, "Enemy"));
                }
            }
        }

        private void CreateRiddleTablets()
        {
            int tempX;
            int tempY;
            var riddles = Riddle.Generate();

            for (int i = 0; i < Rooms.Count; i++)
            {
                do
                {
                    tempX = _rng.Next(Rooms[i].Area.Left, Rooms[i].Area.Right);
                    tempY = _rng.Next(Rooms[i].Area.Top, Rooms[i].Area.Bottom);
                } while (!TileGrid[tempX][tempY].IsWalkable);

                if (riddles.Count > 0)
                {
                    var riddleIndex = riddles.Count <= 0 ? 0 : _rng.Next(riddles.Count);

                    Rooms[i].Tablet = new RiddleTablet(tempX, tempY, riddles[riddleIndex]);
                    riddles.RemoveAt(riddleIndex);

                    GameObjects.Add(Rooms[i].Tablet);
                }
            }
        }

        /// <summary>
        /// Kollar om de angivna koordinaterna existerar på spelbrädet. Returnererar true om det existerar, och false om det inte existerar.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public bool IsWithinBounds(int x, int y)
        {
            return (x >= 0 && x < Width && y >= 0 && y < Height);
        }

        public bool IsWithinBounds(Coord location)
        {
            return (location.X >= 0 && location.X < Width && location.Y >= 0 && location.Y < Height);
        }

        /// <summary>
        /// Ritar kartan på skärmen.
        /// </summary>
        public void DrawMap()
        {
            // Används för att konstruera en stärng för varje rad som ska renderas.
            var sb = new StringBuilder();

            // Itererar över varje ruta i varje rad.
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    // Kollar om det finns något GameObject med koordinaterna på rutan som ska renderas.
                    var gameObjectAtLoc = GetEntityAtLoc<GameObject>(x, y);

                    // Om det finns ett GameObject på koordinaterna så läggs objektets tecken till i StringBuildern. Om inte, så läggs tecknet för den rutan till.
                    sb.Append(gameObjectAtLoc is null ? TileGrid[x][y].Icon : gameObjectAtLoc.Icon);
                }

                // Flyttar pekaren till den rad som ska skrivas ut.
                Console.SetCursorPosition(0, y);

                // Skriver ut strängen som konstruerats för att representera raden.
                Console.Write(sb.ToString());

                // Återställer StringBuildern så att den kan användas igen för nästa rad.
                sb.Clear();
            }
        }

        /// <summary>
        /// Uppdaterar kartan när en Actors position ändras, så att det som visas för spelaren stämmer överrens med Actorns nya position.
        /// </summary>
        /// <param name="actor"></param>
        /// <param name="lastLocation">Actorns förra position. Används för att uppdatera rutan med dess förra koordinater.</param>
        public void UpdateAfterActorMove(Actor actor, Coord lastLocation)
        {
            if (GameObjects.Contains(actor))
            {
                var gameObjectAtLoc = GetEntityAtLoc<GameObject>(lastLocation.X, lastLocation.Y);

                Console.SetCursorPosition(lastLocation.X, lastLocation.Y);
                Console.Write(gameObjectAtLoc is null ? TileGrid[lastLocation.X][lastLocation.Y].Icon : gameObjectAtLoc.Icon);
                Console.SetCursorPosition(actor.X, actor.Y);
                Console.Write(actor.Health > 0 ? actor.Icon : TileGrid[actor.X][actor.Y].Icon);
            }
        }
    }
}