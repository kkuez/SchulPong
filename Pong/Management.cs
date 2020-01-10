using System;
using System.Collections.Generic;
using System.Windows.Input;
/**
 This class is the control class which is called by Program.cs and inherits critical objects which are required for correct functioning of the program.
     */
namespace sasd
{
   public class Management {

        private IO io;

        private Screen currentScreen;

        private GameScreen gameScreen; 

        private Boolean exit;

        public Management() {
            io = new IO(this);
            exit = false;
            currentScreen = new MenuScreens.GeneralScreen(io, this);
            gameScreen =    new GameScreen( io, this);
            loop();
        }

        private void loop() {
            while (!exit)
            {
                currentScreen.Redraw();
                System.Threading.Thread.Sleep(20);
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo pressedkey = Console.ReadKey();
                    GamePlayControlEnum gamePlayControlEnum = io.GetControlEnum(pressedkey);
                    GamePlayControlEnum gamePlayCOntrolEnum2;
                    io.ProcessControl(gamePlayControlEnum, currentScreen);
					io.ProcessReceivedString(gamePlayCOntrolEnum2, currentScreen);
                   
                }
                    if (currentScreen.GetType() == typeof(GameScreen))
                {
                    gameScreen.ballroutine();
                }
            }
        }

        //GETTER SETTER
        public IO GetIO()
        {
            return io;
        }

        public void SetExit(Boolean value) {
           // this.exit = exit;
        }

        public Screen GetCurrentScreen() {
            return currentScreen;
        }

        public void SetCurrentScreen(Screen screen) {
            this.currentScreen = screen;
        }


       /* public GameScreen GetGameScreen()
        {
            return gameScreen;
        }
        */
    }
}
