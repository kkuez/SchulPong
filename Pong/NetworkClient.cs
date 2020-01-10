using System;
using System.Net.Sockets;

/*
 * This class is the client class which handles connection with the server and transfer of data to the remote site.
 * tcpClient field will be initialized lazily by initiating a new instance of TCPClient with the given ip and port. 
 *tcpClient immediately tries to connect with the remote machine.
 *
 * *After that, networkStream field will be initized by the tcpClients getStream()-method. The field now provides the remotely sended data by stream by offering methods to read
 *or write data of/ to that stream.
 */

namespace sasd
{
    class NetworkClient : Network
    {
        public NetworkClient(String ip, int port) {
            try
            {
                SetTcpClient(new TcpClient(ip, port));
                SetNetworkStream(GetTcpClient().GetStream());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
