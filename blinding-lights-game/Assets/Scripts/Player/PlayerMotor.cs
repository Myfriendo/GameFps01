using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour


{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool isGrounded;
    private bool lerpCrouch;
    private bool crouching;
    private bool sprinting;
    public float crouchTimer;
    public float speed = 5f;
    [SerializeField] public float gravity = -9.81f;
    public float jumpHeight = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = controller.isGrounded;
        if(lerpCrouch)
        {   
            crouchTimer += Time.deltaTime /1;
            float p = crouchTimer / 1;
            p*=p;
            if(crouching)
            {
                controller.height = Mathf.Lerp(controller.height, 1f, p);
            }
            else
            {
                controller.height = Mathf.Lerp(controller.height, 2f, p);
            }
            crouchTimer += Time.deltaTime * 3;
            if(p > 1)
            {
                lerpCrouch = false;
                crouchTimer = 0;
            }
        }
    }
    public void ProcessMove(Vector2 input)
    {
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = input.x;
        moveDirection.z = input.y;
        controller.Move(transform.TransformDirection(moveDirection) * (speed * Time.deltaTime));
        playerVelocity.y += gravity * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
        // expensive
        //Debug.Log(playerVelocity.y); // not needed
    }
    
    public void Jump()
    {
        if (isGrounded)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -5f * gravity);
        }
    }
    
    public void Crouch()
    {
        //controller.height = 1f;
        crouching = !crouching;
        crouchTimer = 0;
        lerpCrouch = true;
    }
    
    public void Sprint()
    {   
        sprinting = !sprinting;
        if(sprinting)
        {
            speed = 8f;
        }
        else
        {
            speed = 5f;
        }
    }
}
