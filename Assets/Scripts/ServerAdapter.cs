using System;

public class ServerAdapter : IServerAdapter
{
    private IServerAdapter _server;
    
    public Action<string> OnResponseHandler { get; set; }
    public void HandleRequest(string request)
    {
        _server.HandleRequest(request);
    }

    public void SendResponse(ResponseEvent responseEvent)
    {
        _server.SendResponse(responseEvent);
    }

    public ServerAdapter(IServerAdapter server)
    {
        _server = server;
    }
}