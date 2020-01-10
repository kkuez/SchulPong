using System;
using System.Collections.Generic;
/**
 This class is responsible for the first menu presented.
     */
namespace sasd.MenuScreens
{
    public class GeneralScreen : MenuScreen
    {
        public GeneralScreen(IO io, Management management) {
            SetManagement(management);
            SetIO(io);
            List<MenuLine> listOfLines = new List<MenuLine>();
            listOfLines.Add(new MenuLine("Host", "menuHost"));
            listOfLines.Add(new MenuLine("Client", "menuClient"));
            listOfLines.Add(new MenuLine("Test", "Test"));
            listOfLines[0].SetIsMarked(true);
            SetLineList(listOfLines);
        }

        public override void Back()
        {}

        public override String Submit()
        {
            String menuLineCallback = GetMarkedLine().GetCallBack();
            switch (menuLineCallback) {
                case "menuHost":
                    Console.Clear();
                    string port = Ask("Wie lautet der Port?");
                  GetIO().ActAsServer(Int32.Parse(port));
                  GetManagement().SetCurrentScreen(new GameScreen(this.GetIO(),this.GetManagement()));  
                    break;
                case "menuClient":
                    Console.Clear();
                    string ip = Ask("Wie lautet die Ip?");
                    Console.Clear();
                    port = Ask("Wie lautet der Port?");
                    GetIO().ActAsClient(ip, Int32.Parse(port));
                    GetManagement().SetCurrentScreen(new GameScreen(this.GetIO(),this.GetManagement()));
                    break;
                case "Test":
                    Console.Clear();
                    GetManagement().SetCurrentScreen(new GameScreen(this.GetIO(), this.GetManagement()));
                    break;
            }
            return "GeneralScreen";
        }
    }
}
