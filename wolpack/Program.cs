using System;
using System.IO;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace wolpack
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Started");

      // This constructor arbitrarily assigns the local port number.
      using (var udpClient = new UdpClient(7))
      try
      {
        udpClient.Connect(IPAddress.Broadcast, 7);

        byte[] sendBytes = new byte[]
        {
          0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF,  // Magic Scan start
          0x02, 0x15, 0x76, 0xC5, 0x4B, 0x77   // MAC Address
        };

        udpClient.Send(sendBytes, sendBytes.Length);

      } catch (Exception e ) {
        Console.WriteLine(e.ToString());
      }

      Console.WriteLine("Ended");
    }
  }
}

