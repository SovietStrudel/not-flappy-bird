using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
	public GameObject gameoverL;
	public GameObject restartL; 
	public GameObject scoreL;
	public GameObject highscoretextL;
	private int score = 0;
	private int highscore = 0;
	private TMP_Text scoretext; 
	private TMP_Text highscoretext;
	public float jumpVelocity = 5;
	
	private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
		gameoverL.SetActive(false);
		restartL.SetActive(false);
        rb = GetComponent<Rigidbody2D>();
		scoretext = scoreL.GetComponent<TMP_Text>(); 
		highscoretext = highscoretextL.GetComponent<TMP_Text>(); 
		score = 0;
		highscore = PlayerPrefs.GetInt("Highscore", 0);
    }

    // Update is called once per frame
    void Update()
    {
			// checks for input
        if (Input.GetKeyDown(KeyCode.Space)) {
			// if input is detected, adds upward velocity
			rb.velocity = Vector2.up * jumpVelocity;
			transform.rotation = Quaternion.Euler(0,0, 90);
		}
		transform.rotation = Quaternion.Euler(0,0, rb.velocity.y * 10f);
		if (Time.timeScale == 0 && Input.GetKeyDown(KeyCode.Space)) {
	
			Time.timeScale = 1;
			Restart();
			GameObject[] pipes = GameObject.FindGameObjectsWithTag("Pipe");
			foreach (GameObject pipe in pipes){
		
				Destroy(pipe);
			}
			gameoverL.SetActive(false);
			restartL.SetActive(false);
			score = 0;
		}
		scoretext.text = $"Score: {score.ToString()}";
		highscoretext.text = $"High Score: {highscore.ToString()}";
	}
   
	void Restart()
	{
		rb.velocity = Vector2.zero;
		transform.position = Vector2.zero;
	}
	private void OnCollisionEnter2D(Collision2D collision)
	{
		gameover();
            
  
	}
	private void OnTriggerEnter2D(Collider2D collision) {
		score += 1;
		if (score > highscore)
		{
			highscore = score;
			PlayerPrefs.SetInt("Highscore", highscore);
		}
	}
	void gameover() {
		Time.timeScale = 0;
		
		gameoverL.SetActive(true);
		restartL.SetActive(true);
		
		
		
	}
		
	
}

