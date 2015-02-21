using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StarSpawnController : MonoBehaviour {

	public GameObject smallStar = null;
	public GameObject bigStar = null;

	private List<GameObject> starList = new List<GameObject>();

	public int smallStarAmountMin = 5;
	public int smallStarAmountMax = 10;

	public int bigStarAmountMin = 5;
	public int bigStarAmountMax = 10;

	// Use this for initialization
	void Start () {

		float smallStarNum = Random.Range(smallStarAmountMin, smallStarAmountMax);
		for(int i = 0; i < smallStarNum; ++i)
		{
			if(smallStar != null)
			{
				starList.Add(Instantiate(smallStar) as GameObject);
				starList[i].transform.parent = transform;

				Rect r = Camera.main.worldSpaceRect();
				Vector3 position = new Vector3(Random.Range(r.xMin, r.xMax), Random.Range(r.yMin, r.yMax));
				starList[i].transform.position = position;
			}
		}

		float bigStarNum = Random.Range(bigStarAmountMin, bigStarAmountMax);
		for(int i = (int)smallStarNum; i < smallStarNum + bigStarNum; ++i)
		{
			if(bigStar != null)
			{
				starList.Add(Instantiate(bigStar) as GameObject);
				starList[i].transform.parent = transform;

				Rect r = Camera.main.worldSpaceRect();
				Vector3 position = new Vector3(Random.Range(r.xMin, r.xMax), Random.Range(r.yMin, r.yMax));
				starList[i].transform.position = position;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
