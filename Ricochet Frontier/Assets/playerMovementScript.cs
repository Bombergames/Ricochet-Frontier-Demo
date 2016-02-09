using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class playerMovementScript : MonoBehaviour
{

	Vector2 velocity = Vector2.zero;
	public float instantVelocity = 1.0f;
	public float accelerationRatio = 0.1f;
	public float terminalVelocity = 10.0f;
	public float frictionCoefficient = 0.9f;
	float sqrTerminalVelocity;
	Vector2 netAcceleration = Vector2.zero;
	Vector2 lastDirection = Vector2.zero;
	//public float dashLength = 1.0f;
	//float dashKeyTime = 10.0f;
	//string lastDashKey = "";
	//float timeAtLastDashKey = 0;
	//bool dashing = false;
	Rigidbody2D rigidBody;
	string latestHorizontal;
	string latestVertical;
 

	void Start()
	{
		sqrTerminalVelocity = Mathf.Pow(terminalVelocity, 2);
		rigidBody = this.GetComponent<Rigidbody2D>();
		//timeAtLastDashKey = Time.time;
	}
	

	void Update()
	{
		UpdatePosition();
		UpdateDirection();
	}

	void UpdatePosition() {
		
		if(!Input.GetButton("Horizontal") && !Input.GetButton("Vertical")) {
				netAcceleration = Vector2.zero;
		} else {
			netAcceleration = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
		}
			
		netAcceleration *= accelerationRatio;


		this.GetComponent<Rigidbody2D>().AddForce(netAcceleration);

	}

	void UpdateDirection() {
		float angle = -1.0f * Mathf.Atan2(rigidBody.velocity.x, rigidBody.velocity.y) * Mathf.Rad2Deg;
		this.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
	}

	void OnCollisionStay2D(Collision2D coll) {
		if(coll.gameObject.tag == "wall") {
			//this.transform.position -= new Vector3(velocity.x, velocity.y, 0.0f);
		}
	}
	/*
	bool CheckDash() {
		if(Input.GetButtonDown("Vertical") && Input.GetAxisRaw("Vertical") < 0f) {
			if (lastDashKey == "Down")
			{
				//this.GetComponent<Rigidbody2D>().MovePosition(new Vector2(this.transform.position.x, this.transform.position.y) + Vector2.down * dashLength);
				//StartCoroutine(doubleDash(0.1f, "Down"));
				return true;
			}

			lastDashKey = "Down";
		} 
		else if(Input.GetButtonDown("Vertical") && Input.GetAxisRaw("Vertical") > 0f) {
			if (lastDashKey == "Up")
			{
				//this.GetComponent<Rigidbody2D>().MovePosition(new Vector2(this.transform.position.x, this.transform.position.y) + Vector2.up * dashLength);
				//StartCoroutine(doubleDash(0.1f, "Up"));
				return true;
			}
			
			lastDashKey = "Up";
		}
		else if(Input.GetButtonDown("Horizontal") && Input.GetAxisRaw("Horizontal") < 0f) {
			if (lastDashKey == "Left")
			{
				//this.GetComponent<Rigidbody2D>().MovePosition(new Vector2(this.transform.position.x, this.transform.position.y) + Vector2.left * dashLength);
				//StartCoroutine(doubleDash(0.1f, "Left"));
				return true;
			}
			
			lastDashKey = "Left";
		}
		else if(Input.GetButtonDown("Horizontal") && Input.GetAxisRaw("Horizontal") > 0f) {
			if (lastDashKey == "Right")
			{
				//this.GetComponent<Rigidbody2D>().MovePosition(new Vector2(this.transform.position.x, this.transform.position.y) + Vector2.right * dashLength);
				//StartCoroutine(doubleDash(0.1f, "Right"));
				return true;
			}
			
			lastDashKey = "Right";
		}

		return false;
	}
	*/


	private IEnumerator doubleDash(float delay, string direction) {
			yield return new WaitForSeconds(delay);

			if (direction == "Down")
			{
			//this.GetComponent<Rigidbody2D>().MovePosition(new Vector2(this.transform.position.x, this.transform.position.y) + Vector2.down * dashLength * secondDashRatio);
			}else if (direction == "Up")
			{
			//	this.GetComponent<Rigidbody2D>().MovePosition(new Vector2(this.transform.position.x, this.transform.position.y) + Vector2.up * dashLength * secondDashRatio);
			} else if (direction == "Left")
			{
			//	this.GetComponent<Rigidbody2D>().MovePosition(new Vector2(this.transform.position.x, this.transform.position.y) + Vector2.left * dashLength * secondDashRatio);
			} else if (direction == "Right")
			{
			//	this.GetComponent<Rigidbody2D>().MovePosition(new Vector2(this.transform.position.x, this.transform.position.y) + Vector2.right * dashLength * secondDashRatio);
			}

	}
}