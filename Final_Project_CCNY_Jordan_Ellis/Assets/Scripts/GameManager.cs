using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI answerScoreText;
    public int answerScore = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        answerScoreText.text = "Score: " + answerScore;
    }

    public void Answer()
    {
        answerScore++;
    }
}
