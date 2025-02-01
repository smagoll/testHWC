using System;
using UnityEngine;

public abstract class Controller : MonoBehaviour
{
    [SerializeField]
    private UnitController unitControllerPrefab;

    private GameUnitInfo _selfUnit;
    private GameUnitInfo _enemyUnit;
    
    [SerializeField]
    protected BattleSystem _battleSystem;

    private UnitController unitController;

    public GameUnitInfo SelfUnit => _selfUnit;
    public UnitController UnitController => unitController;
    
    public bool IsTurn { get; set; }
    
    public void Init(GameUnitInfo player, GameUnitInfo enemy)
    {
        _selfUnit = player;
        _enemyUnit = enemy;
        
        SpawnUnit();
        
        CheckTurn();
    }

    private void CheckTurn()
    {
        if (IsTurn) OnStartTurn();
    }

    protected abstract void OnStartTurn();
    protected abstract void OnEndTurn();

    private void SpawnUnit()
    {
        unitController = Instantiate(unitControllerPrefab, transform);
        unitController.Init(_selfUnit);
    }

    public void UseAbility(AbilityType abilityType)
    {
        if (IsTurn)
        {
            OnEndTurn();
            _battleSystem.UseAbility(abilityType, _selfUnit.id, _enemyUnit.id);
        }
    }

    public void ResetController()
    {
        Destroy(unitController.gameObject);
    }

    private void OnEnable()
    {
        _battleSystem.OnSwitchTurn += CheckTurn;
    }

    private void OnDisable()
    {
        _battleSystem.OnSwitchTurn -= CheckTurn;
    }
}