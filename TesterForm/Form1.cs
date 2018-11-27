using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using Global.Models;

namespace TesterForm
{
    public partial class Form1 : Form
    {
        string serverIP = "localhost";
        int port = 8080;
        Guid userId = new Guid("player 1");
        Guid matchId = new Guid("Match 123");
        public Form1()
        {
            InitializeComponent();
        }

        private void submit_Click(object sender, EventArgs e)
        {
            TcpClient client = new TcpClient(serverIP, port);
            MoveModel move = new MoveModel(moveTxtBox.Text, userId, matchId);


            // mkaes a byte array . length is how much byte the bessage contained
            byte[] sendData = move.ToByteArray();

            NetworkStream stream = client.GetStream();

            //sends entire message in the stream
            stream.Write(sendData, 0, sendData.Length);

            stream.Close();
            client.Close();
        }
    }
}
