using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameState CurrentState = GameState.MAIN_MENU;
    public string[] SceneNames;

    public static GameManager instance;

    public enum GameState
    {
        MAIN_MENU,
        CAR_SELECTION,
        GAME,
        CREDITS,
        END
    }

    public static int GamepadCount;
    public SpawnPlayers spawnPlayers;

    void Start()
    {
    }

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
        var joystickCount = Input.GetJoystickNames().Length;
        GamepadCount = joystickCount;
    }

    void Update()
    {
        if(CurrentState == GameState.END)
        {
            Application.Quit();
        }


        SceneHandling();
    }

    void SceneHandling()
    {
        var ActualSceneName = SceneManager.GetActiveScene().name;

        if (ActualSceneName == "CarSelection") {
            FindSpawner();
        }

        try {
            if (ActualSceneName != SceneNames[(int)CurrentState])
            {
                SceneManager.LoadScene(SceneNames[(int)CurrentState]);
               // SceneManager.SetActiveScene(SceneManager.GetSceneByName(SceneNames[(int)CurrentState]));

                //SceneManager.UnloadSceneAsync(ActualSceneName);
            }
        } catch (System.IndexOutOfRangeException) {}
    }

    void FindSpawner() {
        if (this.spawnPlayers == null) {
            this.spawnPlayers = GameObject.FindGameObjectWithTag("PlayerSpawner").GetComponent<SpawnPlayers>();
        }
    }
}
