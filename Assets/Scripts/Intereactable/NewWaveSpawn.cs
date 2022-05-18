using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class NewWaveSpawn : Interactable
{
    public override void OnFocus()
    {
        Debug.Log("Looking at " + gameObject.name);
    }

    public override void OnInterect()
    {
        if(enemyCount.EnemyList.Count ==0)
        {
            SwitchScene();
        }
        else
        {
            Debug.Log("Please kill all enemies");
        }
        Debug.Log("Interacted with " + gameObject.name);
    }

    public override void OnLoseFocus()
    {
        Debug.Log("Stopped looking at " + gameObject.name);
    }

    //public GameObject home;
    int currentDifficulty = 0;
    /* difficulties:
    * easy = 0
    * med = 1
    * hard = 2*/

    Scene currentArena;
    public int randomArena;
    EnemyCoun enemyCount;
    public SceneList[] difficulty = new SceneList[] { };
    [System.Serializable]
    public struct SceneList
    {
        public List<int> arenas;
    }
    private void Start()
    {
        StartCoroutine(LoadScene());
    }
    public void SwitchScene()
    {
        SceneManager.UnloadSceneAsync(difficulty[currentDifficulty].arenas[randomArena]);
        difficulty[currentDifficulty].arenas.RemoveAt(randomArena);
        if (difficulty[currentDifficulty].arenas.Count == 0)
        {
            LoadNextDifficulty();
        }
        StartCoroutine(LoadScene());
    }
    public IEnumerator LoadScene()
    {
        currentDifficulty = 0;
        randomArena = Random.Range(0, difficulty[currentDifficulty].arenas.Count - 1);
        currentArena = SceneManager.GetSceneByBuildIndex(difficulty[currentDifficulty].arenas[randomArena]);
        SceneManager.LoadScene(difficulty[currentDifficulty].arenas[randomArena], LoadSceneMode.Additive);
        enemyCount = gameObject.GetComponent<EnemyCoun>();
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("MainScene"));
        yield return new WaitForSeconds(1);
        enemyCount.FindEnemies();
    }
    //public void BossSwitchScene()
    //{
    //    SceneManager.LoadScene(RoomController.instance.currentWorldName + "Boss", LoadSceneMode.Additive);
    //    room = GameManager.RoomCont;
    //    room.SetActive(false);
    //}
    //public void MapSwitchScene()
    //{
    //    SceneManager.UnloadSceneAsync("Rewards");
    //    room = GameManager.RoomCont;
    //    room.SetActive(true);
    //}

    public void LoadNextDifficulty()
    {
        currentDifficulty += 1;
        //roomcontroller.instance.currentworldname = currentDifficulty.();
        //scenemanager.loadscene(roomcontroller.instance.currentworldname + "main");
    }
    //public void ResetGame()
    //{
    //    SceneManager.LoadScene("MainScene");
    //}
}
