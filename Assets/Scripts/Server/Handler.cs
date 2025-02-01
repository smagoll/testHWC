public abstract class Handler
{
    protected GameServer _gameServer;

    public GameServer GameServer => _gameServer;

    protected Handler(GameServer gameServer)
    {
        _gameServer = gameServer;
    }
    public abstract void Handle(string request);
}