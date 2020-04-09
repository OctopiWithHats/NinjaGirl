using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaModel
{
    // Game behaviour settings
    public const float speed = 6.0f;
    public const float jumpSpeed = 8.0f;
    public const float gravity = 20.0f;

    // Link to view.
    public NinjaView myView;

    // Link to character controller
    private NinjaController myCharacterController;

    // Is the character grounded?
    private bool _isGrounded;

    public bool IsGrounded
    {
        get
        {
            return _isGrounded;
        }

        set
        {
            _isGrounded = value;

            myView.SetGrounded(_isGrounded); // Update the view.
        }
    }

    private Vector3 moveDirection = Vector3.zero;

    // Control character movement.
    public void Move(float moveX, float moveY, bool jump)
    {
        IsGrounded = myCharacterController.isGrounded;


        if (IsGrounded)
        {
            // We are grounded, so recalculate
            // move direction directly from axes
            moveDirection = new Vector3(moveX, 0.0f, moveY);
            moveDirection *= speed;

            // Face in direction of movement.
            if (moveDirection.magnitude > float.Epsilon)
            {
                myView.SetRotate(Quaternion.LookRotation(moveDirection));
            }

            myView.SetAnimationSpeed(moveDirection.magnitude);

            if (jump)
            {
                moveDirection.y = jumpSpeed;
            }
        }

        moveDirection.y -= gravity * Time.deltaTime;

        myCharacterController.Move(moveDirection * Time.deltaTime);
    }

    // Pass view into model.
    public void SetView(NinjaView theView)
    {
        myView = theView;
    }

    // Pass character controller into model.
    public void SetCharacterController(NinjaController theCharacterController)
    {
        myCharacterController = theCharacterController;
    }

}
