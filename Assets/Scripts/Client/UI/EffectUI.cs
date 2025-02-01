using TMPro;
using UnityEngine;

public class EffectUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _titleText;
    [SerializeField]
    private TextMeshProUGUI _durationText;
    
    private AbilityEffectType _abilityEffectType;
    private string _title;
    private int _duration;

    public AbilityEffectType AbilityEffectType => _abilityEffectType;

    public void Init(AbilityEffectType abilityEffectType, string title, int duration)
    {
        _abilityEffectType = abilityEffectType;
        _title = title;
        _duration = duration;
        
        UpdateInfo();
    }

    private void UpdateInfo()
    {
        _titleText.text = _title;
        _durationText.text = _duration.ToString();
    }

    public void UpdateDuration(int duration)
    {
        _durationText.text = duration.ToString();
    }
}
