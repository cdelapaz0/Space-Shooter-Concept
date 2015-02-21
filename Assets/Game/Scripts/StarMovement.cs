using UnityEngine;
using System.Collections;

public class StarMovement : MonoBehaviour {

	public float starSpeed = 1.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 position = transform.position;
		position.x -= starSpeed * Time.deltaTime;

		Rect r = Camera.main.worldSpaceRect();
		if( position.x < r.xMin - 1.0f)
		{
			position.x = r.xMax + 1.0f;
			position.y = Random.Range(r.yMin, r.yMax);
		}
		transform.position = position;
	}
}
