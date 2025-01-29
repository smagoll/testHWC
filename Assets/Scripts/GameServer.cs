using System;
using System.Collections.Generic;
using UnityEngine;

public class GameServer : IServerAdapter
{
    public Action<string> OnResponseHandler { get; set; }

    private Dictionary<string, Handler> _abilityHandlers = new();
    
    public void HandleRequest(string request)
    {
        var requestJson = JsonUtility.FromJson<Request<GameEvent>>(request);
        // Если обработчик для этого типа не существует, создаем его
        if (!_abilityHandlers.ContainsKey(requestJson._requestType))
        {
            Handler handler = CreateHandlerForRequest(requestJson._requestType);
            _abilityHandlers[requestJson._requestType] = handler;
        }

        _abilityHandlers[requestJson._requestType].Handle(request);
    }

    public void SendResponse(ResponseEvent responseEvent)
    {
        string response = JsonUtility.ToJson(responseEvent);
        OnResponseHandler?.Invoke(response);
    }

    private Handler CreateHandlerForRequest(string requestType)
    {
        switch (requestType)
        {
            case "use_ability":
                return new AbilityHandler(this);
            case "start_battle":
                return new BattleHandler(this);
            default:
                throw new InvalidOperationException("Неизвестный тип запроса");
        }
    }
}