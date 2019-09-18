using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : Subject
{
    public static int score = 0;
    public Observer displayScore;

    private void Start()
    {
        RegisterObserver(displayScore);
    }
    public void UpdateScore(int point)
    {
        score += point;
        Notify(score, NotificationType.ScoreUpdated);
    }
}
