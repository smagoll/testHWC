using UnityEngine;

public class UISystem : MonoBehaviour
{
    [SerializeField]
    private AbilityPanel abilityPanel;

    public AbilityPanel AbilityPanel => abilityPanel;
}