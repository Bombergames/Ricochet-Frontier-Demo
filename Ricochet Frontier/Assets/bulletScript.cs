using UnityEngine;
using System.Collections;

public class bulletScript : MonoBehaviour {
	public control.BulletParams bulletParams = control.BulletParams.one;
	TrailRenderer trail;
	Vector2 velocity;
	Rigidbody2D rigidBody;
	float timeAtLastBounce = float.MinValue;
	float deathTimer = 10;


	void Start() {
		Debug.Log("instantiating bullet");

		rigidBody = this.GetComponent<Rigidbody2D>();
		trail = this.gameObject.GetComponentInChildren<TrailRenderer>();
	}
	
	void Update() {
		velocity = bulletParams.direction.normalized * bulletParams.speed;
		this.GetComponent<Rigidbody2D>().MovePosition(new Vector2(velocity.x, velocity.y) + new Vector2(transform.position.x, transform.position.y));

		if ((deathTimer -= Time.deltaTime) <= 0 || (velocity.x == 0 && velocity.y == 0)) {
			Destroy(this.gameObject);
		}
		UpdateDirection();
		UpdateTrail();
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if(Time.time - timeAtLastBounce > 0.01f) {
			if(coll.gameObject.tag == "wall") {
				if(bulletParams.bounces > 0) {
					RaycastHit2D raycast = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y) - velocity, velocity.normalized); 
					bulletParams.direction = Vector2.Reflect(bulletParams.direction, raycast.normal).normalized;

					bulletParams.bounces--;
				} else {
					Vector3 bulletExplosionParticles = coll.collider.bounds.ClosestPoint(new Vector3(transform.position.x, transform.position.y, 0));
					//bulletExplosionHelper.Instance.Explosion(new Vector3(bulletExplosionParticles.x, bulletExplosionParticles.y, 0));
					OnHitWallAndBreak();
				}

			}
			timeAtLastBounce = Time.time;
		} else {
			Debug.Log("test");
		}
	}

	void OnHitWallAndBreak() {
		Destroy(this.gameObject);
	}

	void UpdateDirection() {
		float angle = -1.0f * Mathf.Atan2(bulletParams.direction.normalized.x, bulletParams.direction.normalized.y) * Mathf.Rad2Deg;
		//float angle = 45f;
		this.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
	}

	void UpdateTrail() {
		this.trail.material.SetColor("_TintColor", bulletParams.color);
	}
}