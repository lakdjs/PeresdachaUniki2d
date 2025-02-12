using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score: IDisposable
{
    public const int StartValue = 10;
    private const int EndValue = 0;

    private int _addingScore = 1;
    public int ScoreValue { get; private set; }

    private Obstacle _obstacle;

    public event Action<int> OnScoreChange;

    public Score(Obstacle obstacle)
    {
        _obstacle = obstacle;
        _obstacle.OnAddScore += AddScore;
    }
    public void Dispose()
    {
        _obstacle.OnAddScore -= AddScore;
    }

    public void AddScore()
    {
       
        ScoreValue += _addingScore;
        OnScoreChange?.Invoke(ScoreValue);
        Debug.Log("Add score");
    }

   
}
