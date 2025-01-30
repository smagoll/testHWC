
using System;
using UnityEngine;

[Serializable]
public class RequestEvent
{
    public RequestType _requestType;
    public string _data;

    public RequestEvent(RequestType requestType, string data)
    {
        _requestType = requestType;
        _data = data;
    }

    public string GetJson()
    {
        return JsonUtility.ToJson(this);
    }
}