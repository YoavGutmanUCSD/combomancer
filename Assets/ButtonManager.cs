using UnityEngine;
using UnityEngine.InputSystem;

public class ButtonManager : MonoBehaviour
{

	InputAction leftButton;
	InputAction rightButton;
	bool leftHeld;
	bool rightHeld;
	int ticks;

    void Awake()
    {
		leftButton = InputSystem.actions.FindAction("LeftButton");
		rightButton = InputSystem.actions.FindAction("RightButton");
		leftHeld = false;
		rightHeld = false;
		ticks = 0;
    }

    // Update is called once per frame
    void Update()
    {
		if(ticks++ >= 2) 
		{
			bool leftPressed = leftButton.IsPressed();
			bool rightPressed = rightButton.IsPressed();
			if(leftPressed && rightPressed && !leftHeld && !rightHeld) {
				Debug.Log("both pressed");
				leftHeld = true;
				rightHeld = true;
			}
			else if (leftPressed && !leftHeld) 
			{
				Debug.Log("leftButton");
				leftHeld = true;
				// rightHeld = false;
			} 
			else if (rightPressed && !rightHeld) 
			{
				Debug.Log("rightButton");
				// leftHeld = false;
				rightHeld = true;
			}
			else if (!leftPressed && !rightPressed)
			{
				leftHeld = false;
				rightHeld = false;
			}
			ticks = 0;
		}
    }
}
