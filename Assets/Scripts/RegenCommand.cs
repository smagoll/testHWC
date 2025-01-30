using System;

public class RegenCommand : AbilityCommand
{
    public override void Action(Guid playerId, Guid targetId)
    {
        
    }

    public RegenCommand(GameServer gameServer) : base(gameServer)
    {
    }
}