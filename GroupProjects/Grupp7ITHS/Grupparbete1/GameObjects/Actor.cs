using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupparbete1.GameObjects
{
    /// <summary>
    /// Representerar ett GameObject som kan agera, till exempel genom att röra sig eller attackera andra Actors.
    /// Alla objekt som kan agera ärver från denna klass, dvs både spelare och fiender.
    /// </summary>
    public class Actor : GameObject
    {
        private int _health;
        public int MaxHealth { get; set; }

        /// <summary>
        /// Kontrollerar att det värde som programmet försöker sätta _health till inte är negativt eller över MaxHealth, så att en Actor inte kan ha mer Health än MaxHealth, eller mindre än 0 Health.
        /// </summary>
        public int Health
        {
            get => _health;
            set
            {
                if (value > MaxHealth)
                {
                    _health = MaxHealth;
                }
                else if (value < 0)
                {
                    _health = 0;
                    OnDeath();
                }
                else
                {
                    _health = value;
                }
            
            }
        }

        // Den skada som Actorn gör om dess attack träffar.
        public int Damage { get; set; }

        // Det värde som en anfallare behöver rulla över för att träffa och göra skada.
        public int Defense { get; set; }

        private Random dice;

        public Actor(int x, int y, string name, char glyph, int maxHealth, int damage, int defense) : base(x, y, name, glyph)
        {
            dice = new Random();
            MaxHealth = maxHealth;
            Health = MaxHealth;
            Damage = damage;
            Defense = defense;
        }

        /// <summary>
        /// Flyttar Actorn i en viss riktning, beroende på de koordinater som angetts. Koordinater som anges bör vara -1, 0, eller 1.
        /// </summary>
        /// <param name="deltaX">Förändringen i horisontell position.</param>
        /// <param name="deltaY">Förändringen i vertikal position.</param>
        /// <returns>Används för att kontrollera om förflyttningen lyckades. Går bl.a. att använda för att se till att spelaren inte slösar sin tur på att försöka gå in i en vägg.</returns>
        public bool MoveBy(int deltaX, int deltaY)
        {
            // Kontrollerar att de koordinater som actorn ska flyttas till existerar.
            if (Program.Game.GameMap.IsWithinBounds(X + deltaX, Y + deltaY))
            {                
                // Kontrollerar att den Tile som actorn ska flyttas till går att gå på.
                if (Program.Game.GameMap.TileGrid[X + deltaX][Y + deltaY].IsWalkable)
                {
                    // Kontrollerar om det finns en fiende på den Tile som Actorn ska flyttas till.
                    var enemy = Program.Game.GameMap.GetEntityAtLoc<Enemy>(X + deltaX, Y + deltaY);
                    var tablet = Program.Game.GameMap.GetEntityAtLoc<RiddleTablet>(X + deltaX, Y + deltaY);

                    // Om det finns en fiende så attackeras den istället för att Actorn flyttas till den rutan.
                    // Annars uppdateras Actorns position till den nya positionen.
                    if (enemy is not null)
                    {
                        Attack(enemy);
                        return true;
                    }
                    else if (tablet is not null)
                    {
                        tablet.Riddle.PrintRiddle();
                        Program.Game.GameMap.CurrentRiddleTablet = tablet;
                        Program.Game.CurrentMode = ControlMode.RiddleInput;
                    }
                    else
                    {
                        X += deltaX;
                        Y += deltaY;
                        Program.Game.GameMap.UpdateAfterActorMove(this, new Coord(X - deltaX, Y - deltaY));
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Används när en Actor attackerar en annan, och räknar ut om attacken träffar och hur mycekt skada den gör.
        /// </summary>
        /// <param name="defender">Den Actor som attackeras.</param>
        public void Attack(Actor defender)
        {
            var attackRoll = dice.Next(1, 21);

            if(attackRoll > defender.Defense)
            {
                defender.Health -= Damage;
            }
        }

        /// <summary>
        /// Körs när en Actors Health når 0. Tar bort den från listan med GameObjects i Map-klassen, och uppdaterar det som visas på rutan med de koordinater som Actorn hade.
        /// </summary>
        private void OnDeath()
        {
            Program.Game.GameMap.UpdateAfterActorMove(this, new Coord(X, Y));
            Program.Game.GameMap.GameObjects.Remove(this);
        }
    }
}
