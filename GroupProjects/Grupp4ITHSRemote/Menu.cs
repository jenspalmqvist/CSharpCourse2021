using System;
using System.Collections.Generic;
using System.Text;

namespace HomeButlerV1
{
    class Menu
    {
        public string MenuName;
        public int MenuLevel;
        public List<string> MenuList;
        public Menu() { }
        public Menu(string menuName, int menuLevel)
        {
            MenuName = menuName;
            MenuLevel = menuLevel;
            MenuList = new List<string>();
        }       
        public Functions GetNameLevelList()
        {
            Functions result = new Functions();
            result.menuTitle = MenuName;
            result.menuLevel = MenuLevel;
            result.menuList = MenuList;
            return result;
        }
    }
}
