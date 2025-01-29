public abstract class Ability
{
    public string Name { get; protected set; }
    public int Cooldown { get; protected set; }
    public int CurrentCooldown { get; private set; }

    public void Activate(UnitController user, UnitController target)
    {
        
    }

    public void ReduceCooldown()
    {
        if (CurrentCooldown > 0)
            CurrentCooldown--;
    }

    public bool IsReady() => CurrentCooldown == 0;

    protected void StartCooldown()
    {
        CurrentCooldown = Cooldown;
    }
}