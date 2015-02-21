using UnityEngine;
using Vexe.Runtime.Types;

public class PlayerFire : BetterBehaviour {

	public GameObject bullet = null;
	public GameObject barrel = null;

   // [SaveAttribute, HideAttribute]
    private float fireRate = 5.0f;

    [Show]
    public float FireRate
    {
        get { return fireRate; }
        set { 
            fireRate = value;
            laserCooldown.CooldownTime = 1/fireRate; 
        }
    }
	CoolDownTimer laserCooldown = new CoolDownTimer();

   

	void Start()
	{
		laserCooldown.CooldownTime = 1/fireRate;
	}

	public void FireLaser()
	{
		if(laserCooldown.IsOnCooldown() == false)
		{
			laserCooldown.Start();
			GameObject laser = Instantiate(bullet) as GameObject;
			laser.transform.position = barrel.transform.position;
            laser.GetComponent<LaserMovement>().MoveDirection = GetFireDirection();
		}

	}

    Vector3 GetFireDirection()
    {
        Vector3 fireDir = barrel.transform.position - transform.position;
        //fireDir.Normalize();
        return fireDir;
    }

	void Update()
	{
		laserCooldown.Update(Time.deltaTime);
        //Debug.DrawLine(transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition));
	}

    void OnGUI()
    {
               
    }
}
