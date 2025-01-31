using System;

public class ServerAdapter : IServerAdapter
{
    private IServerAdapter _server;

    public Database Database { get; set; }

    public Action<string> OnResponseHandler
    {
        get => _server.OnResponseHandler;
        set => _server.OnResponseHandler = value;
    }

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

        Database = _server.Database;
    }
}