// Smuxi - Smart MUltipleXed Irc
//
// Copyright (c) 2013 Mirco Bauer <meebey@meebey.net>
//
// Full GPL License: <http://www.gnu.org/licenses/gpl.txt>
//
// This program is free software; you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation; either version 2 of the License, or
// (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with this program; if not, write to the Free Software
// Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307 USA
using System;
using System.Net;
using System.Net.Sockets;

namespace Smuxi.Engine
{
    public class TorChatListener
    {
        TcpListener Listener { get; set; }

        public TorChatListener()
        {
        }

        public void Start(int port)
        {
            Listener = new TcpListener(IPAddress.Loopback, port);
            Listener.Start();
            Listener.BeginAcceptTcpClient((ar) => {
                var client = Listener.EndAcceptTcpClient(ar);
                new TorChatInConnection(client);
            }, null);
        }

        public void Stop()
        {
            Listener.Stop();
        }
    }
}
