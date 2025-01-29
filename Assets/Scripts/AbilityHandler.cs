public class AbilityHandler : Handler
{
    public AbilityHandler(IServerAdapter serverAdapter) : base(serverAdapter)
    {
    }
    
    public override void Handle(string request)
    {
        var abilityEvent = request;
    }
}