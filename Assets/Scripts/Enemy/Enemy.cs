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
        Debug.Log("Looking at " + gameObject.name);
    }

    public override void OnInterect()
    {
        Debug.Log("Interacted with  " + gameObject.name);
        CharacterCombat playerCombat = playerManager.Player.GetComponent<CharacterCombat>();
        if(playerCombat != null)
        {
            playerCombat.Attack(myStats);
        }
    }

    public override void OnLoseFocus()
    {
        Debug.Log("Stopped looking at " + gameObject.name);
    }
}
