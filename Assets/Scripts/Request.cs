using System;
using Unity.VisualScripting;
using UnityEngine;

[Serializable]
public class Request<T> where T : GameEvent
{
    public string _requestType;
    public string _data;

    public Request(string requestType, T data)
    {
        _requestType = requestType;
        _data = JsonUtility.ToJson(data);
    }

    public string GetJson()
    {
        return JsonUtility.ToJson(this);
    }
}