using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    /// <summary>
    /// Builds the static map, builds and updates dynamic map after every turn
    /// </summary>
    internal class DungeonMap
    {
        public int MapWidth { get; set; }
        public int MapHeight { get; set; }

        public MapTile[,] staticMap; // Walls, floors.
        public IRepresentable[,] dynamicMap; // Stuff that move or change, player, monsters, items, etc.

        /// <summary>
        /// Places objects that implement the IRepresentable interface on dynamic map
        /// </summary>
        public bool PlaceDynamic(int x, int y, IRepresentable representable)
        {
            if (IsInBounds(x, y) && dynamicMap[x, y] == null)
            {
                dynamicMap[x, y] = representable;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Retrieves the IRepresentable object located on DynamicMap given coordinate x, y
        /// </summary>
        public IRepresentable GetDynamic(int x, int y)
        {
            if (!IsInBounds(x, y))
                return null;

            return dynamicMap[x, y];
        }

        /// <summary>
        /// Removes object from DynamicMap
        /// </summary>
        public bool RemoveDynamic(int x, int y)
        {
            if (!IsInBounds(x, y))
                return false;

            if (dynamicMap[x, y] == null)
                return false;

            dynamicMap[x, y] = null;
            return true;
        }

        public DungeonMap(int mapWidth, int mapHeight)
        {
            MapWidth = mapWidth;
            MapHeight = mapHeight;

            staticMap = new MapTile[MapWidth, MapHeight];
            dynamicMap = new IRepresentable[MapWidth, MapHeight];

            DefaultMap();
        }

        /// <summary>
        /// Draws the map to the console
        /// </summary>
        public void DrawMap()
        {
            Console.SetCursorPosition(0, 0);
            Console.Write(GetRepresentation());
        }

        /// <summary>
        /// Gets a string representation of dynamicMap and staticMap together
        /// </summary>
        public string GetRepresentation()
        {
            StringBuilder sb = new StringBuilder();

            for (int j = 0; j < MapHeight; j++)
            {
                for (int i = 0; i < MapWidth; i++)
                {
                    if (dynamicMap[i, j] != null)
                    {
                        sb.Append(dynamicMap[i, j].Representation);
                    }
                    else
                    {
                        sb.Append(staticMap[i, j].Representation);
                    }
                }
                sb.Append('\n');
            }
            return sb.ToString();
        }

        /// <summary>
        /// Takes a position and target coordinates for a move. Returns target coordinates if move is valid
        /// </summary>
        public (int x, int y) Move(int fromX, int fromY, int toX, int toY)
        {
            if (!IsInBounds(fromX, fromY) ||
                !IsInBounds(toX, toY) ||
                dynamicMap[fromX, fromY] == null ||
                dynamicMap[toX, toY] != null ||
                !staticMap[toX, toY].Walkable
                ) return (-1, -1);

            dynamicMap[toX, toY] = dynamicMap[fromX, fromY];
            dynamicMap[toX, toY].PositionX = toX; // Tell the object its new position.
            dynamicMap[toX, toY].PositionY = toY;

            dynamicMap[fromX, fromY] = null;

            return (toX, toY);
        }
        /// <summary>
        /// Takes a position and direction. Returns target coordinates if move is valid
        /// </summary>
        public (int x, int y) Move(int fromX, int fromY, char direction)
        {
            var target = GetMoveTargetCoordinates(fromX, fromY, direction);

            return Move(fromX, fromY, target.x, target.y);
        }

        /// <summary>
        /// Controls for the main character.
        /// </summary>
        public (int x, int y) GetMoveTargetCoordinates(int fromX, int fromY, char direction)
        {
            // up, down, left, right
            int toX = fromX;
            int toY = fromY;
            switch (direction)
            {
                case 'w':
                    toX = fromX;
                    toY = fromY - 1;
                    break;

                case 's':
                    toX = fromX;
                    toY = fromY + 1;
                    break;

                case 'a':
                    toX = fromX - 1;
                    toY = fromY;
                    break;

                case 'd':
                    toX = fromX + 1;
                    toY = fromY;
                    break;

                default:
                    return (fromX, fromY);
            }
            return (toX, toY);
        }

        /// <summary>
        /// Check if the Characters can move.
        /// </summary>
        public bool CanMoveTo(int x, int y)
        {
            return IsInBounds(x, y) && staticMap[x, y].Walkable && dynamicMap[x, y] == null;
        }

        public void DefaultMap()
        {
            BuildStaticRect(0, 0, MapWidth, MapHeight, new MapTile("wall"), new MapTile("wall"));
            BuildStaticRect(0, 0, MapWidth, MapHeight, new MapTile("wall"), new MapTile("floor"));
            // Utanför kammaren

            // Uppe
            BuildStaticRect(1, 3, 3, 1, new MapTile("wall"), new MapTile("wall"));
            BuildStaticRect(3, 2, 3, 1, new MapTile("wall"), new MapTile("wall"));
            BuildStaticRect(5, 7, 3, 1, new MapTile("wall"), new MapTile("wall"));
            BuildStaticRect(3, 6, 3, 1, new MapTile("wall"), new MapTile("wall"));
            BuildStaticRect(1, 11, 3, 1, new MapTile("wall"), new MapTile("wall"));
            BuildStaticRect(3, 10, 3, 1, new MapTile("wall"), new MapTile("wall"));
            BuildStaticRect(5, 15, 3, 1, new MapTile("wall"), new MapTile("wall"));
            BuildStaticRect(3, 14, 3, 1, new MapTile("wall"), new MapTile("wall"));
            BuildStaticRect(1, 19, 3, 1, new MapTile("wall"), new MapTile("wall"));
            BuildStaticRect(3, 18, 3, 1, new MapTile("wall"), new MapTile("wall"));

            // mitten
            BuildStaticRect(1, 23, 5, 1, new MapTile("wall"), new MapTile("wall"));

            // Nere
            BuildStaticRect(1, 27, 3, 1, new MapTile("wall"), new MapTile("wall"));
            BuildStaticRect(3, 28, 3, 1, new MapTile("wall"), new MapTile("wall"));
            BuildStaticRect(5, 31, 3, 1, new MapTile("wall"), new MapTile("wall"));
            BuildStaticRect(3, 32, 3, 1, new MapTile("wall"), new MapTile("wall"));
            BuildStaticRect(1, 35, 3, 1, new MapTile("wall"), new MapTile("wall"));
            BuildStaticRect(3, 36, 3, 1, new MapTile("wall"), new MapTile("wall"));
            BuildStaticRect(5, 39, 3, 1, new MapTile("wall"), new MapTile("wall"));
            BuildStaticRect(3, 40, 3, 1, new MapTile("wall"), new MapTile("wall"));
            BuildStaticRect(1, 43, 3, 1, new MapTile("wall"), new MapTile("wall"));
            BuildStaticRect(3, 44, 3, 1, new MapTile("wall"), new MapTile("wall"));

            // Ingången / Mitten
            BuildStaticRect(8, 24, 2, 21, new MapTile("wall"), new MapTile("wall"));
            BuildStaticRect(8, 1, 2, 22, new MapTile("wall"), new MapTile("wall"));
            BuildStaticRect(10, 21, 15, 2, new MapTile("wall"), new MapTile("wall"));
            BuildStaticRect(9, 24, 5, 2, new MapTile("wall"), new MapTile("wall"));

            //
            // Inne i kammaren
            //

            // Uppe
            BuildStaticRect(18, 11, 2, 11, new MapTile("wall"), new MapTile("wall"));
            BuildStaticRect(18, 10, 20, 2, new MapTile("wall"), new MapTile("wall"));
            BuildStaticRect(24, 14, 30, 2, new MapTile("wall"), new MapTile("wall"));
            BuildStaticRect(41, 6, 2, 10, new MapTile("wall"), new MapTile("wall"));
            BuildStaticRect(13, 6, 29, 2, new MapTile("wall"), new MapTile("wall"));
            BuildStaticRect(29, 21, 55, 2, new MapTile("wall"), new MapTile("wall"));
            BuildStaticRect(88, 21, 12, 2, new MapTile("wall"), new MapTile("wall"));
            BuildStaticRect(65, 5, 35, 2, new MapTile("wall"), new MapTile("wall"));
            BuildStaticRect(42, 9, 53, 2, new MapTile("wall"), new MapTile("wall"));
            BuildStaticRect(65, 13, 35, 2, new MapTile("wall"), new MapTile("wall"));
            BuildStaticRect(60, 17, 35, 2, new MapTile("wall"), new MapTile("wall"));
            BuildStaticRect(58, 3, 2, 18, new MapTile("wall"), new MapTile("wall"));
            BuildStaticRect(18, 2, 42, 2, new MapTile("wall"), new MapTile("wall"));

            // Hinder uppe
            BuildStaticRect(13, 18, 3, 1, new MapTile("wall"), new MapTile("wall"));
            BuildStaticRect(15, 17, 3, 1, new MapTile("wall"), new MapTile("wall"));
            BuildStaticRect(12, 14, 3, 1, new MapTile("wall"), new MapTile("wall"));
            BuildStaticRect(10, 13, 3, 1, new MapTile("wall"), new MapTile("wall"));

            // Nere
            BuildStaticRect(13, 24, 2, 15, new MapTile("wall"), new MapTile("wall"));
            BuildStaticRect(15, 31, 20, 2, new MapTile("wall"), new MapTile("wall"));
            BuildStaticRect(19, 24, 2, 6, new MapTile("wall"), new MapTile("wall"));
            BuildStaticRect(21, 24, 40, 2, new MapTile("wall"), new MapTile("wall"));
            BuildStaticRect(66, 24, 33, 2, new MapTile("wall"), new MapTile("wall"));
            BuildStaticRect(13, 40, 40, 2, new MapTile("wall"), new MapTile("wall"));
            BuildStaticRect(57, 40, 42, 2, new MapTile("wall"), new MapTile("wall"));
            BuildStaticRect(19, 28, 20, 2, new MapTile("wall"), new MapTile("wall"));
            BuildStaticRect(39, 28, 2, 12, new MapTile("wall"), new MapTile("wall"));
            BuildStaticRect(49, 28, 2, 12, new MapTile("wall"), new MapTile("wall"));
            BuildStaticRect(59, 26, 2, 14, new MapTile("wall"), new MapTile("wall"));

            // Hinder nere
            BuildStaticRect(41, 36, 3, 1, new MapTile("wall"), new MapTile("wall"));
            BuildStaticRect(43, 37, 3, 1, new MapTile("wall"), new MapTile("wall"));
            BuildStaticRect(46, 32, 3, 1, new MapTile("wall"), new MapTile("wall"));
            BuildStaticRect(44, 33, 3, 1, new MapTile("wall"), new MapTile("wall"));
            BuildStaticRect(56, 35, 3, 1, new MapTile("wall"), new MapTile("wall"));
            BuildStaticRect(54, 36, 3, 1, new MapTile("wall"), new MapTile("wall"));
            BuildStaticRect(51, 29, 3, 1, new MapTile("wall"), new MapTile("wall"));
            BuildStaticRect(53, 30, 3, 1, new MapTile("wall"), new MapTile("wall"));
            BuildStaticRect(65, 32, 30, 2, new MapTile("wall"), new MapTile("wall"));
            BuildStaticRect(79, 26, 3, 13, new MapTile("wall"), new MapTile("wall"));

            // Under kammaren
            BuildStaticRect(9, 43, 80, 2, new MapTile("wall"), new MapTile("wall"));
            BuildStaticRect(89, 43, 2, 3, new MapTile("wall"), new MapTile("wall"));
        }

        /// <summary>
        /// Check if coordinates are in bounds of the map
        /// </summary>
        public bool IsInBounds(int x, int y)
        {
            return x >= 0 && x < MapWidth && y >= 0 && y < MapHeight;
        }

        /// <summary>
        /// Build the edge boundary of static map
        /// </summary>
        public bool BuildStaticRect(int x, int y, int width, int height, MapTile borderTile, MapTile fillTile)
        {
            // Are we outside the bounds of the map?
            // If so, return false.
            if (!IsInBounds(x, y) || !IsInBounds(x + width - 1, y + height - 1))
                return false;
            // Else, place tiles in staticMap.
            for (int j = 0; j < height; j++)
            {
                for (int i = 0; i < width; i++)
                {
                    if (j == 0 || j == height - 1 || i == 0 || i == width - 1)
                    {
                        // Place border tile.
                        staticMap[x + i, y + j] = (MapTile)borderTile.Clone();
                    }
                    else
                    {
                        // Place fill tile.
                        staticMap[x + i, y + j] = (MapTile)fillTile.Clone();
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// Update characters position on map for next turn
        /// </summary>
        public void NextTurn(ConsoleKeyInfo input)
        {
            var characters = new List<Character>();
            for (int j = 0; j < MapHeight; j++)
            {
                for (int i = 0; i < MapWidth; i++)
                {
                    var obj = dynamicMap[i, j];
                    if (obj == null)
                        continue;

                    if (obj is Character && input.Key is ConsoleKey.A or ConsoleKey.W or ConsoleKey.S or ConsoleKey.D)
                        characters.Add((Character)obj);
                }
            }

            foreach (var c in characters)
            {
                c.NextAction();
            }
        }
    }
}