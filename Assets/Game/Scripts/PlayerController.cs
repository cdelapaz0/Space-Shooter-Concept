using UnityEngine;
using System.Collections;
using Vexe.Runtime.Types;

public class PlayerController : BetterBehaviour
{

    private PlayerMovement move = null;
    private PlayerFire fire = null;

    [SaveAttribute, HideAttribute]
    private bool faceMousePointer = false;

    [Show]
    public bool FaceMousePointer {
        get { return faceMousePointer; }
        set { 
            faceMousePointer = value;
            if (value == false) {
                if (move != null)
                    Screen.showCursor = false;
                    move.FacingDirection = Vector2.right;
            }
            else {
                Screen.showCursor = true;
            }
        }
    }

    // Use this for initialization
    void Start() {
        move = GetComponent<PlayerMovement>();
        fire = GetComponent<PlayerFire>();
        if (faceMousePointer == false)
            if (move != null)
                move.FacingDirection = Vector2.right;
    }

    // Update is called once per frame
    void Update() {

        if (move != null)
            move.MoveDirection = Vector2.zero;

        Vector2 moveDir = Vector2.zero;

        moveDir.x = Input.GetAxis("Horizontal");
        moveDir.y = Input.GetAxis("Vertical");

        if (move != null && moveDir.magnitude > 0)
            move.MoveDirection = moveDir.normalized;

        if (faceMousePointer) {
            Vector2 faceDir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            move.FacingDirection = faceDir.normalized;
        }
        else {
            Vector3 faceDir = new Vector3();
            faceDir.x = Input.GetAxis("rHorizontal");
            faceDir.y = Input.GetAxis("rVertical");

            faceDir.Normalize();
            Debug.DrawLine(transform.position, transform.position + (faceDir * 10));


            if (Mathf.Abs(faceDir.x) > 0 || Mathf.Abs(faceDir.y) > 0) {
                move.FacingDirection = faceDir.normalized;
            }
        }

        if (Input.GetButton("Fire1")) {
            fire.FireLaser();
        }
    }
}
