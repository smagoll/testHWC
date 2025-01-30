
using System;
using UnityEngine;

[Serializable]
public class RequestEvent
{
    public RequestType _requestType;
    public string _data;

    public RequestEvent(RequestType requestType, object data)
    {
        _requestType = requestType;
        _data = JsonUtility.ToJson(data);
    }

    public string GetJson()
    {
        return JsonUtility.ToJson(this);
    }
}