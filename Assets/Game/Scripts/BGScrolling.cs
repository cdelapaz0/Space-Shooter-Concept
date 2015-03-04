using UnityEngine;
using System.Collections;

public class BGScrolling : MonoBehaviour {


	public float scrollSpeed = 1.5f;

	private float position = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		position += scrollSpeed * Time.deltaTime;
		if(position > 1.0f)
		{
			position -= 1.0f;
		}

		GetComponent<Renderer>().material.mainTextureOffset = new Vector2(position, 0);
	}
}
