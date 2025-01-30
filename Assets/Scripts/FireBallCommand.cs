using System;

public class FireBallCommand : AbilityCommand
{
    public override void Action(string playerId, string targetId)
    {
        
    }

    public FireBallCommand(GameServer gameServer) : base(gameServer)
    {
    }
}