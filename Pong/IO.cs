using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
/**
 This class is responsible for Keyboard In-Output, Network-communication and File-related procressing.
     */
namespace sasd
{
    //
    public class IO {

        private Management management;

        private String iP;

        private int port;

        private HashSet<ConsoleKey> controlKeySet;

        private Network network;

        public IO(Management management) {
            this.management = management;
            controlKeySet = new HashSet<ConsoleKey>() { ConsoleKey.UpArrow, ConsoleKey.DownArrow, ConsoleKey.Enter, ConsoleKey.Escape };
        }

        public GamePlayControlEnum parseGPEnumFromString(String incomingString)
        {
            GamePlayControlEnum incomingEnum = GamePlayControlEnum.NOCONTROLKEY;
            if (incomingString.StartsWith("<GamePlayControlEnum>")) {
                String enumString = incomingString.Replace("<GamePlayControlEnum>", "").Replace("</GamePlayControlEnum>", "");
                switch (enumString) {
                    case "UP":
                        break;
                    case "DOWN":
                        break;
                    case "SUBMIT":
                        break;
                }
            }
            return incomingEnum;
        }

        public GamePlayControlEnum GetControlEnum(ConsoleKeyInfo consoleKeyInfo) {

            GamePlayControlEnum controlEnum = GamePlayControlEnum.NOCONTROLKEY;

            if (consoleKeyInfo.Key == ConsoleKey.UpArrow)
            {
                controlEnum = GamePlayControlEnum.UP;
            }
            if (consoleKeyInfo.Key == ConsoleKey.DownArrow)
            {
                controlEnum = GamePlayControlEnum.DOWN;
            }
            if (consoleKeyInfo.Key == ConsoleKey.Enter)
            {
                controlEnum = GamePlayControlEnum.SUBMIT;
            }
            if (consoleKeyInfo.Key == ConsoleKey.Escape)
            {
                controlEnum = GamePlayControlEnum.BACK;
            }
            return controlEnum;
        }

        public void ProcessControl(GamePlayControlEnum gamePlayControlEnum, Screen screen)
        {
            switch (gamePlayControlEnum) {
                case GamePlayControlEnum.UP:
                    screen.Up();
                    break;
                case GamePlayControlEnum.DOWN:
                    screen.Down();
                    break;
                case GamePlayControlEnum.SUBMIT:
                    screen.Submit();
                    break;
                case GamePlayControlEnum.BACK:
                    screen.Back();
                    break;
            }
            if (management.GetCurrentScreen() is GameScreen)
            {
                SendMessageString(gamePlayControlEnum.ToString(), "GamePlayControlEnum");
            }
        }

        public void SendMessageString(string messageString, string objectType){
            if (network == null) {
                Console.WriteLine("Network connection not established!");
                return;
            }
            String taggedString = "<" + objectType + ">" + messageString + "</" + objectType + ">";
            byte[] byteArray = Encoding.ASCII.GetBytes(taggedString);
            network.GetNetworkStream().Write(byteArray, 0, byteArray.Length);
        }

		public void ProcessReceivedString(GamePlayControlEnum incomingEnum, Screen screen) {
            if (network == null)
            {
                Console.WriteLine("Network connection not established!");
            }
            else
            {
                byte[] bytes = new byte[1024];
                int bytesRead = network.GetNetworkStream().Read(bytes, 0, bytes.Length);
                string receivedString = Encoding.ASCII.GetString(bytes, 0, bytesRead);
                incomingEnum = parseGPEnumFromString(receivedString);
                //TODO enum kann nun benutzt werden für gegnerbalken!!
            }
    }

    public void ActAsClient(string ip, Int32 port) {
            network = new NetworkClient(ip, port);
    }

        //Method will prepare classes fields to act as host
        public void ActAsServer(Int32 port) {
            network = new NetworkServer(port);
    }

        //closes networkstream
        public void CloseConnection()
        {
            network.GetNetworkStream().Close();
            network.GetTcpClient().Close();
        }

        //GETTER SETTER
    }
}