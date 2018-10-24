using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NetworkCommsDotNet.Tools;
using NetworkCommsDotNet.Connections;
using NetworkCommsDotNet;
namespace Server
{
    public partial class Server : Form
    {
        public Server()
        {
            InitializeComponent();
        }
        string ip = "127.0.0.1";
        int port = 6600;
        private static List<Connection> Clients { get; set; } = new List<Connection>();
        private void Server_Load(object sender, EventArgs e)
        {
            NetworkComms.AppendGlobalIncomingPacketHandler<string>("Messages", OnMessageReceived);
            NetworkComms.AppendGlobalConnectionCloseHandler(OnConnectionClose);
            NetworkComms.AppendGlobalConnectionEstablishHandler(OnConnectionOpen);

            //Start listening for incoming connections
            Connection.StartListening(ConnectionType.TCP, new System.Net.IPEndPoint(System.Net.IPAddress.Parse(ip), port));

            lblServer.Text = "Server: " + ip + ":" + port;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var stringToSend = txtMessage.Text;
            txtMessage.Clear();

            //If the user has typed exit then we leave
            foreach (var client in Clients)
            {
                client.SendObject("Messages", stringToSend);
            }
            rtxtMessages.Text += "Server: " + stringToSend + Environment.NewLine;
        }

        private void OnMessageReceived(PacketHeader packetHeader, Connection connection, string message)
        {
            SetText("Incoming message from " + connection.ToString() + " saying '" + message + "'." + Environment.NewLine);
        }

        private void OnConnectionClose(Connection connection)
        {
            Clients.Remove(connection);
            SetText("Client disconnected " + connection.ToString() + Environment.NewLine);
        }

        private void OnConnectionOpen(Connection connection)
        {
            Clients.Add(connection);
            SetText("Client connected " + connection.ToString() + Environment.NewLine);
        }
        delegate void SetTextCallback(string text);

        private void SetText(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.rtxtMessages.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.rtxtMessages.Text += text;
            }
        }

        private void Server_FormClosing(object sender, FormClosingEventArgs e)
        {
            // close connection
            NetworkComms.Shutdown();
        }
    }
}
