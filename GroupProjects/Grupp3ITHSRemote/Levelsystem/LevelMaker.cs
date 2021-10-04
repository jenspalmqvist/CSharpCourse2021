using System.Collections.Generic;

namespace Rollspel
{
    public static class LevelMaker
    {
        // Denna metod används ej, är bara en mall.
        private static void Template(out string name, out string message, out string[] lines, out int startX, out int startY, out List<IActiveObject> activeObjects)
        {
            // Kopiera denna metod och döp om till banans namn. Gör public.
            // Använd detta format för att designa en bana.
            // Se till att antalet tecken per rad stämmer med (LevelHandler.Width), och att antal rader stämmer med (LevelHandler.Height).

            name = "Namnlös bana";
            message = "Den här texten kommer upp på skärmen när man går in i banan.";

            lines = new string[LevelHandler.Height];
            lines[00] = @"╔══════════════════════════════════════════════════════════╗";
            lines[01] = @"║                                                          ║";
            lines[02] = @"║                                                          ║";
            lines[03] = @"║                                                          ║";
            lines[04] = @"║                                                          ║";
            lines[05] = @"║                                                          ║";
            lines[06] = @"║                                                          ║";
            lines[07] = @"║                                                          ║";
            lines[08] = @"║                                                          ║";
            lines[09] = @"║                                                          ║";
            lines[10] = @"║                                                          ║";
            lines[11] = @"║                                                          ║";
            lines[12] = @"║                                                          ║";
            lines[13] = @"║                                                          ║";
            lines[14] = @"║                                                          ║";
            lines[15] = @"║                                                          ║";
            lines[16] = @"║                                                          ║";
            lines[17] = @"║                                                          ║";
            lines[18] = @"║                                                          ║";
            lines[19] = @"╚══════════════════════════════════════════════════════════╝";
            //             |        |         |         |         |         |       |
            //             1        10        20        30        40        50      58

            startX = 29; // Spelarens startposition
            startY = 18; //

            // Lägg till alla aktiva objekt i denna lista.
            activeObjects = new List<IActiveObject>(); // Lista med objekt som kör egen kod (på denna bana).
            activeObjects.Add(new Exit(1, 1));
        }

        public static void Test(out string name, out string message, out string[] lines, out int startX, out int startY, out List<IActiveObject> activeObjects)
        {
            name = "Test";
            message = "     Detta är bara en testbana.";

            lines = new string[LevelHandler.Height];
            lines[00] = @"╔══════════════════════════════════════════════════════════╗";
            lines[01] = @"║X                   ÖVRE RADEN                            ║";
            lines[02] = @"║ 1,1                                                      ║";
            lines[03] = @"║                                                          ║";
            lines[04] = @"║                                                          ║";
            lines[05] = @"║V                                                         ║";
            lines[06] = @"║Ä                                                        H║";
            lines[07] = @"║N                                                        Ö║";
            lines[08] = @"║S                                                        G║";
            lines[09] = @"║T                                                        E║";
            lines[10] = @"║E                                                        R║";
            lines[11] = @"║R                                           ¤ ¤          K║";
            lines[12] = @"║K                                           ¤ ¤          A║";
            lines[13] = @"║A                                                        N║";
            lines[14] = @"║N                                                        T║";
            lines[15] = @"║T                                                         ║";
            lines[16] = @"║                                                          ║";
            lines[17] = @"║                                                   58,18  ║";
            lines[18] = @"║                       NEDRE RADEN                       X║";
            lines[19] = @"╚══════════════════════════════════════════════════════════╝";
            //             |        |         |         |         |         |       |
            //             1        10        20        30        40        50      58

            startX = 5;
            startY = 10;

            activeObjects = new List<IActiveObject>();
            activeObjects.Add(new Exit(58, 2));
            activeObjects.Add(new Nyckel(30, 8, true));
            activeObjects.Add(new Potatis(16, 10));
            activeObjects.Add(new Potatis(18, 10));
            activeObjects.Add(new Potatis(20, 10));
            activeObjects.Add(new Potatis(22, 10));
            activeObjects.Add(new Potatis(24, 10));
            activeObjects.Add(new Potatis(26, 10));
            activeObjects.Add(new Potatis(28, 10));
            activeObjects.Add(new Potatis(30, 10));
        }

