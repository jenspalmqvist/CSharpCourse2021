using System;
using ConsoleTables;

namespace RollSpelGrupp6.Classes
{
    public class Inventory
    {
        public Equipment[][] InventoryContents { get; set; }
        public bool IsContentUpdated { get; set; }

        public Inventory()
        {
            InventoryContents = new Equipment[3][]
            {
                new Weapon[3],
                new DefenseEquipment[3],
                new Potion[3]
            };
            IsContentUpdated = false;
        }

        public void DropItem()
        {
        }

        public void PutItem(Equipment equipment)
        {
            int equipmentType = GetEquipmentType(equipment);
            (bool, int) temp = HasSpace(equipmentType);
            if (temp.Item1)
            {
                InventoryContents[equipmentType][temp.Item2] = equipment;
            }
            else
            {
                //Ask user which item to replace
                throw new NotImplementedException();
            }
        }

        public (bool, int) HasSpace(int equipmentType)
        {
            for (int i = 0; i < 3; i++)
            {
                if (InventoryContents[equipmentType][i] is null)
                {
                    return (true, i);
                }
            }
            return (false, -1);
        }

        public int GetEquipmentType(Equipment equipment)
        {
            if (equipment is Weapon)
            {
                return 0;
            }
            else if (equipment is DefenseEquipment)
            {
                return 1;
            }
            else //if (equipment is Potion)
            {
                return 2;
            }
        }

        public void PrintInventory()
        {
            var table = new ConsoleTable("Index", "", "1", "2", "3");

            for (int i = 0; i < InventoryContents.Length; i++)
            {
                table.AddRow(RowBuilder(i));
            }
            table.Write(Format.Alternative);
        }

        private string[] RowBuilder(int rowIndex)
        {
            string[] arrayToReturn = new string[5];
            arrayToReturn[0] = $"{rowIndex + 1}";
            switch (rowIndex)
            {
                case 0:
                    arrayToReturn[1] = "Weapons";
                    break;

                case 1:
                    arrayToReturn[1] = "Armours";
                    break;

                case 2:
                    arrayToReturn[1] = "Potions";
                    break;
            }
            for (int i = 0; i < InventoryContents[rowIndex].Length; i++)
            {
                arrayToReturn[i + 2] = InventoryContents[rowIndex][i] is null ? "Empty" : InventoryContents[rowIndex][i].ToString();
            }
            return arrayToReturn;
        }
    }
}