using UnityEngine;
using System.Collections;


//Largely borrowed from an online resource
public class cameraSmoothFollow : MonoBehaviour
{
	
	public GameObject cameraTarget; // object to look at or follow
	//public GameObject player; // player object for moving
	
	public float smoothTime = 0.1f;    // time for dampen
	public float cameraHeight = 2.5f; // height of camera adjustable
	public Vector2 velocity; // speed of camera movement
	
	private Transform thisTransform; // camera Transform
	
	// Use this for initialization
	void Start()
	{
		thisTransform = transform;
	}
	
	// Update is called once per frame
	void Update()
	{

		thisTransform.position = new Vector3(Mathf.SmoothDamp(thisTransform.position.x, cameraTarget.transform.position.x, ref velocity.x, smoothTime), Mathf.SmoothDamp(thisTransform.position.y, cameraTarget.transform.position.y, ref velocity.y, smoothTime), thisTransform.position.z);
	}
}