        public static void Drama(out string name, out string message, out string[] lines, out int startX, out int startY, out List<IActiveObject> activeObjects)
        {
            name = "Drama!";
            message = "     Du vaknar på morgonen och ser att det ligger ett brev instucket under dörren. \n" + 
                "     Efter att ha halkat på gårdagens utspillda oboy snubblar du fram till brevet\n" +
                "     och läser det. Det är från Big Jens, han har snott din kastbara råtta och\n" +
                "     utmanar dig till att komma och hämta den. Inget snack om det, men\n" +
                "     dörren är låst och nyckeln har fått fötter...";

            lines = new string[LevelHandler.Height];
            lines[00] = @"╔══════════════════════════════════════════════════════════╗";
            lines[01] = @"║   _______                                 o              ║";
            lines[02] = @"║  |_*_|_*_|                                |              ║";
            lines[03] = @"║  |       |                          o    ,|.             ║";
            lines[04] = @"║                                     |  ,' \ `.           ║";
            lines[05] = @"║                                     |,'\,' ,' `.   o     ║";
            lines[06] = @"║                    .-===-.          |.`. ,'     `. |     ║";
            lines[07] = @"║                    | . . |          | `.`.    o  ,'|     ║";
            lines[08] = @"║                    | .'. |              `.`.  |,'  |     ║";
            lines[09] = @"║                   ()_____()               `.`.|  ,'|     ║";
            lines[10] = @"║                   ||_____||                 `.|,'        ║";
            lines[11] = @"║                    W     W                    |          ║";
            lines[12] = @"║                                                          ║";
            lines[13] = @"║                                                          ║";
            lines[14] = @"║                                                    _     ║";
            lines[15] = @"║    .-^-.                                          | |    ║";
            lines[16] = @"║   ´´'|'``                                     ____| |    ║";
            lines[17] = @"║      j                                       (_   .'     ║";
            lines[18] = @"║                                                )  (      ║";
            lines[19] = @"╚══════════════════════════════════════════════════════════╝";
            //             |        |         |         |         |         |       |
            //             1        10        20        30        40        50      58

            startX = 48;
            startY = 4;

            activeObjects = new List<IActiveObject>();
            activeObjects.Add(new Exit(55, 18));
            activeObjects.Add(new Nyckel(1, 2, false));
            activeObjects.Add(new Nyckel(48, 17, false));
            activeObjects.Add(new Nyckel(22, 11, false));
        }

        public static void Yard(out string name, out string message, out string[] lines, out int startX, out int startY, out List<IActiveObject> activeObjects)
        {
            name = "Trädgård";
            message = "     Du kommer ut ur huset och sätter fötterna på gräsmattan. \n" + 
                "     Flera av grannskapets gräsklippare verkar ha samlats just här. De verkar\n" +
                "     samtala med varandra med ett dovt tomgångsljud. Tvåtaktarna verkar lite\n" +
                "     upprörda, kanske är det bara åldern som gör dem vresiga. Gräsklipparna verkar\n" +
                "     uppmärksamma att du är här, och närmar sig för att blockera din väg...";

            lines = new string[LevelHandler.Height];
            lines[00] = @"╔══════════════════════════════════════════════════════════╗";
            lines[01] = @"║               ____             #                         ║";
            lines[02] = @"║            __/    \_           #                         ║";
            lines[03] = @"║           '-Ö----Ö-'           #                         ║";
            lines[04] = @"║                                #                         ║";
            lines[05] = @"║      __                        #                         ║";
            lines[06] = @"║   ||/  \                                                 ║";
            lines[07] = @"║   |/    \                                                ║";
            lines[08] = @"║   /   _  \                                               ║";
            lines[09] = @"║   |  |_| |                     #           ________      ║";
            lines[10] = @"║   |      |                     #          /|__| | |\     ║";
            lines[11] = @"║###|______|###                  #         |      |_| \___.║";
            lines[12] = @"║                                #         '-----Ö----'    ║";
            lines[13] = @"║                                #                         ║";
            lines[14] = @"║                                #                         ║";
            lines[15] = @"║                                #                         ║";
            lines[16] = @"║                                #                         ║";
            lines[17] = @"║                                #                         ║";
            lines[18] = @"║                                #                         ║";
            lines[19] = @"╚══════════════════════════════════════════════════════════╝";
            //             |        |         |         |         |         |       |
            //             1        10        20        30        40        50      58

            startX = 15;
            startY = 18;

            activeObjects = new List<IActiveObject>();
            activeObjects.Add(new Exit(45, 1));
            activeObjects.Add(new Potatis(6, 13));
            activeObjects.Add(new Potatis(3, 4));
            activeObjects.Add(new Potatis(40, 5));
            activeObjects.Add(new Potatis(48, 17));
            activeObjects.Add(new Potatis(55, 18));
            activeObjects.Add(new LawnMower(20, 10, true));
            activeObjects.Add(new LawnMower(34, 8, false));
            activeObjects.Add(new LawnMower(57, 3, true));
            activeObjects.Add(new LawnMower(50, 4, true));
            activeObjects.Add(new LawnMower(45, 16, true));
            activeObjects.Add(new LawnMower(2, 6, false));
        }

