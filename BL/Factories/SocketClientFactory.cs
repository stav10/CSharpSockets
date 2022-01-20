﻿using System.Net;
using System.Net.Sockets;
using BL.Abstractions;
using BL.Sockets;

namespace BL.Factories
{
    public class SocketClientFactory
    {
        public SocketClientFactory(string ip, int port)
        {
            IP = ip;
            Port = port;
        }

        public string IP { get; set; }
        public int Port { get; set; }

        public (IConnectionClient<byte[]>, IPEndPoint) Create()
        {
            var socket = new Socket(SocketType.Stream, ProtocolType.Tcp);
            var ipEndPoint = new IPEndPoint(IPAddress.Parse(IP), Port);
            return (new SocketClient(socket), ipEndPoint);
        }
    }
}
