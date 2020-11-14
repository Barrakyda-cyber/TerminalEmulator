using System;
using System.Collections.Generic;
using System.Text;

namespace Terminal
{
    
    public class Terminal
    {
        Catalog users;
        Catalog admin;
        Catalog megaboss;

        public Terminal()
        {
            UserCatalogListCommand();
            AdminCatalogListCommand();
            MegabossCatalogListCommand();
        }
        private void UserCatalogListCommand()
        {
            users = new Catalog("User");
            users.AddCommand("admin", () => { admin.PerformingOperation(); });
        }

        private void AdminCatalogListCommand()
        {
            admin = new Catalog("Admin", users.path);
            admin.AddCommand("color", () => { Console.ForegroundColor = ConsoleColor.Green; });
            admin.AddCommand("megaboss", () => { megaboss.PerformingOperation(); });
        }
        private void MegabossCatalogListCommand()
        {
            megaboss = new Catalog("Megaboss", admin.path);
            megaboss.AddCommand("godmode", () => { Console.ForegroundColor = ConsoleColor.Red; });
        }

        public void TerminalEntrance()
        {
            users.PerformingOperation();
        }
    }
}
