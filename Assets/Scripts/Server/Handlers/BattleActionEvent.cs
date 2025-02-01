public struct BattleActionEvent
{
    public BattleActionType battleActionType;
    public BattleState battleState;

    public BattleActionEvent(BattleActionType battleActionType) : this(battleActionType, new BattleState())
    {
    }

    public BattleActionEvent(BattleActionType battleActionType, BattleState battleState)
    {
        this.battleActionType = battleActionType;
        this.battleState = battleState;
    }
}