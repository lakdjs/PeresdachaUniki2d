using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;

public class ScoreView : MonoBehaviour, IDisposable
{
    [SerializeField] private TextMeshProUGUI scoreText;
    private Score _score;

    [Inject]
    private void Construct(Score score)
    {
        _score = score;
        _score.OnScoreChange += RefreshScoreText;
        scoreText.text = $"score: {_score.ScoreValue}";
    }

    private void RefreshScoreText(int curScore)
    {
        scoreText.text = $"score: {curScore}";
    }

    public void Dispose()
    {
        _score.OnScoreChange -= RefreshScoreText;
    }
}
