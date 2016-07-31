using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour 
{
	float currentSpeed, highGearSpeed, lowGearSpeed;
	float currentTurnSpeed, turnSpeedLow, turnSpeedHigh;

	void Start () 
	{
		GameManager.ChangeGear += GearChangeHandler;

		turnSpeedHigh = 5f;
		turnSpeedLow = 2.5f;
		currentTurnSpeed = turnSpeedLow;

		highGearSpeed = .25f;
		lowGearSpeed = .1f;
		currentSpeed = lowGearSpeed;
	}

	void Update () 
	{
		if (Input.GetAxisRaw ("Horizontal") != 0) 
		{
			Turn ((int)Mathf.Sign(Input.GetAxisRaw ("Horizontal")));
		}
		if (Input.GetAxisRaw ("Vertical") > 0) 
		{
			Move ();
		}
	}

	void GearChangeHandler(int gear)
	{
		if (gear == 1) 
		{
			currentSpeed = highGearSpeed;
			currentTurnSpeed = turnSpeedHigh;
		} 
		else if (gear == 0) 
		{
			currentSpeed = lowGearSpeed;
			currentTurnSpeed = turnSpeedLow;
		}
	}

	void Move()
	{
		Vector3 newPos = transform.position;
		newPos += currentSpeed * transform.up;
		transform.position = newPos;
	}

	//Turn with turn speed to the left (-1) or right (1)
	void Turn(int direction)
	{
		Collider2D coll = GetComponent<Collider2D> ();
		transform.RotateAround (coll.bounds.center,
			Vector3.forward, -currentTurnSpeed * direction);
	}
}
