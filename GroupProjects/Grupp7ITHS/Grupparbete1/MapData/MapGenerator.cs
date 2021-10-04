 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grupparbete1.Tiles;
using System.Drawing;

namespace Grupparbete1.MapData
{
    public class MapGenerator
    {
        private Map _map;
        private readonly int _roomCountMax;
        private readonly int _roomSizeMin;
        private readonly int _roomSizeMax;
        private Random _rng;

        public MapGenerator(Map map, int roomCountMax, int roomSizeMin, int roomSizeMax)
        {
            _map = map;
            _roomCountMax = roomCountMax;
            _roomSizeMin = roomSizeMin;
            _roomSizeMax = roomSizeMax;
            _rng = new Random();
        }

        private void GenerateRooms()
        {
            // Första rummet genereras alltid längst till vänster, i mitten.
            Size nextRoomSize = new Size(_rng.Next(_roomSizeMin, _roomSizeMax), _rng.Next(_roomSizeMin, _roomSizeMax));
            var nextRoomPos = new Coord(1, (_map.Height / 2) - (nextRoomSize.Height / 2));
            _map.Rooms.Add(new Room(nextRoomPos, nextRoomSize));

            int roomPosLowerBoundX;
            int roomPosUpperBoundY;

            for(int i = 1; i < _roomCountMax; i++)
            {
                // Ser till att det alltid är minst 3 rutors mellanrum mellan rummen.
                roomPosLowerBoundX = _map.Rooms[i - 1].Area.Right + 3;

                // Slumpar fram dimensionerna på nästa rum.
                nextRoomSize = new Size(_rng.Next(_roomSizeMin, _roomSizeMax), _rng.Next(_roomSizeMin, _roomSizeMax));

                // Ser till att rummet hålls innanför spelkartans dimensioner.
                roomPosUpperBoundY = _map.Height - nextRoomSize.Height - 1; 

                nextRoomPos = new Coord(_rng.Next(roomPosLowerBoundX, roomPosLowerBoundX + 5), _rng.Next(1, roomPosUpperBoundY));

                // Om det inte finns någon plats att generera nästa rum så bryts loopen.
                if(nextRoomPos.X + nextRoomSize.Width > _map.Width)
                {
                    break;
                }

                _map.Rooms.Add(new Room(nextRoomPos, nextRoomSize));
            }
        }

        public Map Generate()
        {
            FillWithTileOfType<TileWall>();
            GenerateRooms();
            CreateRoomTiles();

            for (int i = 0; i < _map.Rooms.Count - 1; i++)
            {
                ConnectRooms(_map.Rooms[i], _map.Rooms[i + 1]);
            }

            return _map;
        }

        // Kopplar ihop två rum via en korridor, som går via rummens horisontella mittpunkter och möts i mitten.
        private void ConnectRooms(Room origin, Room target)
        {
            var originLoc = new Coord(origin.Area.Right, origin.Area.Top + origin.Size.Height / 2);
            var targetLoc = new Coord(target.Area.Left, target.Area.Top + target.Size.Height / 2);

            if (originLoc.Y == targetLoc.Y)
            {
                CreateHorizontalCorridor(originLoc, targetLoc);
                origin.ExitDoor = CreateDoor(originLoc);
                return;
            }
            else
            {
                var middleX = originLoc.X + ((targetLoc.X - originLoc.X) / 2);
                
                CreateHorizontalCorridor(originLoc, new Coord(middleX, originLoc.Y));
                CreateHorizontalCorridor(new Coord(middleX, targetLoc.Y), targetLoc);

                origin.ExitDoor = CreateDoor(originLoc);

                originLoc = new Coord(middleX, originLoc.Y);
                targetLoc = new Coord(middleX, targetLoc.Y);

                if (originLoc.Y > targetLoc.Y)
                {
                    CreateVerticalCorridor(targetLoc, originLoc);
                }
                else if (originLoc.Y < targetLoc.Y)
                {
                    CreateVerticalCorridor(originLoc, targetLoc);
                }
                
            }
        }

        // Skapar en horisontell tunnel av TileFloor mellan två punkter.
        private void CreateHorizontalCorridor(Coord origin, Coord target)
        {
            // Ser till att punkterna har samma Y-koordinat, och att target har en högre X-koordinat för att förhindra fel.
            if(origin.Y != target.Y || origin.X == target.X)
            {
                throw new ArgumentException();
            }

            for(int x = origin.X; x <= target.X; x++)
            {
                _map.TileGrid[x][origin.Y] = new TileFloor();
            }
        }

        // Skapar en vertikal tunnel av TileFloor mellan två punkter.
        private void CreateVerticalCorridor(Coord origin, Coord target)
        {
            // Ser till att punkterna har samma X-koordinat, och att target har en högre Y-koordinat för att förhindra fel.
            if (origin.X != target.X || origin.Y == target.Y)
            {
                throw new ArgumentException();
            }

            for (int y = origin.Y; y <= target.Y; y++)
            {
                _map.TileGrid[origin.X][y] = new TileFloor();
            }
        }

        private TileDoor CreateDoor(Coord location)
        {
            var door = new TileDoor();
            _map.TileGrid[location.X][location.Y] = door;
            return door;
        }

        private void CreateRoomTiles()
        {
            foreach (Room room in _map.Rooms)
            {
                if (_map.IsWithinBounds(room.Position) && _map.IsWithinBounds(room.Position + new Coord(room.Size.Width, room.Size.Height)))
                {
                    for (int y = room.Position.Y; y < room.Position.Y + room.Size.Height; y++)
                    {
                        for (int x = room.Position.X; x < room.Position.X + room.Size.Width; x++)
                        {
                            _map.TileGrid[x][y] = new TileFloor();
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Fyller hela kartan med en specifik sorts Tile.
        /// </summary>
        private void FillWithTileOfType<T>() where T : TileBase, new()
        {
            for (int x = 0; x < _map.Width; x++)
            {
                for (int y = 0; y < _map.Height; y++)
                {
                    _map.TileGrid[x][y] = new T();
                }
            }
        }
    }
}