        public static void Road(out string name, out string message, out string[] lines, out int startX, out int startY, out List<IActiveObject> activeObjects)
        {
            name = "Väg";
            message = "     Du står vid en väg som är hårt trafikerad av katter.\n" +
                "     Det finns inga övergångsställen eller trafikljus i närheten,\n" +
                "     så du får försöka ta dig över utan att bli påsprungen.\n" +
                "     Eftersom du är lite rädd för väglinjer så känner du att du måste gå mellan dem.";

            lines = new string[LevelHandler.Height];
            lines[00] = @"╔══════════════════════════════════════════════════════════╗";
            lines[01] = @"║                                                          ║";
            lines[02] = @"║                                                          ║";
            lines[03] = @"║                                                          ║";
            lines[04] = @"║                                                          ║";
            lines[05] = @"║                                                          ║";
            lines[06] = @"║── ── ── ── ── ── ── ── ── ── ── ── ── ── ── ── ── ── ── ─║";
            lines[07] = @"║                                                          ║";
            lines[08] = @"║                                                          ║";
            lines[09] = @"║- - - - - - - - - - - - - - - - - - - - - - - - - - - - - ║";
            lines[10] = @"║                                                          ║";
            lines[11] = @"║                                                          ║";
            lines[12] = @"║── ── ── ── ── ── ── ── ── ── ── ── ── ── ── ── ── ── ── ─║";
            lines[13] = @"║                                                          ║";
            lines[14] = @"║                                                          ║";
            lines[15] = @"║                                                          ║";
            lines[16] = @"║                                                          ║";
            lines[17] = @"║                                                          ║";
            lines[18] = @"║                                                          ║";
            lines[19] = @"╚══════════════════════════════════════════════════════════╝";
            //             |        |         |         |         |         |       |
            //             1        10        20        30        40        50      58

            startX = 29;
            startY = 17;

            activeObjects = new List<IActiveObject>();
            activeObjects.Add(new Exit(29, 1));

            activeObjects.Add(new CatCar(16, 7, -2)); activeObjects.Add(new CatCar(17, 7, -2));
            activeObjects.Add(new CatCar(26, 7, -2)); activeObjects.Add(new CatCar(27, 7, -2));
            activeObjects.Add(new CatCar(33, 7, -2)); activeObjects.Add(new CatCar(34, 7, -2));
            activeObjects.Add(new CatCar(46, 7, -2)); activeObjects.Add(new CatCar(47, 7, -2));
            activeObjects.Add(new CatCar(56, 7, -2)); activeObjects.Add(new CatCar(57, 7, -2));
            activeObjects.Add(new CatCar(15, 8, -3)); activeObjects.Add(new CatCar(16, 8, -3)); activeObjects.Add(new CatCar(17, 8, -3));
            activeObjects.Add(new CatCar(25, 8, -3)); activeObjects.Add(new CatCar(26, 8, -3)); activeObjects.Add(new CatCar(27, 8, -3));
            activeObjects.Add(new CatCar(55, 8, -3)); activeObjects.Add(new CatCar(56, 8, -3)); activeObjects.Add(new CatCar(57, 8, -3));
            activeObjects.Add(new CatCar(2, 10, 3)); activeObjects.Add(new CatCar(3, 10, 3)); activeObjects.Add(new CatCar(4, 10, 3));
            activeObjects.Add(new CatCar(22, 10, 3)); activeObjects.Add(new CatCar(23, 10, 3)); activeObjects.Add(new CatCar(24, 10, 3));
            activeObjects.Add(new CatCar(39, 10, 3)); activeObjects.Add(new CatCar(40, 10, 3)); activeObjects.Add(new CatCar(41, 10, 3));
            activeObjects.Add(new CatCar(2, 11, 2)); activeObjects.Add(new CatCar(3, 11, 2));
            activeObjects.Add(new CatCar(22, 11, 2)); activeObjects.Add(new CatCar(23, 11, 2));
            activeObjects.Add(new CatCar(37, 11, 2)); activeObjects.Add(new CatCar(38, 11, 2));
            activeObjects.Add(new CatCar(42, 11, 2)); activeObjects.Add(new CatCar(43, 11, 2));
            activeObjects.Add(new CatCar(52, 11, 2)); activeObjects.Add(new CatCar(53, 11, 2));
        }

