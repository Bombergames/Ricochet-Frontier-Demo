using UnityEngine;
using System.Collections;

public class backgroundScript : MonoBehaviour {

	void Start () {
		Sprite sprite = this.GetComponent<SpriteRenderer>().sprite;
		if(sprite) {
			Vector3 spriteSize = sprite.bounds.size;
			this.transform.localScale = new Vector3(MapData.width / spriteSize.x, MapData.height / spriteSize.y, 1);
		} else {
			Debug.Log("no sprite for background");
		}
	}

}
