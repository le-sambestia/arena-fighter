using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : CharacterStats
{
    public GameObject magicTable;
    public override void Die()
    {
        magicTable = GameObject.Find("Table2");
        EnemyCoun enemyCount = magicTable.GetComponent<EnemyCoun>();
        enemyCount.Enemies -= 1;
        enemyCount.EnemyList.Remove(gameObject);
        currentHealth = 0;
        Destroy(gameObject);
    }
}
