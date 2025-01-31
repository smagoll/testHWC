using System;
using UnityEngine;

public class PlayerController : Controller
{
    protected override void OnStartTurn()
    {
        _battleSystem.UISystem.AbilityPanel.Show();
    }

    protected override void OnEndTurn()
    {
        _battleSystem.UISystem.AbilityPanel.Hide();
    }
}