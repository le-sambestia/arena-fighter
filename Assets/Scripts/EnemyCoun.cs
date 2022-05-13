using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCoun : MonoBehaviour
{
    public int Enemies;
    public List<GameObject> EnemyList = new List<GameObject>();

    // Update is called once per frame
    public void FindEnemies()
    {
        EnemyList.Clear();
        foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            EnemyList.Add(enemy);
            Enemies = EnemyList.Count;
        }
    }
}
