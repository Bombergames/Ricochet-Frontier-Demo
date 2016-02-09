using UnityEngine;
using System.Collections;


//this script is used for classes and functions that need to be generally accessible. Should eventually be refactored to not be so global.

public class controlScript : MonoBehaviour
{


	void Start()
	{

	}
	
	// Update is called once per frame
	void Update()
	{

	}



}

namespace control
{
	public struct BulletParams
	{
		public Vector2 direction;
		public float speed;
		public int bounces;
		public float damage;
		public Color color;

		public BulletParams(Vector2 dir, float s, int b, float dam, Color col) {
			direction = dir;
			speed = s;
			bounces = b;
			damage = dam;
			color = col;
		}

		public static BulletParams one { get{
				return new BulletParams(new Vector2(1, 1), 0.1f, 2, 100.0f, Color.cyan); }
		}
	}
}

public static class Vector2Extension {
	
	public static Vector2 Rotate(this Vector2 v, float degrees) {
		float sin = Mathf.Sin(degrees * Mathf.Deg2Rad);
		float cos = Mathf.Cos(degrees * Mathf.Deg2Rad);
		
		float tx = v.x;
		float ty = v.y;
		v.x = (cos * tx) - (sin * ty);
		v.y = (sin * tx) + (cos * ty);
		return v;
	}
}

public static class MapData
{
	public static float width = 20f;
	public static float height = 20f;
}



