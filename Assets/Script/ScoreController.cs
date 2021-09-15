using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    [Header("Score Highlight")]
    public int scoreHighlightRange;
    public CharSoundController sound;

    private int currentScore = 0;
    private int lastScoreHighlight = 0;
    [Header("Scoring")]
    public ScoreController score;
    public float scoringRatio;
    public float lastPositionX;
    public void IncreaseCurrentScore(int increment)
    {
        currentScore += increment;
        if (currentScore - lastScoreHighlight > scoreHighlightRange)
        {
            sound.PlayScoreHighlight();
            lastScoreHighlight += scoreHighlightRange;
        }
    }

    private void Start()
    {
        // Reset
        currentScore = 0;
        lastScoreHighlight = 0;
    }
    private void Update()
    {

        // calculate score
        int distancePassed = Mathf.FloorToInt(transform.position.x - lastPositionX);
        int scoreIncrement = Mathf.FloorToInt(distancePassed / scoringRatio);

        if (scoreIncrement > 0)
        {
            score.IncreaseCurrentScore(scoreIncrement);
            lastPositionX += distancePassed;
        }
    }

    public float getCurrentScore()
    {
        return currentScore;
    }

    public void increaseCurrentScore(int increment)
    {
        currentScore += increment;

        if (currentScore - lastScoreHighlight > scoreHighlightRange)
        {
           sound.PlayScoreHighlight();
            lastScoreHighlight += scoreHighlightRange;
        }
    }

    public void FinishScoring()
    {
        // Set high score
        if (currentScore > ScoreData.highScore)
        {
            ScoreData.highScore = currentScore;
        }
    }
}