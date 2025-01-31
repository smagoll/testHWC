using UnityEngine;

public class UnitController : MonoBehaviour
{
    [SerializeField]
    private HealthBar healthBar;

    private string _id;
    private int _health;

    public string Id => _id;
    
    public void Init(GameUnit gameUnit)
    {
        _id = gameUnit.id;
        _health = gameUnit.health;
        
        UpdateBar();
    }

    public void UpdateHealth(int health)
    {
        _health = health;
        UpdateBar();
    }

    private void UpdateBar() => healthBar.UpdateBar(_health);
}