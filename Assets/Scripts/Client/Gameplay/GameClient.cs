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
        //Debug.Log($"Клиент отправил запрос: {request}");
        
        _serverAdapter.HandleRequest(request);
    }
}