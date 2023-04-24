using UnityEngine;

namespace Assets.Player
{
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
        [SerializeField] private CharacterController _controller;

        // Customisable gravity
        [SerializeField] private float _gravity = -20f;

        // How high the player can jump
        [SerializeField] private float jumpHeight = 2f;

        // Leeway for jumping off things
        [SerializeField] private int _frameLeewayForGrounded = 20;

        // So the script knows if you can jump
        private bool isGrounded;

        // Allow double jump and track it
        private bool canDoubleJump;
        private bool hasDoubleJumped;

        // Player velocity
        private Vector3 velocity;

        // Counts the number of frames since the player was on the ground
        private int _numFramesSinceGrounded = 0;

        private void Start()
        {
            // If the variable "controller" is empty...
            if (_controller == null)
            {
                // ...then this searches the components on the game object and gets a reference to the CharacterController class
                _controller = GetComponent<CharacterController>();
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

            // Detect when the player is grounded or was until 5 frames ago (to give some leeway)
            if (_controller.isGrounded)
            {
                // Is on the ground
                isGrounded = true;

                _numFramesSinceGrounded = 0;
            }
            else
            {
                // Not on the ground

                if (_numFramesSinceGrounded < _frameLeewayForGrounded)
                {
                    // Been less than the limit of frames since was on the ground
                    _numFramesSinceGrounded += 1;
                }
                else
                {
                    // Been more than the limit of frames
                    isGrounded = false;
                }
            }

            // Let the player jump if they are on the ground and they press the jump button
            if (Input.GetButtonDown("Jump"))
            {
                if (isGrounded)
                {
                    // On the ground, can jump
                    velocity.y = Mathf.Sqrt(jumpHeight * -2 * _gravity);

                    hasDoubleJumped = false;
                }
                else if (!isGrounded && canDoubleJump && !hasDoubleJumped)
                {
                    // In the air, and allowed to double jump
                    velocity.y = Mathf.Sqrt(jumpHeight * -2 * _gravity);
                    hasDoubleJumped = true;
                }
            }

            // Rotate the player based off those mouse values we collected earlier
            transform.eulerAngles = new Vector3(0.0f, _yaw, 0.0f);

            // What does this do
            if (isGrounded && (velocity.y < 0))
            {
                velocity.y = -2f;
            }

            // This fakes gravity!
            velocity.y += _gravity * Time.deltaTime;

            // This takes the Left/Right and Forward/Back values to build a vector
            Vector3 move = transform.right * x + transform.forward * z;

            // Finally, it applies that vector it just made to the character
            _controller.Move(_speed * Time.deltaTime * move + velocity * Time.deltaTime);
        }

        public void EnableDoubleJump()
        {
            Debug.Log("Double jump enabled");
            canDoubleJump = true;
        }

        public void IncreaseSpeed()
        {
            Debug.Log("Speed up enabled");
            _speed *= 2.0f;
        }

        public void SetColor(Material color)
        {
            // Capsule
            MeshRenderer mr = this.gameObject.GetComponent<MeshRenderer>();
            mr.material = color;

            // Goggles
            GameObject goggles = this.gameObject.transform.Find("Goggles").gameObject;
            mr = goggles.GetComponent<MeshRenderer>();
            mr.material = color;
        }
    }
}
