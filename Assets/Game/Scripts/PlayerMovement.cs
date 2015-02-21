using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	private Vector2 moveDir = Vector2.zero;

	public Vector2 MoveDirection {
		get {
			return moveDir;
		}
		set {
			moveDir = value;
		}
	}

	private Vector2 faceDir = Vector2.zero;

	public Vector2 FacingDirection {
		get {
			return faceDir;
		}
		set {
			faceDir = value;
		}
	}

	public float speed = 2.0f;

	public GameObject ship = null;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		// Transaltion ///////
		Vector3 pos = transform.position;
		pos.x += moveDir.x * speed * Time.deltaTime;
		pos.y += moveDir.y * speed * Time.deltaTime;

        transform.position = pos;
        transform.position = GameHelper.ClampPositionWithinBounds(collider2D.bounds);

        //// CheckOutOfBounds() tets code
        //transform.position = pos;
        //BoundsExitFlag flags = GameUtils.CheckOutOfBounds(collider2D.bounds);
        //if(flags != BoundsExitFlag.None)
        //{
        //    Debug.Log(flags);
        //}


		///////////////////////

		// Rotation ///////////
		ship.transform.up = faceDir;
		///////////////////////

	}
}
