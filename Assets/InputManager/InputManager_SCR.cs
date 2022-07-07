using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class InputManager_SCR : MonoBehaviour
{
	public static InputManager_SCR instance;
	[Header("Character Input Values")]
	public Vector2 move;
	public Vector2 look;
	public bool sprint;
	public bool jump;

	[Header("Movement Settings")]
	public bool analogMovement;

	private void Awake()
    {
        if (instance)
        {
			Destroy(gameObject);
        }
        else
        {
			instance = this;
        }
    }


    public void OnMove(InputValue value)
	{
		
		MovmentInput(value.Get<Vector2>());
	}

	public void OnLook(InputValue value)
	{
		
		LookInput(value.Get<Vector2>());
		
	}

	public void MovmentInput(Vector2 newMoveDirection)
	{
		move = newMoveDirection;
	}

	public void LookInput(Vector2 newLookDirection)
	{
		look = newLookDirection;
	}


	public void OnSprint(InputValue value)
	{
		SprintInput(value.isPressed);



	}

	public void SprintInput(bool newSprintState)
	{
		sprint = newSprintState;
	}

	public void OnJump(InputValue value)
	{
		JumpInput(value.isPressed);
	}

	public void JumpInput(bool newJumpState)
	{
		jump = newJumpState;
	}

}
