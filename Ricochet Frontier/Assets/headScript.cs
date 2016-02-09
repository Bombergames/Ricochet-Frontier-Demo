using UnityEngine;
using System.Collections;

public class headScript : MonoBehaviour
{

	Vector3 mouse_pos;
	Transform target;
	Vector3 object_pos;
	float angle;
	Vector2 bulletSpawnOffset;

	void Start()
	{
		angle = 0f;
		bulletSpawnOffset = Vector2.right * 0.1f;
	}
	
	// Update is called once per frame
	void Update()
	{
		UpdateLookDir();
		UpdateShooting();
	}

	void UpdateLookDir()
	{
		Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		transform.rotation = Quaternion.LookRotation(Vector3.forward, mousePos - transform.position);
		angle = transform.rotation.eulerAngles.z;
	}

	void UpdateShooting()
	{
		if(Input.GetButtonDown("Fire1")) {
			control.BulletParams bulletParams = control.BulletParams.one;
			bulletParams.direction = (Camera.main.ScreenToWorldPoint(Input.mousePosition)- transform.position).normalized;
			Shoot(bulletParams);
		}
	}

	void Shoot(control.BulletParams bulletParams) {
		GameObject lastBullet = Instantiate(Resources.Load("bullet", typeof(GameObject))) as GameObject;

		if(lastBullet) {
			bulletScript lastBulletScript = lastBullet.AddComponent<bulletScript>() as bulletScript;

			lastBullet.transform.position = this.transform.position;
			lastBulletScript.bulletParams = bulletParams;
			lastBulletScript.bulletParams.speed = Random.Range(0.01f, 0.1f);
			lastBulletScript.bulletParams.color = Random.ColorHSV();
			lastBullet.transform.position += new Vector3(bulletSpawnOffset.Rotate(this.angle).x, bulletSpawnOffset.Rotate(this.angle).y, 0.0f);
		} else {
			Debug.Log("could not instantiate bullet");
		}
	}
}

