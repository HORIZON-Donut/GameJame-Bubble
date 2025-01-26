using UnityEngine;

public class CameraScript: MonoBehaviour
{
	void Start()
	{
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}

	void Update()
	{
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			enableCursor();
		}

		if(Input.GetKey(KeyCode.LeftAlt))
		{
			disableCursor();
		}
	}

	public void enableCursor()
	{
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
	}

	public void disableCursor()
	{
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}
}
