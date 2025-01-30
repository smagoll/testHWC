using System;

public class FireBallCommand : AbilityCommand
{
    public override void Action(Guid playerId, Guid targetId)
    {
        
    }

    public FireBallCommand(GameServer gameServer) : base(gameServer)
    {
    }
}