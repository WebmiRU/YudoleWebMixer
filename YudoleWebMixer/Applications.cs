using System.Diagnostics;
using CoreAudio;

namespace YudoleWebMixer;

public static class Applications
{
    public static List<Application> Get()
    {
        var apps = new List<Application>();
        var deviceEnum = new MMDeviceEnumerator();

        foreach (var device in deviceEnum.EnumerateAudioEndPoints(DataFlow.All, DeviceState.Active))
        foreach (var session in device.AudioSessionManager2.Sessions)
            if (session.State == AudioSessionState.AudioSessionStateActive)
            {
                var p = Process.GetProcessById((int)session.ProcessID);

                apps.Add(new Application
                {
                    PID = session.ProcessID,
                    Process = p.ProcessName,
                    Name = session.DisplayName,
                    Title = p.MainWindowTitle,
                    Volume = (int)(session.SimpleAudioVolume.MasterVolume * 100)
                });
            }

        return apps;
    }
}