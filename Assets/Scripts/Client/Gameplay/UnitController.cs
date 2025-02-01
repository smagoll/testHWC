using UnityEngine;

public class UnitController : MonoBehaviour
{
    [SerializeField]
    private HealthBar healthBar;

    private string _id;
    private int _health;

    public string Id => _id;
    
    public void Init(GameUnitInfo gameUnitInfo)
    {
        _id = gameUnitInfo.id;
        _health = gameUnitInfo.health;
        
        UpdateBar();
    }

    public void UpdateHealth(int health)
    {
        _health = health;
        UpdateBar();
    }

    private void UpdateBar() => healthBar.UpdateBar(_health);
}