using UnityEngine;

public class GameClient
{
    private readonly IServerAdapter _serverAdapter;

    public IServerAdapter ServerAdapter => _serverAdapter;
    
    public GameClient(IServerAdapter serverAdapter)
    {
        _serverAdapter = serverAdapter;
    }

    public void SendRequest(string request)
    {
        _serverAdapter.HandleRequest(request);
    }
}