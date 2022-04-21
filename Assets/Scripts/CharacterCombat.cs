using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterStats))]
public class CharacterCombat : MonoBehaviour
{
    CharacterStats myStats;

    void Start()
    {
        myStats = GetComponent<CharacterStats>();
    }
    public void Attack(CharacterStats targetStats)
    {
        targetStats.ApplyDamage(myStats.damage.GetValue());
    }
}
