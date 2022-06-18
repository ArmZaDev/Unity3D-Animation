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

        

    }

    
}
