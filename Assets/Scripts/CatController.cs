using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatController : MonoBehaviour
{
    public float forceStrength = 500;
    [SerializeField] Animator catA;
    [SerializeField] Rigidbody body;
    [SerializeField] AudioSource catEffectAS;
    [SerializeField] AudioClip jumpS;
    [SerializeField] AudioClip footsS;
    bool isLooping = false;
    /// <summary>
    /// Speed scale for the velocity of the Rigidbody.
    /// </summary>
    public float speed;
    /// <summary>
    /// Rotation Speed scale for turning.
    /// </summary>
    public float rotationSpeed;
    /// <summary>
    /// The upwards jump force of the player.
    /// </summary>
    public float jumpForce;
    // The vertical input from input devices.
    private float vertical;
    // The horizontal input from input devices.
    private float horizontal;
    // Whether or not the player is on the ground.
    private bool isGrounded;
    // Initialization function
    private void FixedUpdate()
    {
        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");
        CheckGrounded();
        if (Input.GetButton("Jump"))
        {
            if (isGrounded)
            {
                catEffectAS.PlayOneShot(jumpS);
                catA.SetBool("isJumping", true);
                body.AddForce(transform.up * jumpForce);
                //Debug.LogError("jump");
            }
        }
        Vector3 velocity = (transform.forward * vertical) * speed * Time.fixedDeltaTime;
        velocity.y = body.velocity.y;
        body.velocity = velocity;
        transform.Rotate((transform.up * horizontal) * rotationSpeed * Time.fixedDeltaTime);
        //check velocity if velocity above 0 then animate walk
        if (body.velocity.magnitude > 1f)
        {
            catA.SetBool("isWalking", true);
            //if (!isLooping)
            //{
            //    isLooping = true;
            //    catEffectAS.clip = footsS;
            //    catEffectAS.loop = true;
            //    catEffectAS.Play();
            //}
        }
        else
        { 
            catA.SetBool("isWalking", false);
            //if (isLooping)
            //{
            //    catEffectAS.loop = false;
            //    catEffectAS.Stop();
            //    isLooping = false;
            //}
        }
        //check velocity if velocity above 0 then animate walk
        if (body.velocity.magnitude > 2f)
        {
            catA.SetBool("isRunning", true);
            //if (!isLooping)
            //{
            //    isLooping = true;
            //    catEffectAS.clip = footsS;
            //    catEffectAS.loop = true;
            //    catEffectAS.Play();
            //}
        }
        else
        {
            catA.SetBool("isRunning", false);
            //if (isLooping)
            //{
            //    catEffectAS.loop = false;
            //    catEffectAS.Stop();
            //    isLooping = false;
            //}
        }
    }

    //function to check distance of player to ground to see if player is grounded 
    private void CheckGrounded()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 1.1f))
        {
            if(hit.distance > 0.1f)
            {
                //Debug.LogError("Too far");
                isGrounded = false;
            }
            else
            {
                isGrounded = true;
                catA.SetBool("isJumping", false);
                //Debug.LogError("isgrounded");
            }

        }
        else
        {
            isGrounded = false;
            //Debug.LogError("isgrounded");
        }
    }

    //collider
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Destroyable")
        {
            collision.gameObject.GetComponent<Rigidbody>().AddForce(-collision.contacts[0].normal * forceStrength);
        }
    }

}
