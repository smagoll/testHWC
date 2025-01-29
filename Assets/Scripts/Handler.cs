public abstract class Handler
{
    protected IServerAdapter _serverAdapter;
    
    public Handler(IServerAdapter serverAdapter)
    {
        _serverAdapter = serverAdapter;
    }
    public abstract void Handle(string request);
}