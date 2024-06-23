
using System.Net;
using System.Net.Sockets;
using System.Text;
using UnityEngine;
using System.Threading;

public class Receiver : SingletonDontDestroy<Receiver>
{   
    [SerializeField] private string connectionIP = "127.0.0.1";
    [SerializeField] private int connectionPort = 25001;
    private Thread mThread;
    private IPAddress localAdd;
    private TcpListener listener;
    private TcpClient client;
    public string receivedString = "a";
    public string dataReceived = "";
    private bool isRunning;
    protected override void Awake()
    {
        base.Awake();
    }
    private void LateUpdate()
    {
        ProcessData();
        receivedString = ".";
    }   
    public void StartNewThread()
    {
        ThreadStart ts = new ThreadStart(GetInfo);
        mThread = new Thread(ts);
        mThread.Start();
    }
    private void ProcessData()
    {
        if (GameManager.currentGameMode == (GameMode)0)
        {
            if (BreakTheBlockManager.Instance)
                if (receivedString != ".")
                    BreakTheBlockManager.Instance.ProcessData(receivedString);
        }
        else if (GameManager.currentGameMode == (GameMode)1)
        {
            if (ColoringManager.Instance)
                if (receivedString != ".")
                    ColoringManager.Instance.ProcessData(receivedString);
        }
        else if (GameManager.currentGameMode == (GameMode)2)
        {
            if (QuizManager.Instance)
                if (receivedString != ".")
                    QuizManager.Instance.ProcessData(receivedString);
        }
        else if(GameManager.currentGameMode == (GameMode)3)
        {
            if (LearningManager.Instance)
                if (receivedString != ".")
                    LearningManager.Instance.ProcessData(receivedString);
        }

    }
    private void GetInfo()
    {
        if (!isRunning)
        {
            localAdd = IPAddress.Parse(connectionIP);
            listener = new TcpListener(IPAddress.Any, connectionPort);
            listener.Start();
            client = listener.AcceptTcpClient();
            isRunning = true;
        }          
        while (isRunning)
        {
            if (GameManager.currentGameMode != GameMode.None) SendAndReceiveData();            
        }
        listener.Stop();
    }

    private void SendAndReceiveData()
    {
        NetworkStream nwStream = client.GetStream();
        byte[] buffer = new byte[client.ReceiveBufferSize];
        int bytesRead = nwStream.Read(buffer, 0, client.ReceiveBufferSize); //Getting data in Bytes from Python
        dataReceived = Encoding.UTF8.GetString(buffer, 0, bytesRead); //Converting byte data to string

        if (dataReceived != null)
        {
            receivedString = ResolveData(dataReceived);
            byte[] myWriteBuffer = Encoding.ASCII.GetBytes("Hey I got your message Python! Do You see this massage?"); //Converting string to byte data
            nwStream.Write(myWriteBuffer, 0, myWriteBuffer.Length); //Sending the data in Bytes to Python
        }
        else
        {
            dataReceived = ".";
            Debug.Log(dataReceived);
        }
    }

    private string ResolveData(string data)
    {
        if (data.StartsWith("(") && data.EndsWith(")"))
        {
            data = data.Substring(1, data.Length - 2);
        }
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