using UnityEngine;
using UnityEngine.Serialization;

public class BattleSpawner : MonoBehaviour
{
    [SerializeField]
    private UISystem uiSystem;
    
    [SerializeField]
    private Controller controller;
    [SerializeField]
    private Controller aiController;

    public void SpawnBattle(GameClient gameClient, GameUnit player, GameUnit enemy)
    {
        controller.Init(gameClient, player, enemy);
        aiController.Init(gameClient, enemy, player);
        
        uiSystem.AbilityPanel.Init(controller);
    }
}