using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAPI;

public class CameraMove : NetworkBehaviour
{
    public Transform target;
    public float smooth = 10.0f;
    public Vector3 offset = new Vector3(0, 15, -15);
    private Vector3 maxoffset = new Vector3(0, 20, -19);
    private Vector3 minoffset = new Vector3(0, 4, -3);

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, target.position + offset, Time.deltaTime * smooth);

        if (Input.mouseScrollDelta.y > 0.0f) 
        {
            if (offset.y > minoffset.y) 
            {
                offset += Vector3.down;
                offset += Vector3.forward;
            }
        }
        
        if (Input.mouseScrollDelta.y < 0.0f) 
        {
            if (offset.y < maxoffset.y)
            {
                offset += Vector3.up;
                offset += Vector3.back;
            }
        }
        
    }
}
