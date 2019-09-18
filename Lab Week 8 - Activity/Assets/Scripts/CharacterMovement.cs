using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private Vector3 movement;
    private float movementSqrMagnitude;

    public float walkSpeed = 1.5f;
    public Animator animator;
    public AudioSource footstepSource;
    public AudioClip[] footstepClips;
    public AudioSource backgroundSource;

    // Update is called once per frame
    void Update()
    {

        GetMovementInput();
        if (RaycastCheck())
        {
            CharacterRotation();
        }
        else
        {
           
            CharacterPostion();
            CharacterRotation();
            WalkingAnimation();
            FootstepAudio();
        }
      
    }


    void GetMovementInput()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.z = Input.GetAxis("Vertical");

        movement = Vector3.ClampMagnitude(movement, 1.0f);
        // Store the squared magnitude of the movement vector 
        movementSqrMagnitude = Vector3.SqrMagnitude(movement);

       // Debug.Log(movement);
    }
    void CharacterPostion()
    {
 
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
    void WalkingAnimation()
    {
        animator = GetComponent<Animator>();
        animator.SetFloat("MoveSpeed", movementSqrMagnitude);
    }
    void FootstepAudio()
    {
        if (movementSqrMagnitude > 0.3f && !footstepSource.isPlaying)
        {
            if (footstepSource.clip.Equals(footstepClips[0]))
            {
                footstepSource.clip = footstepClips[1];
            }
            else if (footstepSource.clip.Equals(footstepClips[1]))
            {
                footstepSource.clip = footstepClips[0];
            }


            // Set the volume of the audio source to the movementSqrMagnitude
            footstepSource.volume = movementSqrMagnitude;
            footstepSource.Play();

            //“Duck” the background music volume by reducing it to 0.5f.
            backgroundSource.volume = 0.5f;
        }
        else if (movementSqrMagnitude<=0.3f && footstepSource.isPlaying)
        {
            footstepSource.Stop();
            backgroundSource.volume = 1.0f;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Trigger Exit: " + other.gameObject.name + " : " + other.gameObject.transform.position );
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision Enter: " + collision.gameObject.name + " : " + collision.GetContact(0).point);
     }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Impassable"))
        {
            Debug.Log("Collision Stay: " + collision.gameObject.name);
        }

    }

    private bool RaycastCheck()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position + new Vector3(0, 0.5f, 0), transform.TransformDirection(Vector3.forward), out hit))
        {
            Debug.Log("Raycast Hit: " + hit.transform.name);
            if (hit.transform.CompareTag("Freeze"))
            {
                return true;
            }
        }

        return false;
    }
}
