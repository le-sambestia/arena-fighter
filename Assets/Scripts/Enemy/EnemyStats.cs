using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : CharacterStats
{
    public override void Die()
    {
        currentHealth = 0;
        Destroy(gameObject);
    }
}
