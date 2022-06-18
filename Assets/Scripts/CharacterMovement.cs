using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{

    Animator anim;
    CharacterController characterController;

    public float speed = 6.0f;
    public float rotationSpeed = 25;
    public float jumpSpeed = 7.5f;
    public float garvity = 20.0f;

    Vector3 inputVector;
    Vector3 targetDirection;

    private Vector3 moveDirection = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        anim = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = -(Input.GetAxisRaw("Vertical"));
        float z = Input.GetAxisRaw("Horizontal");
        inputVector = new Vector3(x, 0, z);

        anim.SetFloat("Input X", z);
        anim.SetFloat("Input Z", -(x));
        
        if (x != 0 || z != 0)
        {
            anim.SetBool("Moving", true);
            anim.SetBool("Running", true);
        }
        else
        {
            anim.SetBool("Moving", false);
            anim.SetBool("Running", false);
        }

        //Jump
        if (characterController.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
            moveDirection *= speed;
        }
        characterController.Move(moveDirection * Time.deltaTime);
        updateMovement();

    }

    void updateMovement()
    {
        Vector3 motion = inputVector;
        motion *= (Mathf.Abs(inputVector.x) == 1 && Mathf.Abs(inputVector.z) == 1)?.7f:1;
        rotateTowardMovementDireation();
        getCameraRealtive();
    }

    void rotateTowardMovementDireation()
    {
        if(inputVector != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(targetDirection), Time.deltaTime * rotationSpeed);
        }
    }

    void getCameraRealtive()
    {
        Transform cameratransform = Camera.main.transform;
        Vector3 forward = cameratransform.TransformDirection(Vector3.forward);
        forward.y = 0;
        forward = forward.normalized;

        Vector3 right = new Vector3(forward.z, 0, -forward.x);
        float v = Input.GetAxisRaw("Vertical");
        float h = Input.GetAxisRaw("Horizontal");
        targetDirection = (h * right) + (v * forward);
    }
}
