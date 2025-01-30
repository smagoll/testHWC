using System;

public class BarrierCommand : AbilityCommand
{
    public override void Action(Guid playerId, Guid targetId)
    {
        
    }

    public BarrierCommand(GameServer gameServer) : base(gameServer)
    {
    }
}