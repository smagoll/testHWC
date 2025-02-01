using System;

public interface IServerAdapter
{
    public Database Database { get; set; }
    public Action<string> OnResponseHandler { get; set; }
    public void HandleRequest(string request);
    public void SendResponse(RequestType requestType, object data);
}