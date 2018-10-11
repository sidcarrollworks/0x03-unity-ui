using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public float speed = 20000;
	public Rigidbody rb;
	public int health = 5;
	public Text scoreText;
	public Text healthText;
	public Image winLoseBG;
	public GameObject winLoseObject;
	public Text winLoseText;
	
	private int score = 0;


	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey("w")){
			rb.AddForce(0, 0, speed * Time.deltaTime);
		}
		if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey("s")){
			rb.AddForce(0, 0, -speed * Time.deltaTime);
		}
		if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey("a")){
			rb.AddForce(-speed * Time.deltaTime, 0, 0);
		}
		if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey("d")){
			rb.AddForce(speed * Time.deltaTime, 0, 0);
		}
	}

	void Update () {
		if (health == 0) {
			Lose();
			StartCoroutine(LoadScene(3));
		}
	}

	void OnTriggerEnter(Collider other) {
		// if you touch a coin
		if (other.gameObject.tag == "Coin") {
			score++;
			SetScoreText();
			Destroy(other.gameObject);
		}

		// if you touch a trap
		if (other.gameObject.tag == "Trap") {
			health--;
			SetHealthText();
		}

		// if player touches goal
		if (other.gameObject.tag == "Goal") {
			Win();
			StartCoroutine(LoadScene(3));
		}
	}

	void SetScoreText() {
		scoreText.text = "Score: " + score;
	}

	void SetHealthText() {
		healthText.text = "Health: " + health;
	}

	void Win() {
		winLoseObject.SetActive(true);
		winLoseText.color = Color.black;
		winLoseBG.color = Color.green;
		winLoseText.text = "You Win!";
	}

	void Lose() {
		winLoseObject.SetActive(true);
		winLoseText.color = Color.white;
		winLoseBG.color = Color.red;
		winLoseText.text = "Game Over!";
	}

	IEnumerator LoadScene (float seconds) {
		yield return new WaitForSeconds(seconds);
		SceneManager.LoadScene("maze");
	}
}

