using System;
using System.Collections.Generic;
using UnityEngine;

public class GameServer : IServerAdapter
{
    public Action<string> OnResponseHandler { get; set; }

    private Dictionary<RequestType, Handler> _abilityHandlers = new();
    
    public void HandleRequest(string request)
    {
        Debug.Log($"Сервер получил запрос: {request}");
        
        var requestJson = JsonUtility.FromJson<RequestEvent>(request);
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
        
        Debug.Log($"Сервер отправил ответ: {response}");
        
        OnResponseHandler?.Invoke(response);
    }

    private Handler CreateHandlerForRequest(RequestType requestType)
    {
        return requestType switch
        {
            RequestType.UseAbility => new AbilityHandler(this),
            RequestType.StartBattle => new BattleHandler(this),
            _ => throw new InvalidOperationException("Неизвестный тип запроса")
        };
    }
}