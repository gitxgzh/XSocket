using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace XSocket.Common
{
    public static class SocketExt
    {
        public static void SafeClose(this Socket client)
        {
            if (client == null)
            {
                return;
            }

            try
            {
                if (client.Connected)
                {
                    client.Shutdown(SocketShutdown.Both);
                }
            }
            catch  
            { 
            }

            try
            {
                client.Close();
            }
            catch
            {
            }
        }


        public static int SendData(this Socket clinet, byte[] buffer)
        {
            return SendData(clinet, buffer, 0, buffer.Length);
        }

        /// <summary>
        /// sends the data
        /// </summary>
        /// <param name="clinet"></param>
        /// <param name="buffer"></param>
        /// <param name="offset"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static int SendData(this Socket clinet, byte[] buffer, int offset, int length)
        {
            int sent = 0;
            while (length > sent)
            {
                sent += clinet.Send(buffer, offset + sent, length - sent, SocketFlags.None);
            }

            return sent;
        }
    }
}
