using System;
using System.Linq;
using System.Threading;
using UnityEngine;
using UnityEngine.Serialization;

[Serializable]
public class Battle
{
    private AiPlayer _aiPlayer;
    
    public Action OnSwitchState;
    
    private GameUnit player;
    private GameUnit enemy;
    private GameUnit[] units;

    public GameUnit Player => player;
    public GameUnit Enemy => enemy;

    private CancellationTokenSource cts;

    public Battle(GameUnit player, GameUnit enemy)
    {
        this.player = player;
        this.enemy = enemy;

        cts = new();
        
        player.IsTurn = true;
        Debug.Log("Player:");
        
        _aiPlayer = new AiPlayer(enemy, player);
        
        OnSwitchState += UpdateAbilities;
        OnSwitchState += AiStart;

        units = new[] { player, enemy };
    }
    
    public GameUnit GetUnit(string id)
    {
        return units.FirstOrDefault(x => x.Id == id);
    }

    public void SwitchState()
    {
        player.IsTurn = !player.IsTurn;
        enemy.IsTurn = !enemy.IsTurn;
        
        if (player.IsTurn) Debug.Log("Player:");
        if (enemy.IsTurn) Debug.Log("Ai:");
    }

    private void UpdateAbilities()
    {
        if (player.IsTurn)
        {
            foreach (var ability in player.Abilities)
            {
                ResponseEventBus.UpdateAbilityResponse?.Invoke(player.Id, ability.AbilityType, ability.Cooldown);
            }
        }
    }

    public BattleState GetBattleState()
    {
        var playerInfo = GetUnitInfo(player);
        var enemyInfo = GetUnitInfo(enemy);

        return new BattleState(playerInfo, enemyInfo);
    }

    private GameUnitInfo GetUnitInfo(GameUnit gameUnit)
    {
        var abilities = gameUnit.Abilities
            .Select(x => new AbilityInfo(x.AbilityType, x.Title, x.Cooldown))
            .ToArray();

        return new GameUnitInfo(gameUnit.Id, gameUnit.Health, abilities, gameUnit.IsTurn);
    }

    private void AiStart()
    {
        _aiPlayer.OnStart(cts);
    }

    public void End()
    {
        OnSwitchState -= UpdateAbilities;
        OnSwitchState -= AiStart;
        
        cts?.Cancel();
    }
}

