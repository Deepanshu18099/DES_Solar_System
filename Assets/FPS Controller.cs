using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// [RequireComponent(typeof(CharacterController))]
public class FPSController : MonoBehaviour
{
    public Camera playerCamera;
    public float walkSpeed = 12f;
    public float runSpeed = 23f;
    public float jumpPower = 7f;
    public float lookfastSpeed = 3f;
    public float lookslowspeed = 1f;
    public float lookXLimit = 45f;

    Vector3 moveDirection = Vector3.zero;
    float rotationX = 0;

    public bool canMove = true;

    // CharacterController characterController;
     bool IsSet;

    float timeDelta;

    void Start()
    {
        // characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        IsSet = false;
    }

    void Update()
    {
        if(!IsSet)
        {
            timeDelta = Time.deltaTime;
            IsSet = true;
            Debug.Log("Hello " + timeDelta);
        }
        #region Handles Movement
         // Move the character controller
        Vector3 forward = transform.forward;
        Vector3 right = transform.right;
        Vector3 up = transform.up;

        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        float moveSpeed = isRunning ?  runSpeed : walkSpeed;
        float lookSpeed = isRunning ? lookfastSpeed : lookslowspeed;


        float inputX = Input.GetAxisRaw("Horizontal");
        float inputY = Input.GetAxisRaw("UpDown");
        float inputZ = Input.GetAxisRaw("Vertical");

        // debugging all the inputx
        // Debug.Log("Debug: " + inputX + ", " + inputY + ", "  + inputZ + "");

        Vector3 movement = (forward * inputZ + right * inputX + up * inputY) * moveSpeed * timeDelta;

        // Debug.Log(movement + " fffff ");

        // Move the player regardless of time scale
        transform.position += movement;
        #endregion

        #region Handles Rotation
        float mouseX = Input.GetAxis("Mouse X") * lookSpeed;
        float mouseY = -Input.GetAxis("Mouse Y") * lookSpeed; // Inverted Y-axis

        rotationX += mouseY;
        rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);

        playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
        transform.rotation *= Quaternion.Euler(0, mouseX, 0);
        #endregion
    }
}