using UnityEngine;
using System.Collections;

public class rockScript : MonoBehaviour {

	public float rockDensity = 0.0001f;
	int rockCount;

	// Use this for initialization
	void Start () {
		rockCount = Mathf.RoundToInt(rockDensity * MapData.width * MapData.height);
		for(int i = 0; i < rockCount; i++) {
			GameObject rock = Instantiate(Resources.Load("rock")) as GameObject;
			rock.transform.position = new Vector3(Random.Range(-MapData.width / 2, MapData.width / 2), Random.Range(-MapData.height / 2, MapData.height / 2), 0);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
