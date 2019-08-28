using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace WebRequestLogger
{
	class SocketStateObject
	{
		private const int MAX_BUFFER_SIZE = 11540100;
		private StringBuilder sb = new StringBuilder();

		public byte[] Buffer = new byte[MAX_BUFFER_SIZE];

		public Socket WorkSocket { get; set; }

		public int BufferSize => MAX_BUFFER_SIZE;

	}
}
