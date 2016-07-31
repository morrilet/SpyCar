using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Animator))]
public class Gearshift : MonoBehaviour 
{
	void Start () 
	{
		GameManager.ChangeGear += AnimateChangeGear;
	}

	void Update()
	{
		SetPosition ();
	}

	//Keeps gearshift in bottom right corner of camera.
	void SetPosition()
	{
		SpriteRenderer SR = GetComponent<SpriteRenderer> ();

		Vector2 camExtents = new Vector2();
		camExtents.y = Camera.main.orthographicSize;
		camExtents.x = camExtents.y * Screen.width / Screen.height;

		Vector3 newPos = transform.position;
		newPos.x = camExtents.x - SR.bounds.extents.x;
		newPos.y = -camExtents.y + SR.bounds.extents.y;
		transform.position = newPos;
	}

	void AnimateChangeGear(int gearNumber)
	{
		GetComponent<Animator> ().SetInteger ("Gear", gearNumber);
	}
}
