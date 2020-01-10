using System.Net.Sockets;

/*
 * This class provides the minimum required fields for network related objects.
 * **/

namespace sasd
{
    abstract class Network
    {
        protected TcpClient tcpClient { get; set; }

        protected NetworkStream networkStream { get; set; }

        public TcpClient GetTcpClient() {
            return tcpClient;
        }

        public NetworkStream GetNetworkStream()
        {
            return networkStream;
        }

        public void SetTcpClient(TcpClient tcpClient) {
            this.tcpClient = tcpClient;
        }

        public void SetNetworkStream(NetworkStream networkStream)
        {
            this.networkStream = networkStream;
        }
    }
}
