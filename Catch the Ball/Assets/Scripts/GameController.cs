using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject bowlingBall;
    public float maxWidth;
    public Text timerText;
    public float timeLeft;
    public GameObject startButton;
    public GameObject gameOverText;
    public GameObject restartButton;
    private bool playing;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 upperCorner = new Vector3(Screen.width, Screen.height, 0.0f); 
        Vector3 targetWidth = Camera.main.ScreenToWorldPoint(upperCorner); 
        float ballWidth = bowlingBall.GetComponent<Renderer>().bounds.extents.x / 2; 
        maxWidth = targetWidth.x - ballWidth;
        playing = false;
    }

    public void StartGame()
	{
        playing = true;
        StartCoroutine(Spawn());
        startButton.SetActive(false);
    }

    void FixedUpdate()
	{
		if (playing==true)
		{
            timeLeft = timeLeft - Time.deltaTime; 
            if (timeLeft < 0) 
            { 
                timeLeft = 0; 
            } 
            // Koristi se Mathf.RountToInt kako bi vrijeme bilo bez decimalnih brojeva 
            timerText.text = "Time Left : " + Mathf.RoundToInt(timeLeft);
		}
        
    }
    IEnumerator Spawn()
    { // Čeka 2 sekunde 
        yield return new WaitForSeconds(2.0f); 
        // Beskonačna petlja 
        while (timeLeft>0) { 
            // Određuje poziciju iz koje će se instancirati kugle 
            Vector3 spawnPosition = new Vector3(Random.Range(-maxWidth, maxWidth), transform.position.y, 0.0f); 
            // Za rotaciju se uzima „default“ vrijednost (0, 0, 0, 0) 
            Quaternion spawnRotation = Quaternion.identity; 
            // Instanciranje kugle 
            Instantiate(bowlingBall, spawnPosition, spawnRotation); 
            // Čeka 2 sekunde 
            yield return new WaitForSeconds(2.0f); 
        }
        gameOverText.SetActive(true); 
        restartButton.SetActive(true);
    }
      // Update is called once per frame
        void Update()
    {
        
    }
}
