using UnityEngine;
using System.Collections;

public class pointTowardsVelocity : MonoBehaviour {
	Rigidbody2D rigidBody;
	// Use this for initialization
	void Start () {
		rigidBody = this.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		float angle = Mathf.Atan2(rigidBody.velocity.x, rigidBody.velocity.y) * Mathf.Rad2Deg;
		this.transform.localRotation = Quaternion.AngleAxis(angle, Vector3.up);
	}
}
