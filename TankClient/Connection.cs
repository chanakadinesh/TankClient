using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Net.Sockets;
using System.Threading;
namespace TankClient
{
    class Connection
    {
        private string IP = "127.0.0.1";
        private int server_port = 6000;
        private int client_port = 7000;
        private TcpClient client = null;
        private TcpListener client_listener = null;
        private string msg = "JOIN#";
        private NetworkStream serverStream;
        private Thread Listner_Thread;
        private Thread ServerClient_Thread;
        private Form1 gui;

        public Connection(Form1 f) {
            this.gui = f;
        }

        public void sendToServer(string m){
            this.msg = m;
        }

        public void writing_on_client()
        {

            this.client = new TcpClient();

            try
            {
                this.client.Connect(IP, server_port);
                while (true)
                {
                    if (this.client.Connected)
                    {
                        //To write to the socket
                        // gui.WriteDisplay("Connection Established...!");
                        if (msg != "")
                        {
                            NetworkStream clientStream = client.GetStream();

                            //Create objects for writing across stream
                            BinaryWriter writer = new BinaryWriter(clientStream);

                            Byte[] tempStr = Encoding.ASCII.GetBytes(msg);

                            //writing to the port                
                            writer.Write(tempStr);
                            gui.WriteDisplay("\t Data: " + msg + " is written to Server");
                            msg = "";
                            writer.Close();
                            clientStream.Close();
                        }
                        Thread.Sleep(10);
                    }
                    else {
                        this.client.Connect(IP, server_port);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Communication (WRITING) to  on Server Failed! \n " + e.Message);
            }
            finally
            {
                this.client.Close();
            }
        }

        public void receiving_from_client()
        {
            Socket connection = null; //The socket that is listened to       
            try
            {
                //Creating listening Socket
                this.client_listener = new TcpListener(IPAddress.Parse(IP), client_port);
                //Starts listening
                this.client_listener.Start();
                //Establish connection upon client request
                //DataObject dataObj;
                while (true)
                {
                    //connection is connected socket
                    connection = client_listener.AcceptSocket();
                    if (connection.Connected)
                    {
                        //To read from socket create NetworkStream object associated with socket
                        this.serverStream = new NetworkStream(connection);

                        SocketAddress sockAdd = connection.RemoteEndPoint.Serialize();
                        string s = connection.RemoteEndPoint.ToString();
                        List<Byte> inputStr = new List<byte>();

                        int asw = 0;
                        while (asw != -1)
                        {
                            asw = this.serverStream.ReadByte();
                            inputStr.Add((Byte)asw);
                        }

                        String reply = Encoding.UTF8.GetString(inputStr.ToArray());
                       // Console.WriteLine("Server Reply: " + reply);
                        gui.DisplayServerMessage(reply);

                    }

                }
            }
            catch (Exception e)
            {
                gui.WriteDisplay("Communication (RECEIVING) Failed! \n " + e.Message);
            }
            finally
            {
                if (connection != null)
                    if (connection.Connected)
                        connection.Close();
                //if (errorOcurred)
                //this.ReceiveData();
            }
        }

        public void startClient()
        {
            Listner_Thread = new Thread(new ThreadStart(this.writing_on_client));
            ServerClient_Thread = new Thread(new ThreadStart(this.receiving_from_client));
            Listner_Thread.IsBackground = true;
            ServerClient_Thread.IsBackground = true;
            Listner_Thread.Start();
            ServerClient_Thread.Start();
        }
       /* public void stopClient() {
            try
            {
                if (Listner_Thread.IsAlive) { Listner_Thread.Abort(); }
                if (ServerClient_Thread.IsAlive) { ServerClient_Thread.Abort(); }
            }
            catch (Exception e)
            {

            }
        }*/
    }
}
