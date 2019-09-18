using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private Vector3 movement;
    private float movementSqrMagnitude;

    public float walkSpeed = 1.5f;

    // Update is called once per frame
    void Update()
    {
        GetMovementInput();
        CharacterPostion();
        CharacterRotation();
        WalkingAnimation();
        FootstepAudio();

    }


    void GetMovementInput()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.z = Input.GetAxis("Vertical");

        movement = Vector3.ClampMagnitude(movement, 1.0f);
        // Store the squared magnitude of the movement vector 
        movementSqrMagnitude = Vector3.SqrMagnitude(movement);

        Debug.Log(movement);
    }
    void CharacterPostion()
    {
        //gameObject.
        transform.Translate( movement * walkSpeed * Time.deltaTime, Space.World);
       // transform.position += movement * walkSpeed * Time.deltaTime;
        
    }
    void CharacterRotation()
    {
        if (movement != Vector3.zero)
        {
            Quaternion rotation = Quaternion.LookRotation(movement);
            transform.rotation = rotation;
        }


    }
    void WalkingAnimation() { }
    void FootstepAudio() { }

}
