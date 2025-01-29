public interface IServerAdapter
{
    public void HandleRequest<T>(T gameEvent);
}