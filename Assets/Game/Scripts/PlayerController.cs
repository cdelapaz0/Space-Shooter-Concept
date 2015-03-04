using UnityEngine;
using System.Collections;


public class PlayerController : MonoBehaviour
{

    private PlayerMovement move = null;
    private PlayerFire fire = null;

    // Use this for initialization
    void Start() {
        move = GetComponent<PlayerMovement>();
        fire = GetComponent<PlayerFire>();

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


        if (Input.GetButton("Fire1")) {
            fire.FireLaser();
        }
    }
}
