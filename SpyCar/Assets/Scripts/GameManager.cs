using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour 
{
	#region Singleton
	public static GameManager instance;
	#endregion

	int currentGear;

	#region Events
	public delegate void ChangeGearAction (int gear);
	public static event ChangeGearAction ChangeGear;
	#endregion

	void Awake()
	{
		if (instance == null)
			instance = this;
		else
			Destroy (this);
	}

	void Start () 
	{
		currentGear = 0;
	}

	void Update () 
	{
		currentGear = Mathf.Clamp (currentGear, 0, 1);

		HandleInput ();
	}

	void HandleInput()
	{
		if (Input.GetKeyDown (KeyCode.LeftShift)) 
		{
			if (currentGear == 0)
				currentGear = 1;
			else if (currentGear == 1)
				currentGear = 0;
			if (ChangeGear != null)
				ChangeGear (currentGear);

			Debug.Log (ChangeGear.Method);
		}
	}
}
