using System;
using UnityEngine;

public abstract class Controller : MonoBehaviour
{
    [SerializeField]
    private UnitController unitControllerPrefab;

    private GameUnit _selfUnit;
    private GameUnit _enemyUnit;
    
    protected BattleSystem _battleSystem;

    private UnitController unitController;

    public GameUnit SelfUnit => _selfUnit;
    public UnitController UnitController => unitController;
    
    public bool IsTurn { get; set; }
    
    public void Init(BattleSystem battleSystem, GameUnit player, GameUnit enemy)
    {
        _battleSystem = battleSystem;
        _selfUnit = player;
        _enemyUnit = enemy;

        battleSystem.OnSwitchTurn += CheckTurn;
        
        SpawnUnit();
        
        CheckTurn();
    }

    private void CheckTurn()
    {
        if (IsTurn)
        {
            OnStartTurn();
        }
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
            _battleSystem.UseAbility(abilityType, _selfUnit.id, _enemyUnit.id);
            OnEndTurn();
        }
    }
}