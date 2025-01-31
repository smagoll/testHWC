using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class UISystem : MonoBehaviour
{
    [FormerlySerializedAs("abilityPanel")] [SerializeField]
    private AbilityPanel _abilityPanel;
    
    public AbilityPanel AbilityPanel => _abilityPanel;
}