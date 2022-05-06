using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    //public GameObject home;
    int currentDifficulty = 0;
    /* difficulties:
    * easy = 0
    * med = 1
    * hard = 2*/

    Scene currentArena;
    public int randomArena;
    public SceneList[] difficulty = new SceneList[] { };
    [System.Serializable]
    public struct SceneList
    {
        public List<int> arenas;
    }
    private void Start()
    {
        currentDifficulty = 0;
        randomArena = Random.Range(0, difficulty[currentDifficulty].arenas.Count - 1);
        currentArena = SceneManager.GetSceneByBuildIndex(difficulty[currentDifficulty].arenas[randomArena]);
        SceneManager.LoadScene(difficulty[currentDifficulty].arenas[randomArena], LoadSceneMode.Additive);
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("MainScene"));
    }
    private void Update()
    {
        SwitchScene();
    }
    public void SwitchScene()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            
            SceneManager.UnloadSceneAsync(difficulty[currentDifficulty].arenas[randomArena]);
            difficulty[currentDifficulty].arenas.RemoveAt(randomArena); 
            if (difficulty[currentDifficulty].arenas.Count == 0)
            {
                LoadNextDifficulty();
            }
            randomArena = Random.Range(0, difficulty[currentDifficulty].arenas.Count - 1);
            currentArena = SceneManager.GetSceneByBuildIndex(difficulty[currentDifficulty].arenas[randomArena]);
            SceneManager.LoadScene(difficulty[currentDifficulty].arenas[randomArena], LoadSceneMode.Additive);
            SceneManager.SetActiveScene(SceneManager.GetSceneByName("MainScene"));
            
        }
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
    //    SceneManager.LoadScene("1Main");
    //room = GameManager.RoomCont;
    //}
}