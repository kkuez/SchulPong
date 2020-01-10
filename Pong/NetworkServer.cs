using System;
using System.Net.Sockets;

/*
 * This class is the server class which handles connection with the cliend and transfer of data to the remote site.
 * First a TcpListener object is created with the port to listened to and started so it starts listening for incoming connections.
 * As soon as a connection is incoming, the listener initiates a TcpClient object and a networkStream object is spawned from that client.
 * The network stream then handles the data transfer to the remote client.
 * **/

namespace sasd
{
    class NetworkServer : Network
    {
        public NetworkServer(int port) {
			TcpListener tcpListener = new TcpListener(port);
            tcpListener.Start();
            Console.WriteLine("Waiting for opponent...");
            SetTcpClient(tcpListener.AcceptTcpClient());
            SetNetworkStream(tcpClient.GetStream());
        }
    }
}
