using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using UnityEngine;
using System.Threading;
using Unity.VisualScripting;

public class ReceiverColoring : SingletonDontDestroy<Receiver>
{
    Thread mThread;
    public string connectionIP = "127.0.0.2";
    public int connectionPort = 25002;
    IPAddress localAdd;
    TcpListener listener;
    TcpClient client;
    public string receivedString = "a";
    public string dataReceived = "";
    bool running;
    protected override void Awake()
    {
        base.Awake();
        GameEvent.OnReturnHome += OnReturnHomeEvent;
    }
    private void Start()
    {
        //StartNewThread();
    }
    private void LateUpdate()
    {
        if(GameManager.Instance.currentGameMode == (GameMode)0)
        {
            if(BreakTheBlockManager.Instance)
                if(receivedString != ".")
                    BreakTheBlockManager.Instance.ProcessData(receivedString);
        }
        else if (GameManager.Instance.currentGameMode == (GameMode)1)
        {
            //if (ColoringManager.Instance)
        }
        else if (GameManager.Instance.currentGameMode == (GameMode)2)
        {
            //BreakTheBlockManager.Instance.OnPressKey(receivedString);
        }
        else
        {
            //do smt
        }
        receivedString = ".";
    }
    private void OnReturnHomeEvent()
    {
        //mThread.Abort();
    }    
    public void StartNewThread()
    {
        ThreadStart ts = new ThreadStart(GetInfo);
        mThread = new Thread(ts);
        mThread.Start();
    }
    private void GetInfo()
    {
        if (!running)
        {
            localAdd = IPAddress.Parse(connectionIP);
            listener = new TcpListener(IPAddress.Any, connectionPort);
            listener.Start();
            client = listener.AcceptTcpClient();
            running = true;
        }          
        while (running)
        {
            if (GameManager.Instance.currentGameMode != GameMode.None) SendAndReceiveData();            
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
            receivedString = ReceiveData(dataReceived);
            byte[] myWriteBuffer = Encoding.ASCII.GetBytes("Hey I got your message Python! Do You see this massage?"); //Converting string to byte data
            nwStream.Write(myWriteBuffer, 0, myWriteBuffer.Length); //Sending the data in Bytes to Python
        }
        else
        {
            dataReceived = ".";
            Debug.Log(dataReceived);
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
    private void OnDestroy()
    {
        GameEvent.OnReturnHome -= OnReturnHomeEvent;
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