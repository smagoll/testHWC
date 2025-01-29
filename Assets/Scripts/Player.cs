public class Player
{
    private readonly IServerAdapter _serverAdapter;
    
    public Player(IServerAdapter serverAdapter)
    {
        _serverAdapter = serverAdapter;
    }

    public void SendRequest(IGameEvent gameEvent)
    {
        _serverAdapter.SendRequest(gameEvent);
    }
}