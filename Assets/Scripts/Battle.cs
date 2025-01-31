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

        _aiPlayer = new AiPlayer(enemy, player);
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
}