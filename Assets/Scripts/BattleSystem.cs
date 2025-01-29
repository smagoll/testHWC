using UnityEngine;
using UnityEngine.Serialization;

public class BattleSystem : MonoBehaviour
{
    [SerializeField]
    private Controller controller;
    [SerializeField]
    private Controller aiController;

    public void SpawnBattle(Player player, Player enemy)
    {
        controller.Init(player);
        aiController.Init(player);
    }
}