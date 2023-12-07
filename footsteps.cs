using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class footsteps : MonoBehaviour
{
    public float walkSpeed = 0.5f;
    public float runSpeed = 1f;
    public float jumpForce = 0f;
    public float groundDistance = 0.2f;
    public LayerMask groundMask;
    public AudioSource footstepSound;
    public AudioSource jumpSound;
    public AudioSource landingSound;

    private bool isWalking;
    private bool isRunning;
    private bool isGrounded;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // Check for input (you can replace this with your movement input)
        float moveInput = Input.GetAxis("Vertical");

        // Check if the character is walking or running
        isWalking = Mathf.Abs(moveInput) > 0 && Mathf.Abs(moveInput) < 0.5f;
        isRunning = Mathf.Abs(moveInput) >= 0.5f;

        // Play footstep sound based on movement
        PlayFootstepSound();

        // Apply movement based on walking or running speed
        float speed = isRunning ? runSpeed : walkSpeed;
        transform.Translate(Vector3.forward * moveInput * speed * Time.deltaTime);

        // Jumping
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            if (jumpSound != null)
                jumpSound.Play();
        }

        // Check for ground contact using Raycast
        CheckGrounded();
    }

    private void CheckGrounded()
    {
        RaycastHit hit;
        isGrounded = Physics.Raycast(transform.position, Vector3.down, out hit, groundDistance, groundMask);

        if (isGrounded && hit.collider != null)
        {
            if (landingSound != null && rb.velocity.y <= 0.1)
            {
                landingSound.Play();
            }
        }
    }

    private void PlayFootstepSound()
    {
        if (footstepSound != null)
        {
            if ((isWalking || isRunning) && !footstepSound.isPlaying)
            {
                footstepSound.Play();
                footstepSound.volume = isRunning ? 1f : 0.2f; // Adjust volume based on movement
            }
            else if (!isWalking && !isRunning)
            {
                footstepSound.Stop(); // Stop sound if neither walking nor running
            }
        }
    }
}