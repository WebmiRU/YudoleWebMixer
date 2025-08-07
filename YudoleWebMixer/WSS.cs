using System.Text.Json;
using WebSocketSharp;
using WebSocketSharp.Server;

namespace YudoleWebMixer;

public class WSS : WebSocketBehavior
{
    protected override void OnMessage(MessageEventArgs e)
    {
        var message = JsonDocument.Parse(e.Data);
        var type = message.RootElement.GetProperty("type").GetString();
        Console.WriteLine($"TYPE: {type}");

        string? response = null;

        switch (type)
        {
            case "version.get":
                response = JsonSerializer.Serialize(new Version());
                break;

            case "applications.get":
                Applications.Get();
                response = JsonSerializer.Serialize(new ApplicationsGet
                {
                    Applications = Applications.Get()
                });

                break;
        }

        if (response != null) Send(response);
    }
}