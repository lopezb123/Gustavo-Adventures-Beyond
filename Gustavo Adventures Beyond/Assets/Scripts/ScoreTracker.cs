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

        //We can't put airTimeCalculator into update or fixed update because
        //then it won't add 5 points for every second of airtime, it will add for every frame of airtime
        InvokeRepeating("airTimeCalculator", 0, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        score.text = totalScore + scoreNum;
        scoreMultiplier();
    }

    private void trickScores()
    {
        bool tempBool = GameObject.FindGameObjectWithTag("Skateboard").GetComponent<BoardController>().getIsGrounded();
        if (Input.GetKeyDown(KeyCode.Space) && tempBool)
        {
            tempScoreNum += 10;
        }
        else if (Input.GetKeyDown(KeyCode.K))
        {
            tempScoreNum += 20;
        }
        scoreNum += tempScoreNum;
    }

    private void airTimeCalculator()
    {
        bool tempBool = GameObject.FindGameObjectWithTag("Skateboard").GetComponent<BoardController>().getIsGrounded();
        if (tempBool == false)
        {
     
            tempScoreNum += 5;
        }
    }

    private void scoreMultiplier()
    {
        trickScores();
        tempScoreNum = 0;
    }

}
