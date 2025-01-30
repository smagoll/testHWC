using System;

[Serializable]
public class  AbilityUseEvent : GameEvent
{
    public Ability _ability;
    public Guid _playerId;
    public Guid _targetId;

    public AbilityUseEvent(Ability ability, Guid playerId, Guid targetId)
    {
        _ability = ability;
        _playerId = playerId;
        _targetId = targetId;
    }
}