using System;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class UISystem : MonoBehaviour
{
    [SerializeField]
    private GameManager gameManager;
    
    [FormerlySerializedAs("abilityPanel")] [SerializeField]
    private AbilityPanel _abilityPanel;
    [SerializeField]
    private Button _restartButton;
    
    public AbilityPanel AbilityPanel => _abilityPanel;

    private void RestartBattle()
    {
        var json = new RequestEvent(RequestType.BattleAction, new BattleActionEvent(BattleActionType.Restart)).GetJson();
        gameManager.SendRequest(json);
    }
    
    private void OnEnable()
    {
        _restartButton.onClick.AddListener(RestartBattle);
    }
    
    private void OnDisable()
    {
        _restartButton.onClick.RemoveListener(RestartBattle);
    }
}