﻿using System.Net;
using System.Net.Sockets;
using BL.Abstractions;
using BL.Sockets;

namespace BL.Factories
{
    public class SocketServerFactory
    {
        public SocketServerFactory(int port)
        {
            Port = port;
        }

        public int Port { get; set; }

        public IConnectionServer<byte[]> Create()
        {
            var socket = new Socket(SocketType.Stream, ProtocolType.Tcp);
            var ipEndPoint = new IPEndPoint(IPAddress.Any, Port);
            return new SocketServer(socket, ipEndPoint);
        }
    }
}