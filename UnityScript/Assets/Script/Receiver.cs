using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using UnityEngine;
using System.Threading;

public class Receiver : MonoBehaviour
{
    public static Receiver Instance;
    Thread mThread;
    public string connectionIP = "127.0.0.1";
    public int connectionPort = 25001;
    IPAddress localAdd;
    TcpListener listener;
    TcpClient client;
    public string receivedLetter = "a";
    public string dataReceived = "";
    private int i = 0;
    bool running;
    
    private void LateUpdate()
    {
        //Debug.Log(receivedLetter);
        GameManager.Instance.OnPressKey(receivedLetter);
        //Debug.Log(receivedLetter);
        receivedLetter = ".";
    }

    private void Start()
    {
        ThreadStart ts = new ThreadStart(GetInfo);
        mThread = new Thread(ts);
        mThread.Start();
    }

    void GetInfo()
    {
        localAdd = IPAddress.Parse(connectionIP);
        listener = new TcpListener(IPAddress.Any, connectionPort);
        listener.Start();

        client = listener.AcceptTcpClient();

        running = true;
        while (running)
        {
            SendAndReceiveData();
        }
        listener.Stop();
    }

    void SendAndReceiveData()
    {
        NetworkStream nwStream = client.GetStream();
        byte[] buffer = new byte[client.ReceiveBufferSize];

        //---receiving Data from the Host----
        int bytesRead = nwStream.Read(buffer, 0, client.ReceiveBufferSize); //Getting data in Bytes from Python
        dataReceived = Encoding.UTF8.GetString(buffer, 0, bytesRead); //Converting byte data to string

        if (dataReceived != null)
        {
            receivedLetter = ReceiveData(dataReceived);
            i++;

            byte[] myWriteBuffer = Encoding.ASCII.GetBytes("Hey I got your message Python! Do You see this massage?"); //Converting string to byte data
            nwStream.Write(myWriteBuffer, 0, myWriteBuffer.Length); //Sending the data in Bytes to Python
        }
        else
        {
            dataReceived = ".";
            Debug.Log(Receiver.Instance.dataReceived);
        }
    }

    public static string ReceiveData(string data)
    {
        // Remove the parentheses
        if (data.StartsWith("(") && data.EndsWith(")"))
        {
            data = data.Substring(1, data.Length - 2);
        }

        // split the items
        string[] sArray = data.Split(',');
        string result = sArray[0];
       

        return result;
    }
    /*
    public static string GetLocalIPAddress()
    {
        var host = Dns.GetHostEntry(Dns.GetHostName());
        foreach (var ip in host.AddressList)
        {
            if (ip.AddressFamily == AddressFamily.InterNetwork)
            {
                return ip.ToString();
            }
        }
        throw new System.Exception("No network adapters with an IPv4 address in the system!");
    }
    */
}