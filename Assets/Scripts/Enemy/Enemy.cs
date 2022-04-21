using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterStats))]
public class Enemy : Interactable
{
    FirstPersonController playerManager;
    CharacterStats myStats;

    void Start()
    {
        playerManager = FirstPersonController.instance;
        myStats = GetComponent<CharacterStats>();
    }
    public override void OnFocus()
    {

    }

    public override void OnInterect()
    {
        CharacterCombat playerCombat = playerManager.Player.GetComponent<CharacterCombat>();
        if(playerCombat != null)
        {
            playerCombat.Attack(myStats);
        }
    }

    public override void OnLoseFocus()
    {
        
    }
}
