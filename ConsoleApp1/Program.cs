using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using XSocket.Common;
namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            SocketInformation socket1;
            
           
            IPAddress iP = new IPAddress(0x100007f);
            IPEndPoint iPEnd = new IPEndPoint(0x0100007f, 8080);

            Task a =  Task.Factory.StartNew(()=>
           {
               socket.Bind(iPEnd);
               socket.Listen(10000);
               socket.Accept();
           }
            );

            socket.SafeClose();
        
        }
    }
}
