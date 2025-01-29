public class ServerAdapter : IServerAdapter
{
    private IServerAdapter _server;
    
    public ServerAdapter(IServerAdapter server)
    {
        _server = server;
    }
    
    public void SendRequest(IGameEvent gameEvent)
    {
        _server.SendRequest(gameEvent);
    }
}