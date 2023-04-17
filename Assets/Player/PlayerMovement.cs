using Assets.Objects.PowerUps;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    // These variables (visible in the inspector) are for you to set up to match the right feel
    [SerializeField] private float _speed = 12f;
    [SerializeField] private float _speedH = 2.0f;
    [SerializeField] private float _speedV = 2.0f;
    [SerializeField] private float _yaw = 0.0f;
    [SerializeField] private float _pitch = 0.0f;

    // This must be linked to the object that has the "Character Controller" in the inspector. You may need to add this component to the object
    [SerializeField] private CharacterController controller;
    private Vector3 velocity;

    // Customisable gravity
    [SerializeField] private float gravity = -20f;

    // Tells the script how far to keep the object off the ground
    [SerializeField] private float groundDistance = 0.4f;

    // How high the player can jump
    [SerializeField] private float jumpHeight = 2f;

    // So the script knows if you can jump!
    // TODO Remove serialization
    [SerializeField] private bool isGrounded;

    // Allow double jump and track it
    // TODO Remove serialization
    [SerializeField] private bool canDoubleJump;
    [SerializeField] private bool hasDoubleJumped;

    private void Start()
    {
        // If the variable "controller" is empty...
        if (controller == null)
        {
            // ...then this searches the components on the gameobject and gets a reference to the CharacterController class
            controller = GetComponent<CharacterController>();
        }
    }

    private void Update()
    {
        // These lines let the script rotate the player based on the mouse moving
        _yaw += _speedH * Input.GetAxis("Mouse X");
        _pitch -= _speedV * Input.GetAxis("Mouse Y");

        // Get the Left/Right and Forward/Back values of the input being used (WASD, Joystick etc.)
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // Let the player jump if they are on the ground and they press the jump button
        if (Input.GetButtonDown("Jump"))
        {
            if (isGrounded)
            {
                // On the ground, can jump
                velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);

                hasDoubleJumped = false;
            }
            else if (!isGrounded && canDoubleJump && !hasDoubleJumped)
            {
                // In the air, and allowed to double jump
                velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
                hasDoubleJumped = true;
            }
        }

        // Rotate the player based off those mouse values we collected earlier
        transform.eulerAngles = new Vector3(0.0f, _yaw, 0.0f);

        // This is stealing the data about the player being on the ground from the character controller
        isGrounded = controller.isGrounded;

        // What does this do
        if (isGrounded && (velocity.y < 0))
        {
            velocity.y = -2f;
        }

        // This fakes gravity!
        velocity.y += gravity * Time.deltaTime;

        // This takes the Left/Right and Forward/Back values to build a vector
        Vector3 move = transform.right * x + transform.forward * z;

        // Finally, it applies that vector it just made to the character
        controller.Move(_speed * Time.deltaTime * move + velocity * Time.deltaTime);
    }

    public void EnableDoubleJump()
    {
        Debug.Log("Double jump enabled");
        canDoubleJump = true;
    }

    public void IncreaseSpeed()
    {
        _speed *= 1.5f;
    }
}