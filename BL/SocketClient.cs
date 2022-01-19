﻿using System;
using System.Net.Sockets;
using Common.Abstractions;
using BL.Abstractions;

namespace BL
{
    public class SocketClient: ISocketClient<byte[]>
    {
        private readonly Socket _socket;

        public SocketClient(
                        IInput<string> input,
                        IOutput output,
                        IConvertor<string, byte[]> sendConvertor,
                        IConvertor<byte[], string> reciveConvertor,
                        Socket socket)
        {
            _socket = socket;
        }

        public byte[] Receive()
        {
            int length = ReciveLength();
            var buffer = new byte[length];
            _socket.Receive(buffer, 4, length, SocketFlags.None);
            return buffer;
        }

        public void Send(byte[] buffer)
        {
            _socket.Send(BitConverter.GetBytes(buffer.Length));
            _socket.Send(buffer);
        }

        private int ReciveLength()
        {
            var lengthChunk = new byte[4];
            _socket.Receive(lengthChunk);
            return BitConverter.ToInt32(lengthChunk);
        }
    }
}
