using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTracker : MonoBehaviour
{
    public string totalScore;
    public string trickScoreCurrent;
    private int scoreNum = 0;
    private int tempScoreNum = 0;
    public Text score;
    public Text currentTrickScore;
    // Start is called before the first frame update
    void Start()
    {
        score.text = totalScore;
    }

    // Update is called once per frame
    void Update()
    {
        score.text = totalScore + scoreNum;
        scoreMultiplier();

    }

    private void trickScores()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            tempScoreNum+=10;
        }
        else if(Input.GetKeyDown(KeyCode.K))
        {
            tempScoreNum+=20;
        }
        scoreNum+=tempScoreNum;
    }

    private void airTimeCalculator()
    {
        
    }

    private void scoreMultiplier()
    {
        trickScores();
        airTimeCalculator();
        tempScoreNum=0;
    }
}
