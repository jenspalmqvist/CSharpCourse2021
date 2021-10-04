using System;

namespace GruppUppgift1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Console.ForegroundColor = ConsoleColor.Red;
            SplashScreen();
            Console.ReadKey(true);
            Console.Clear();
            Game game = new Game();
            game.HelpMenu();
            game.InitGame();
            game.Loop();
        }

        private static void SplashScreen()
        {
            Console.WriteLine(@"                                                                          
            @@@@@@@   @@@@@@@    @@@@@@        @@@  @@@@@@@@   @@@@@@@  @@@@@@@  
            @@@@@@@@  @@@@@@@@  @@@@@@@@       @@@  @@@@@@@@  @@@@@@@@  @@@@@@@  
            @@!  @@@  @@!  @@@  @@!  @@@       @@!  @@!       !@@         @@!    
            !@!  @!@  !@!  @!@  !@!  @!@       !@!  !@!       !@!         !@!    
            @!@@!@!   @!@!!@!   @!@  !@!       !!@  @!!!:!    !@!         @!!    
            !!@!!!    !!@!@!    !@!  !!!       !!!  !!!!!:    !!!         !!!    
            !!:       !!: :!!   !!:  !!!       !!:  !!:       :!!         !!:    
            :!:       :!:  !:!  :!:  !:!  !!:  :!:  :!:       :!:         :!:    
            ::       ::   :::  ::::: ::  ::: : ::   :: ::::   ::: :::     ::    
            :         :   : :   : :  :    : :::    : :: ::    :: :: :     :     
                                                                          
                                                  
                                    @@@@@@@@   @@@@@@   
                                    @@@@@@@@@  @@@@@@@@  
                                    !@@             @@@  
                                    !@!            @!@   
                                    !@! @!@!@     !!@    
                                    !!! !!@!!    !!:     
                                    :!!   !!:   !:!      
                                    :!:   !::  :!:       
                                    ::: ::::  :: :::::  
                                    :: :: :   :: : :::  
                 


                                Press any key to continue..");
        }
    }
}