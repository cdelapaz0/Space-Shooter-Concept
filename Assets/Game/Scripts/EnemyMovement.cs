using UnityEngine;
using System.Collections;
using Vexe.Runtime.Types;

public class EnemyMovement : BetterBehaviour {

    public Vector2 speed = new Vector2(5, 5);

    private Vector2 moveDir = new Vector2(1, 1).normalized;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
    {



       BoundsExitFlag flags = GameHelper.CheckOutOfBounds(transform.position);
       if ((flags & BoundsExitFlag.Left) == BoundsExitFlag.Left || (flags & BoundsExitFlag.Right) == BoundsExitFlag.Right)
       {
           Destroy(this);
       }
	}
}
