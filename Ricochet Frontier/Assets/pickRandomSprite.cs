using UnityEngine;
using System.Collections;

//assigns the object's sprite to a random sprite, rotates it if set to rotate. Useful for terrain generation/randomization

public class pickRandomSprite : MonoBehaviour {

	public Sprite[] sprites = new Sprite[]{};
	public bool rotate = false;
	void Start () {
		SpriteRenderer rend = this.GetComponent<SpriteRenderer>();

		rend.sprite = sprites[(int) Mathf.Round(Random.Range(0, sprites.Length - 1))];

		if(rotate) {
			this.transform.rotation = Quaternion.AngleAxis(Random.Range(0, 360), Vector3.forward);
		}
	}
	

	void Update () {
	
	}
}