        public static void Labyrint(out string name, out string message, out string[] lines, out int startX, out int startY, out List<IActiveObject> activeObjects)
        {
            name = "Labyrint";
            message = "     Du vet inte hur du hamnade mitt i en labyrint, men det är nog bara\n" +
                "     en manusgrej. Det känns i alla fall på lukten att det finns tre ringklockor\n" +
                "     i närheten. De måste väl ha någon betydelse?";

            lines = new string[LevelHandler.Height];
            lines[00] = @"╔══════════════════════════════════════════════════════════╗";
            lines[01] = @"║##########################################################║";
            lines[02] = @"║       ### ##                     ##############     #####║";
            lines[03] = @"║###### ##     ### ############### ########       ### #####║";
            lines[04] = @"║###### ## ## ####       ######### ######## ######### ###  ║";
            lines[05] = @"║###### ##### ########## ######### ##### ## #########     #║";
            lines[06] = @"║###### ###      ####### ######### ##### ## ########## ####║";
            lines[07] = @"║###### ### #### ####### ######### ##### ## ########## ####║";
            lines[08] = @"║###### ######## #####         ###       ##       #### ####║";
            lines[09] = @"║######             ##         ############# ####      ####║";
            lines[10] = @"║################## ##         ############# #### #########║";
            lines[11] = @"║################## ###### #################    # #########║";
            lines[12] = @"║###           #### ######               ###### # #########║";
            lines[13] = @"║### ######### #### ####################             ######║";
            lines[14] = @"║### #########      #################### ##### ##### ######║";
            lines[15] = @"║### ############## #################### ##### #####       ║";
            lines[16] = @"║###         ######                      ##### ############║";
            lines[17] = @"║########### #################################          ###║";
            lines[18] = @"║########### ##############################################║";
            lines[19] = @"╚══════════════════════════════════════════════════════════╝";
            //             |        |         |         |         |         |       |
            //             1        10        20        30        40        50      58

            startX = 26;
            startY = 10;

            activeObjects = new List<IActiveObject>();
            activeObjects.Add(new Checkpoint(58, 4));
            activeObjects.Add(new Checkpoint(58, 15));
            activeObjects.Add(new Checkpoint(1, 2));
            activeObjects.Add(new Exit(25, 9));
        }


