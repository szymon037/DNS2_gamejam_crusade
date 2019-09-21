using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static ulong HighScore = 0;
    public ulong CurrentScore = 0,
        PointsPerSecond = 10;

    float dtime = 0.0f;

    void Start()
    {

    }

    void Update()
    {
        UpdateScoreOverTime();
    }

    public void OnCoinPickUp(int value)
    {
        CurrentScore += (ulong)value;
    }

    public void RecordHighScore()
    {
        if(CurrentScore > HighScore)
        {
            HighScore = CurrentScore;
        }
    }

    public void RestartScore()
    {
        CurrentScore = 0;
        dtime = 0.0f;
    }

    void UpdateScoreOverTime()
    {
        if (dtime < 1.0f)
        {
            dtime += Time.deltaTime;
        }
        else
        {
            CurrentScore += PointsPerSecond;
            dtime = 0.0f;
        }
    }
}
