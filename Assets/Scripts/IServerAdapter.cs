using System;

public interface IServerAdapter
{
    public Action<string> OnResponseHandler { get; set; }
    public void HandleRequest(string request);
    public void SendResponse(ResponseEvent responseEvent);
}