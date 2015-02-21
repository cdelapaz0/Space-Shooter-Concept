using UnityEngine;
using System.Collections;

public class LaserMovement : MonoBehaviour {

	private Vector3 moveDir = Vector2.right;
	
	public Vector3 MoveDirection {
		get {
			return moveDir;
		}
		set {
			moveDir = value;
			transform.right = moveDir;
		}
	}
	
	public float speed = 2.0f;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        moveDir.Normalize();

        //Debug.DrawLine(transform.position, transform.position + (3 * moveDir));
        //Debug.DrawLine(transform.position, transform.position + (3 * transform.right), Color.red);

		Vector3 pos = transform.position;
		pos += moveDir * speed * Time.deltaTime;
		//pos.y = moveDir.y * speed * Time.deltaTime;

        transform.position = pos;

        if (GameHelper.CheckOutOfBounds(transform.position) != BoundsExitFlag.None)
        {
            Destroy(this.gameObject);
            return;
        }
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}
