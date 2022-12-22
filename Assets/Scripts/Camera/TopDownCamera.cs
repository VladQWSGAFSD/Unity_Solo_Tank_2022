using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownCamera : MonoBehaviour
{
    //Variables
    [SerializeField] Transform lookAt;
    [SerializeField] float height = 7f;
    [SerializeField] float distance = 7f;
    [SerializeField] float angle = 0f;
    [SerializeField] float smoothSpeed = 3f;
    Vector3 refVelocity;
    //End Variables

    //Main
    // Start is called before the first frame update
    void Start()
    {
        //MoveCamera();
    }

    // Update is called once per frame
    void Update()
    {
        MoveCamera();
    }
    //End Main

    //Everything else
    protected virtual void MoveCamera()
    {
        if (!lookAt)
        {
            //If you have no target don't execute method
            return;
        }

        //Create world position by going backwards and up 
        Vector3 worldPosition = (Vector3.forward * -distance) + (Vector3.up * height);
        //Debug.DrawLine(target.position, worldPosition, Color.red);

        //Create a vector that will rotate camera
        Vector3 rotatedVector = Quaternion.AngleAxis(angle, Vector3.up) * worldPosition;
        //Debug.DrawLine(target.position, rotatedVector, Color.green);

        //Move the position 
        Vector3 flatTargetPosition = lookAt.position;
        flatTargetPosition.y = 0f; //Camera will not be moving up nor down 
        Vector3 finalPosition = flatTargetPosition + rotatedVector;
        //Debug.DrawLine(target.position, finalPosition, Color.blue);

        //Smooth the movement of the camera
        transform.position = Vector3.SmoothDamp(transform.position, finalPosition, ref refVelocity, smoothSpeed);
        transform.LookAt(flatTargetPosition);

    }


}
