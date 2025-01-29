using System;

[Serializable]
public class ResponseEvent
{
    public string _responseType;
    public string _data;

    public ResponseEvent(string responseType, string data)
    {
        _responseType = responseType;
        _data = data;
    }
}