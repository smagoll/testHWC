using UnityEngine;
using UnityEngine.Serialization;

public class BattleSystem : MonoBehaviour
{
    [SerializeField]
    private UISystem uiSystem;
    
    [SerializeField]
    private Controller controller;
    [SerializeField]
    private Controller aiController;

    public void SpawnBattle(GameClient gameClient, Unit player, Unit enemy)
    {
        controller.Init(gameClient, player, enemy);
        aiController.Init(gameClient, enemy, player);
        
        uiSystem.AbilityPanel.Init(controller);
    }
}