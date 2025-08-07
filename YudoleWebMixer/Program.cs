using WebSocketSharp.Server;

namespace YudoleWebMixer;

public class Program
{
    public static void Main(string[] args)
    {
        var wss = new WebSocketServer(8571);

        wss.AddWebSocketService<WSS>("/");
        wss.Start();

        Console.ReadKey(true);
        wss.Stop();
    }
}