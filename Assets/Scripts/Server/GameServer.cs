using System;
using System.Collections.Generic;
using UnityEngine;

public class GameServer : IServerAdapter
{
    public GameServer(Database database)
    {
        Database = database;

        BattleHandler = new BattleHandler(this);
        AbilityHandler = new AbilityHandler(this);
        EffectHandler = new EffectHandler(this);
    }
    
    public Action<string> OnResponseHandler { get; set; }

    private Dictionary<RequestType, Handler> _abilityHandlers = new();
    
    public Database Database { get; set; } // Симуляция базы данных
    public BattleHandler BattleHandler { get; private set; }
    public AbilityHandler AbilityHandler { get; private set; }
    public EffectHandler EffectHandler { get; private set; }

    public void HandleRequest(string request)
    {
        //Debug.Log($"Сервер получил запрос: {request}");
        
        var requestJson = JsonUtility.FromJson<RequestEvent>(request);
        
        if (!_abilityHandlers.ContainsKey(requestJson._requestType))
        {
            Handler handler = CreateHandlerForRequest(requestJson._requestType);
            _abilityHandlers[requestJson._requestType] = handler;
        }

        _abilityHandlers[requestJson._requestType].Handle(requestJson._data);
    }

    public void SendResponse(RequestType requestType, object data)
    {
        var jsonData = JsonUtility.ToJson(data);
        ResponseEvent responseEvent = new ResponseEvent(requestType, jsonData);
        
        string response = JsonUtility.ToJson(responseEvent);
        
        //Debug.Log($"Сервер отправил ответ: {response}");
        
        OnResponseHandler?.Invoke(response);
    }

    private Handler CreateHandlerForRequest(RequestType requestType)
    {
        return requestType switch
        {
            RequestType.UseAbility => AbilityHandler,
            RequestType.BattleAction => BattleHandler,
            _ => throw new InvalidOperationException("Неизвестный тип запроса")
        };
    }
}