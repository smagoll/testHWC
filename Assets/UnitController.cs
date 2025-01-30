using UnityEngine;

public class UnitController : MonoBehaviour
{
    private string _name;
    private int _health;
    private Ability[] _abilities;
    
    public void Init(Unit unit)
    {
        _name = unit.name;
        _health = unit.health;
        _abilities = unit.abilities;
    }
}