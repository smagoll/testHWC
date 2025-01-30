using System;

[Serializable]
public class Ability
{
    public Action<Ability> OnUpdateState;
    
    public AbilityType abilityType;
    public string name;
    public int damage;
    public int cooldown;
    public int currentCooldown;
    public AbilityEffectType[] effects;

    public bool IsReady
    {
        get => currentCooldown <= 0;
        private set { }
    }

    public Ability(AbilityType abilityType, string name, int damage, int cooldown, AbilityEffectType[] effects)
    {
        this.name = name;
        this.cooldown = cooldown;
        this.effects = effects;
    }

    public void ReduceCooldown()
    {
        if (currentCooldown > 0)
        {
            currentCooldown--;
        }
        else
        {
            if (IsReady == false)
            {
                IsReady = true;
            }
        }
        
        //OnUpdateState?.Invoke(this);
    }

    public void Use()
    {
        if (IsReady)
        {
            IsReady = false;
            currentCooldown = cooldown;
            OnUpdateState?.Invoke(this);
        }
    }
}