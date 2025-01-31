using System;
using System.Linq;
using UnityEngine.Serialization;

[Serializable]
public class Battle
{
    private AiPlayer _aiPlayer;
    
    public Action OnSwitchState;
    
    public GameUnit player;
    public GameUnit enemy;

    public GameUnit[] units;

    public Battle(GameUnit player, GameUnit enemy)
    {
        this.player = player;
        this.enemy = enemy;

        player.IsTurn = true;
        
        _aiPlayer = new AiPlayer(enemy, player);
        
        OnSwitchState += UpdateAbilities;
        OnSwitchState += _aiPlayer.OnStart;

        units = new[] { player, enemy };
    }
    
    public GameUnit GetUnit(string id)
    {
        return units.FirstOrDefault(x => x.id == id);
    }

    public void SwitchState()
    {
        player.IsTurn = !player.IsTurn;
        enemy.IsTurn = !enemy.IsTurn;
    }

    private void UpdateAbilities()
    {
        if (player.IsTurn)
        {
            foreach (var ability in player.abilities)
            {
                EventBus.UpdateAbility?.Invoke(player.id, ability.abilityType, ability.cooldown);
            }
        }
    }
}

