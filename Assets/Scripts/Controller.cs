using UnityEngine;

public class Controller : MonoBehaviour
{
    [SerializeField]
    private UnitController unitControllerPrefab;

    private Unit unit = new("Default", 30, new Ability[] { new Attack() });
    
    protected Player _player;
    
    public void Init(Player player)
    {
        _player = player;
        
        SpawnUnit();
    }

    private void SpawnUnit()
    {
        var unitController = Instantiate(unitControllerPrefab, transform);
        unitController.Init(unit);
    }
}