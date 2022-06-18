using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    private const float SMOTH_TIME = 0.3f;
    public bool LockX, LockY, LockZ;
    public float offSetZ = -3f;
    public bool useSmoothing = true;

    public Transform target;
    private Transform thisTransform;

    private Vector3 velocity;

    private void Awake()
    {
        thisTransform = transform;
        velocity = new Vector3(0.5f, 0.5f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        var newPos = Vector3.zero;

        if (useSmoothing)
        {
            newPos.x = Mathf.SmoothDamp(thisTransform.position.x,target.position.x,ref velocity.x,SMOTH_TIME);
            newPos.y = Mathf.SmoothDamp(thisTransform.position.y,target.position.y,ref velocity.y,SMOTH_TIME);
            newPos.z = Mathf.SmoothDamp(thisTransform.position.z,target.position.z + offSetZ,ref velocity.z,SMOTH_TIME);
        }
        else
        {
            newPos.x = target.position.x;
            newPos.y = target.position.y;
            newPos.z = target.position.z;
        }

        if (LockX)
        {
            newPos.x = thisTransform.position.x;
        }
        if (LockY)
        {
            newPos.y = thisTransform.position.y;
        }
        if (LockZ)
        {
            newPos.z = thisTransform.position.z;
        }
        transform.position = Vector3.Slerp(thisTransform.position, newPos, Time.time);



    }
}
