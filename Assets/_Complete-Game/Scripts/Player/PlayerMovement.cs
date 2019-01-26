using UnityEngine;
using UnitySampleAssets.CrossPlatformInput;

namespace CompleteProject
{
    public class PlayerMovement : MonoBehaviour
    {
        public float speed = 6f;            // The speed that the player will move at.


        Vector3 movement;                   // The vector to store the direction of the player's movement.
        Animator anim;                      // Reference to the animator component.
        Rigidbody playerRigidbody;          // Reference to the player's rigidbody.
#if !MOBILE_INPUT
        int floorMask;                      // A layer mask so that a ray can be cast just at gameobjects on the floor layer.
        float camRayLength = 100f;          // The length of the ray from the camera into the scene.
#endif

        void Awake ()
        {
#if !MOBILE_INPUT
            // Create a layer mask for the floor layer.
            floorMask = LayerMask.GetMask ("Floor");
#endif

            // Set up references.
            anim = GetComponent <Animator> ();
            playerRigidbody = GetComponent <Rigidbody> ();
        }


        void FixedUpdate ()
        {
            // Store the input axes.
            float h = CrossPlatformInputManager.GetAxisRaw("Horizontal");
            float v = CrossPlatformInputManager.GetAxisRaw("Vertical");

            // Move the player around the scene.
            Move (h, v);

            // Turn the player to face the mouse cursor.
            Turning ();

            // Animate the player.
            Animating (h, v);
        }


        void Move (float h, float v)
        {
            // Set the movement vector based on the axis input.
            movement.Set (h, 0f, v);
            
            // Normalise the movement vector and make it proportional to the speed per second.
            movement = movement.normalized * speed * Time.deltaTime;

            // Move the player to it's current position plus the movement.
            playerRigidbody.MovePosition (transform.position + movement);
        }

// Get.Joystick.X
// JoyX = Joystick.X * 5
// Get.Joystick.Y
// JoyY = Joystick.Y * 5
// Richtung.Joy = Vector2(Joystick.X, Joystick.Y)
// player.Rigidbody.MoveRotation (Richtung.Joy)

// Vector3 turnDir = new Vector3(CrossPlatformInputManager.GetAxisRaw("Joystick X") , 0f , CrossPlatformInputManager.GetAxisRaw("Joystick Y"));
// if (turnDir != Vector3.zero)
// turnDir = Vector3 (turnDir.X * 5, turnDir.Y * 5)
// Vector3 playerToMouse = (transform.position + turnDir) - transform.position;
// playerToMouse.y = 0f;
// Quaternion newRotatation = Quaternion.LookRotation(playerToMouse);
// Set the player's rotation to this new rotation.
// playerRigidbody.MoveRotation(newRotatation);


        void Turning ()
           
        {
            // Create a ray from the mouse cursor on screen in the direction of the camera.
            //Ray camRay = Camera.main.ScreenPointToRay (Input.mousePosition);

            // Create a RaycastHit variable to store information about what was hit by the ray.
            //RaycastHit floorHit;

            // Perform the raycast and if it hits something on the floor layer...
            //if(Physics.Raycast (camRay, out floorHit, camRayLength, floorMask))
            //{
                // Create a vector from the player to the point on the floor the raycast from the mouse hit.
                //Vector3 playerToMouse = floorHit.point - transform.position;

                // Ensure the vector is entirely along the floor plane.
                //playerToMouse.y = 0f;

                // Create a quaternion (rotation) based on looking down the vector from the player to the mouse.
                //Quaternion newRotatation = Quaternion.LookRotation (playerToMouse);

                // Set the player's rotation to this new rotation.
                //playerRigidbody.MoveRotation (newRotatation);
            //}
            
            Vector3 turnDir = new Vector3(CrossPlatformInputManager.GetAxisRaw("Joystick X") * 5 , 0f * 0, CrossPlatformInputManager.GetAxisRaw("Joystick Y") * 5);
                Vector3 playerToMouse = (transform.position + turnDir) - transform.position;
                Quaternion newRotatation = Quaternion.LookRotation(playerToMouse);
                playerRigidbody.MoveRotation(newRotatation);

            

        }


        void Animating (float h, float v)
        {
            // Create a boolean that is true if either of the input axes is non-zero.
            bool walking = h != 0f || v != 0f;

            // Tell the animator whether or not the player is walking.
            anim.SetBool ("IsWalking", walking);
        }
    }
}