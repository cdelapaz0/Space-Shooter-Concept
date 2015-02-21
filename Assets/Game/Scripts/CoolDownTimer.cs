using UnityEngine;
using System.Collections;

public class CoolDownTimer {

	float cooldownTime;

	public float CooldownTime {
		get {
			return cooldownTime;
		}
		set {
			cooldownTime = value;
		}
	}

	float currTime = 0;
	bool active = false;

	public void Start()
	{
		if(!active)
		{
			active = true;
			currTime = cooldownTime;
		}
	}

	public bool IsOnCooldown()
	{
		if(active && currTime > 0)
		{
			return true;
		}
		return false;
	}
	
	// Update is called once per frame
	public void Update (float dt) 
    {
		if(active)
		{
			currTime -= dt;
			if(currTime <= 0)
			{
				active = false;
				currTime = 0;
			}
		}
	}
}
