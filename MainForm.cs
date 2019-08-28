using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebRequestLogger
{
	public partial class WebRequestLoggerForm : Form
	{

		public WebRequestLoggerForm()
		{
			InitializeComponent();
		}

		private void startBtn_Click(object sender, EventArgs e)
		{
			SocketManager socketManager = new SocketManager();

			socketManager.OnNewListener += SocketManager_OnNewListener;
			socketManager.OnNewRequest += SocketManager_OnNewRequest;

			socketManager.StartListening();

		}

		private void SocketManager_OnNewRequest(string requestContent)
		{
			flowLayoutPanel.Invoke(new Action(() => {
				Label label = new Label();
				label.Text = requestContent;
				flowLayoutPanel.Controls.Add(label);
			}));

		}

		private void SocketManager_OnNewListener(string endpoint)
		{
			//can't access the control outside the main UI thread
			listeningEndpointTextBox.Invoke(new Action(()=> {	
				listeningEndpointTextBox.Text = endpoint;
			}));
		}


		private void redirectChkBox_CheckedChanged(object sender, EventArgs e)
		{
			redirectToTextBox.ReadOnly = !((CheckBox)sender).Checked;
		}

		private void WebRequestLoggerForm_Load(object sender, EventArgs e)
		{

		}


	}
}
