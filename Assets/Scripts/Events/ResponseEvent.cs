using System;

[Serializable]
public class ResponseEvent
{
    public RequestType _responseType;
    public string _data;

    public ResponseEvent(RequestType responseType, string data)
    {
        _responseType = responseType;
        _data = data;
    }
}