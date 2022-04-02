using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {

	public float Speed;
	public float JumpForce;
	public bool isJumping;
	public bool doubleJumping;
	private Rigidbody2D rigi;

	// Use this for initialization
	void Start () {
		rigi = GetComponent<Rigidbody2D>();

	}
	// Update is called once per frame
	void Update () {

		Move();
		Jump();
	}
	void Move() {
		Vector3 movement = new Vector3 (Input.GetAxis ("Horizontal"), 0f, 0f);
		transform.position += movement * Time.deltaTime * Speed;
	}
	void Jump() {
		if (Input.GetButtonDown("Jump")) {
			if(!isJumping){
				rigi.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
				doubleJumping = true;
			}
			else {
				if (doubleJumping){

					rigi.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
					doubleJumping = false;
				}
			}
		}
		
	}

	void OnCollisionEnter2D(Collision2D collision) {
		if(collision.gameObject.layer == 8) {
			isJumping = false;

		}
		
	}
	void OnCollisionExit2D(Collision2D collision) {
		if(collision.gameObject.layer == 8) {
			isJumping = true;
			
		}
	}
}