        public static void Minor(out string name, out string message, out string[] lines, out int startX, out int startY, out List<IActiveObject> activeObjects)
        {
            // Kopiera denna metod och döp om till banans namn. Gör public.
            // Använd detta format för att designa en bana.
            // Se till att antalet tecken per rad stämmer med (LevelHandler.Width), och att antal rader stämmer med (LevelHandler.Height).

            name = "Minfält";
            message = "     Det ligger ett antal minor på detta fält. Korsa det om du kan! :) -Big Jens";

            lines = new string[LevelHandler.Height];
            lines[00] = @"╔══════════════════════════════════════════════════════════╗";
            lines[01] = @"║▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓║";
            lines[02] = @"║░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▒░░║";
            lines[03] = @"║░░░░▒▒░░░░▒░░░░░▒▒▒░░░░░░░░░▒░░░░░░░░░▒▒░░░░░░░░▒░░░░░░░░░║";
            lines[04] = @"║░░░░░░░░░░░░░░░░░░░▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░║";
            lines[05] = @"║░▒░░░░░░░░░░░░░░░░░░▒░░░░░░░░░░░░░░░░░░░░░░▒▒▒▒░░░░░░░▒░░░║";
            lines[06] = @"║░░░░░░░░░░░░▒▒▒░░░░░░░░░░░░░▒░░░░░░░░░░░░░░▒░░░░░░░░░░░░░░║";
            lines[07] = @"║░░░░░░░░░░░░░░░░░░░░░░░░░░▒░░░░░░░░░░░░░░░░▒░░░░░░░░░░░░░░║";
            lines[08] = @"║░░░░░░▒░░░░▒░░░░░░░░░░░░▒▒░░░░░░░░░░░░░░░▒▒░░░░░░░▒░░░░░░░║";
            lines[09] = @"║░░░░░░▒▒░░░░░░░░░░░░░░░░░░░░░░░░░░▒░░░░░░░░░░░░░░░░░░░░░░░║";
            lines[10] = @"║░░░░░░░░░░░░░░░░░░░░▒▒▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░║";
            lines[11] = @"║░░░░░░░░░░░░░░░░░░▒░▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░║";
            lines[12] = @"║░░░░░░░░░░░░▒░░░░░░░░░░░░░░░░░░░▒░░░░░░░░▒░░░░░░░░░░░░░▒░░║";
            lines[13] = @"║░░░░░▒▒▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▒▒░░░░░░░░░░░░░║";
            lines[14] = @"║░░░░░░░░░░▒▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░║";
            lines[15] = @"║░░░░▒░░░░░░░░░░░░░░░▒░░░░░░░▒░░░░░░░░░░░░░░░░░░░▒░░░░░░░░░║";
            lines[16] = @"║░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▒▒░░░░░░░░░░░░░░░░░▒▒░░░░░░░║";
            lines[17] = @"║░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░║";
            lines[18] = @"║▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓║";
            lines[19] = @"╚══════════════════════════════════════════════════════════╝";
            //             |        |         |         |         |         |       |
            //             1        10        20        30        40        50      58

            startX = 29;
            startY = 17;


            activeObjects = new List<IActiveObject>();
            activeObjects.Add(new Exit(29, 2));
            activeObjects.Add(new Boom(10, 2));
            activeObjects.Add(new Boom(28, 2));
            activeObjects.Add(new Boom(4, 3));
            activeObjects.Add(new Boom(10, 4));
            activeObjects.Add(new Boom(11, 5));
            activeObjects.Add(new Boom(1, 6));
            activeObjects.Add(new Boom(45, 7));
            activeObjects.Add(new Boom(52, 8));
            activeObjects.Add(new Boom(48, 9));
            activeObjects.Add(new Boom(41, 10));
            activeObjects.Add(new Boom(36, 11));
            activeObjects.Add(new Boom(32, 12));
            activeObjects.Add(new Boom(30, 13));
            activeObjects.Add(new Boom(31, 14));
            activeObjects.Add(new Boom(12, 15));
            activeObjects.Add(new Boom(32, 16));
            activeObjects.Add(new Boom(42, 17));
            activeObjects.Add(new Boom(47, 12));
            activeObjects.Add(new Boom(16, 17));
            activeObjects.Add(new Boom(15, 16));
            activeObjects.Add(new Boom(18, 15));
            activeObjects.Add(new Boom(3, 14));
            activeObjects.Add(new Boom(6, 17));
            activeObjects.Add(new Boom(8, 13));
            activeObjects.Add(new Boom(10, 12));
            activeObjects.Add(new Boom(14, 11));
            activeObjects.Add(new Boom(25, 10));
            activeObjects.Add(new Boom(27, 9));
            activeObjects.Add(new Boom(28, 8)); 
            activeObjects.Add(new Boom(22, 16));
            activeObjects.Add(new Boom(23, 17));
            activeObjects.Add(new Boom(24, 2));
            activeObjects.Add(new Boom(25, 5));
            activeObjects.Add(new Boom(26, 4));
            activeObjects.Add(new Boom(27, 15));
            activeObjects.Add(new Boom(28, 14));
            activeObjects.Add(new Boom(12, 2));
            activeObjects.Add(new Boom(30, 13));
            activeObjects.Add(new Boom(31, 3));
            activeObjects.Add(new Boom(32, 7));
            activeObjects.Add(new Boom(33, 9));
            activeObjects.Add(new Boom(37, 9));
            activeObjects.Add(new Boom(43, 8));
            activeObjects.Add(new Boom(33, 5));
            activeObjects.Add(new Boom(34, 4));
            activeObjects.Add(new Boom(36, 3));
            activeObjects.Add(new Boom(45, 7));
            activeObjects.Add(new Boom(46, 6));
            activeObjects.Add(new Boom(47, 9));
            activeObjects.Add(new Boom(49, 8));
            activeObjects.Add(new Boom(52, 10));
            activeObjects.Add(new Boom(53, 12));
            activeObjects.Add(new Boom(54, 3));
            activeObjects.Add(new Boom(55, 15));

        }
        public static void Ending(out string name, out string message, out string[] lines, out int startX, out int startY, out List<IActiveObject> activeObjects)
        {
            name = "Slutet";
            if (Player.Bonks < 20)
            {
                message = "     Du hittar Big Jens, han kastar råttan mot dig i ren förskräckelse.\n" +
                    "     Du fångar den graciöst med pannan och kelar lite med den,\n" +
                    "     sedan vandrar ni hemåt tillsammans.";
            }
            else
            {
                message = "     Du hittar Big Jens, han kastar råttan mot dig i ren förskräckelse.\n" +
                    "     Den landar på ditt huvud. Dock har du för många bulor i huvet för att\n" +
                    "     råttan ska känna igen dig. Den biter dig och springer iväg.\n" +
                    "     Du kommer på att du aldrig gillat den där råttan\n" +
                    "     särskilt mycket från början och går hem.";
            }
            

            lines = new string[LevelHandler.Height];
            lines[00] = @"╔══════════════════════════════════════════════════════════╗";
            lines[01] = @"║                                                          ║";
            lines[02] = @"║                                                          ║";
            lines[03] = @"║                                                          ║";
            lines[04] = @"║                                                          ║";
            lines[05] = @"║                                                          ║";
            lines[06] = @"║╧╤|                                                       ║";
            lines[07] = @"║╤╧| __                                                    ║";
            lines[08] = @"║╧╤|·.·)                                                   ║";
            lines[09] = @"║╤╧|c /                                                    ║";
            lines[10] = @"║╧╤|                                                       ║";
            lines[11] = @"║                                                          ║";
            lines[12] = @"║     __QQ                                                 ║";
            lines[13] = @"║    (_)_"">                                                ║";
            lines[14] = @"║   _)                                                     ║";
            lines[15] = @"║                                                          ║";
            lines[16] = @"║                                                          ║";
            lines[17] = @"║                                                          ║";
            lines[18] = @"║                                                          ║";
            lines[19] = @"╚══════════════════════════════════════════════════════════╝";
            //             |        |         |         |         |         |       |
            //             1        10        20        30        40        50      58

            startX = 32; 
            startY = 15; 

            activeObjects = new List<IActiveObject>();
            activeObjects.Add(new Exit(45, 18));
        }








    }
}