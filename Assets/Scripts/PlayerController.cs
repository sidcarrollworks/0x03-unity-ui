using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

	public float speed = 20000;
	public Rigidbody rb;
	public int health = 5;
	
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
			Debug.Log("Game over!");
			SceneManager.LoadScene("maze");
			health = 5;
			score = 0;
		}
	}

	void OnTriggerEnter(Collider other) {
		// if you touch a coin
		if (other.gameObject.tag == "Coin") {
			score++;
			Debug.Log("Score: " + score);
			Destroy(other.gameObject);
		}

		// if you touch a trap
		if (other.gameObject.tag == "Trap") {
			health--;
			Debug.Log("Health: " + health);
		}

		// if player touches goal
		if (other.gameObject.tag == "Goal") {
			Debug.Log("You win!");
		}
	}
}
