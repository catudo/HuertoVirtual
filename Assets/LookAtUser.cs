using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtUser : MonoBehaviour
{
    public Transform userLocation;
    float turnSpeed = 20f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 LookAtDirection = (userLocation.transform.position - this.transform.position).normalized;
        LookAtDirection.y = 0;
        Quaternion to = Quaternion.LookRotation(LookAtDirection, Vector3.up);
        this.transform.rotation = Quaternion.RotateTowards(this.transform.rotation, to, turnSpeed);
    }
}
