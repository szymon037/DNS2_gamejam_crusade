using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuFunctions : MonoBehaviour
{
    public void StartGame() {
        GameManager.instance.CurrentState = GameManager.GameState.CAR_SELECTION;
    }

    public void Exit() {
        GameManager.instance.CurrentState = GameManager.GameState.END;
    }
}
