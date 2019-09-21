using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameState CurrentState = GameState.MAIN_MENU;
    public string[] SceneNames;

    static GameManager instance;

    public enum GameState
    {
        MAIN_MENU,
        CAR_SELECTION,
        GAME,
        CREDITS,
        END
    }

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

        if (ActualSceneName != SceneNames[(int)CurrentState])
        {
            SceneManager.LoadScene(SceneNames[(int)CurrentState]);
            SceneManager.SetActiveScene(SceneManager.GetSceneByName(SceneNames[(int)CurrentState]));

            //SceneManager.UnloadSceneAsync(ActualSceneName);
        }
    }
}
