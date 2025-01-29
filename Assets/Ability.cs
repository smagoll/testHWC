public abstract class Ability
{
    public AbilityType AbilityType { get; protected set; }
    public string Name { get; protected set; }
    public int Cooldown { get; protected set; }
    public int CurrentCooldown { get; private set; }

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