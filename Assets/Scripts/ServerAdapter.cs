public class ServerAdapter : IServerAdapter
{
    private IServerAdapter _server;
    
    public ServerAdapter(IServerAdapter server)
    {
        _server = server;
    }
    
    public void SendRequest(IGameEvent gameEvent)
    {
        _server.HandleRequest(gameEvent);
    }

    public void HandleRequest<T>(T gameEvent)
    {
        _server.HandleRequest (gameEvent);
    }
}