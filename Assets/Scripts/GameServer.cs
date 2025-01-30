using System;
using System.Collections.Generic;
using UnityEngine;

public class GameServer : IServerAdapter
{
    public Action<string> OnResponseHandler { get; set; }

    private Dictionary<string, Handler> _abilityHandlers = new();
    
    public void HandleRequest(string request)
    {
        Debug.Log($"Сервер получил запрос: {request}");
        
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
        
        Debug.Log($"Сервер отправил ответ: {response}");
    }

    private Handler CreateHandlerForRequest(string requestType)
    {
        return requestType switch
        {
            "use_ability" => new AbilityHandler(this),
            "start_battle" => new BattleHandler(this),
            _ => throw new InvalidOperationException("Неизвестный тип запроса")
        };
    }
}