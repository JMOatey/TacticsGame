using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public float speed;
	public Text countText;
	public Text winText;
	public Text timer;

	private Rigidbody rb;
	private int count;
	private int secondsi;
	public float seconds;

	void Start()
	{
		rb = GetComponent<Rigidbody>();
		count = 0;
		SetCountText ();
		winText.text = "";
	}
		
	void Update () 
	{
			if (seconds > 0) {
				seconds -= Time.deltaTime;
				secondsi = Mathf.FloorToInt (seconds);
				timer.text = "Time Left: " + secondsi.ToString ();
			}
			if (seconds <= 0) {
				winText.text = "You Lose Mom! Press Enter to Quit.";
				if (Input.GetKey("return"))
					Application.Quit ();
			}
	}

	void FixedUpdate () 
	{
		if (seconds > 0) {
			float moveHorizontal = Input.GetAxis ("Horizontal");
			float moveVertical = Input.GetAxis ("Vertical");

			Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

			rb.AddForce (movement * speed);	
		}
	}


	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag ("Pick Up")) 
		{
			other.gameObject.SetActive (false);
			count++;
			SetCountText ();
		}
		if (count >= 10) {
			winText.text = "You Win!";
		}
	}

	void SetCountText()
	{
		countText.text = "Count: " + count.ToString ();
	}
		
}
