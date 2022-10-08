using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoreText;
    public int ballValue;
    private int score;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        scoreText.text = "Score : " + score;
    }
	void OnTriggerEnter2D()
	{
        score = score + ballValue;
        scoreText.text = "Score : " + score;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
