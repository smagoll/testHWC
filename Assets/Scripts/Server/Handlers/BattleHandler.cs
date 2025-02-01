using System;
using System.Linq;
using UnityEngine;

public class BattleHandler : Handler
{
    private int steps;
    private Battle _battle;

    public Battle Battle => _battle;
    
    public BattleHandler(GameServer gameServer) : base(gameServer)
    {
        ResponseEventBus.UpdateAbilityResponse += SendResponseUpdateAbility;
        ResponseEventBus.UpdateUnitResponse += SendResponseUpdateUnit;
    }

    public override void Handle(string request)
    {
        var battleActionEvent = JsonUtility.FromJson<BattleActionEvent>(request);
        switch (battleActionEvent.battleActionType)
        {
            case BattleActionType.Start:
                StartNewBattle();
                break;
            case BattleActionType.End:
                break;
            case BattleActionType.Restart:
                BattleRestart();
                break;
            case BattleActionType.Update:
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    private void StartNewBattle()
    {
        var player = new GameUnit("Default", 30, GetAbilities());
        var enemy = new GameUnit("Default", 30, GetAbilities());
        _battle = new Battle(player , enemy);
        
        SendBattleStart();
    }

    private void SendBattleStart() => SendBattleAction(BattleActionType.Start);
    private void SendBattleEnd() => SendBattleAction(BattleActionType.End);

    private void BattleRestart()
    {
        _battle.End();
        SendBattleEnd();
        StartNewBattle();
    }
    private void SendBattleUpdate() => SendBattleAction(BattleActionType.Update);

    private void SendBattleAction(BattleActionType battleActionType)
    {
        BattleState battleState = _battle.GetBattleState();
        BattleActionEvent battleActionEvent = new BattleActionEvent(battleActionType, battleState);
        _gameServer.SendResponse(RequestType.BattleAction, battleActionEvent);
    }
    
    public void Step()
    {
        if (_battle.Player.Health > 0 && _battle.Enemy.Health > 0)
        {
            _battle.SwitchState();
            SendBattleUpdate();
            _battle.OnSwitchState?.Invoke();
        }
        else
        {
            BattleRestart();
        }
    }
    
    private void SendResponseUpdateAbility(string id, AbilityType abilityType, int cooldown)
    {
        UpdateAbilityEvent updateAbilityEvent = new UpdateAbilityEvent(id, abilityType, cooldown);
        _gameServer.SendResponse(RequestType.UpdateAbility, updateAbilityEvent);
    }
    
    private void SendResponseUpdateUnit(string id, int health, AbilityEffect[] abilityEffects)
    {
        var abilityEffectsInfo = abilityEffects
            .Select(x => new AbilityEffectInfo(x.AbilityEffectType, x.Title, x.Duration))
            .ToArray();
        
        UpdateUnitEvent updateUnitEvent = new UpdateUnitEvent(id, health, abilityEffectsInfo);
        _gameServer.SendResponse(RequestType.UpdateUnit, updateUnitEvent);
    }

    private Ability[] GetAbilities()
    {
        var abilities = new[]
        {
            _gameServer.Database.GetAbility(AbilityType.Attack),
            _gameServer.Database.GetAbility(AbilityType.Barrier),
            _gameServer.Database.GetAbility(AbilityType.Regen),
            _gameServer.Database.GetAbility(AbilityType.FireBall),
            _gameServer.Database.GetAbility(AbilityType.Purge)
        };

        return abilities;
    }
}