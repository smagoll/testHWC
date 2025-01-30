using UnityEngine;
using UnityEngine.Serialization;

public class BattleSpawner : MonoBehaviour
{
    [FormerlySerializedAs("uiSystem")] [SerializeField]
    private UISystem _uiSystem;
    
    [FormerlySerializedAs("controller")] [SerializeField]
    private Controller _controller;
    [FormerlySerializedAs("aiController")] [SerializeField]
    private Controller _aiController;

    public UISystem UISystem => _uiSystem;

    public void SpawnBattle(GameClient gameClient, GameUnit player, GameUnit enemy)
    {
        _controller.Init(gameClient, player, enemy);
        _aiController.Init(gameClient, enemy, player);
        
        _uiSystem.AbilityPanel.Init(_controller);
    }
}