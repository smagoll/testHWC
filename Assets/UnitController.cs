using UnityEngine;

public class UnitController : MonoBehaviour
{
    private string _name;
    private int _health;
    private Ability[] _abilities;
    
    public void Init(GameUnit gameUnit)
    {
        _name = gameUnit.name;
        _health = gameUnit.health;
        _abilities = gameUnit.abilities;
    }
}