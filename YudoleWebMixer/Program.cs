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

// var deviceEnum = new MMDeviceEnumerator();
//
// foreach (var device in deviceEnum.EnumerateAudioEndPoints(DataFlow.All, DeviceState.Active))
// {
//     foreach (var session in device.AudioSessionManager2.Sessions)
//     {
//         if (session.State == AudioSessionState.AudioSessionStateActive)
//         {
//             Console.WriteLine($"SESSION: {session.DisplayName}");
//             var p = Process.GetProcessById((int)session.ProcessID);
//             Console.WriteLine($"PID: {session.ProcessID.ToString()}");
//             Console.WriteLine($"ProcessName: {p.ProcessName}");
//             Console.WriteLine($"MainWindowTitle: {p.MainWindowTitle}");
//             Console.WriteLine("==============================");
//
//             if (session.ProcessID == 25696)
//             {
//                 Console.WriteLine(session.SimpleAudioVolume.MasterVolume = 1.0F);
//             }
//         }
//     }
// }
//
// Console.ReadKey();