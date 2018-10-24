using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NetworkCommsDotNet;
using NetworkCommsDotNet.Connections;
using NetworkCommsDotNet.Tools;

namespace Client
{
    public partial class Client : Form
    {
        public Client()
        {
            InitializeComponent();
        }
        string ip = "127.0.0.1";
        int port = 6600;
        private void Client_Load(object sender, EventArgs e)
        {
            // set the on message event
            NetworkComms.AppendGlobalIncomingPacketHandler<string>("Messages", OnMessageReceived);     
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            ip = txtIP.Text;
            port = Convert.ToInt16(txtPort.Text);

            // first message to the server will trigger a connection automatically plus it will send the message
            NetworkComms.SendObject("Messages", ip, port, "Connecting");
            lblStatus.Text = "Status: " + ip + ":" + port;
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            var stringToSend = txtMessage.Text;
            txtMessage.Clear();

            NetworkComms.SendObject("Messages", ip, port, stringToSend);
            rtxtMessages.Text += "Me: " + stringToSend + Environment.NewLine;
        }

        private void OnMessageReceived(PacketHeader packetHeader, Connection connection, string message)
        {
            rtxtMessages.Text += "Incoming message from " + connection.ToString() + " saying '" + message + "'." + Environment.NewLine;
        }

        private void Client_FormClosing(object sender, FormClosingEventArgs e)
        {
            // close connection
            NetworkComms.Shutdown();
        }
    }
}
