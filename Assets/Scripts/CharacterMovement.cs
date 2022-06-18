using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{

    Animator anim;
    CharacterController characterContro;

    public float speed = 0f;
    public float rotationSpeed = 25;
    public float jumpSpeed = 7.5f;
    public float garvity = 20.0f;

    Vector3 inputVector;
    Vector3 targetDirection;

    private Vector3 moveDirection = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
