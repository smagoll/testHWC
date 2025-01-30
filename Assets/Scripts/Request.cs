
using System;
using UnityEngine;

[Serializable]
public class Request<T> where T : GameEvent
{
    public RequestType _requestType;
    public string _data;

    public Request(RequestType requestType, T data)
    {
        _requestType = requestType;
        _data = JsonUtility.ToJson(data);
    }

    public string GetJson()
    {
        return JsonUtility.ToJson(this);
    }
}