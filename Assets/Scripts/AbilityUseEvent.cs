using System;

[Serializable]
public class  AbilityUseEvent : GameEvent
{
    public AbilityType _abilityType;
    public string _playerId;
    public string _targetId;

    public AbilityUseEvent(AbilityType abilityType, string playerId, string targetId)
    {
        _abilityType = abilityType;
        _playerId = playerId;
        _targetId = targetId;
    }
}