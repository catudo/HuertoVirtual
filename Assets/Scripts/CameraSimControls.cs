using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSimControls : MonoBehaviour
{
    Vector3 finalPos;
    Quaternion finalRot;


    // Start is called before the first frame update
    void Start()
    {
        finalPos = this.transform.position;
        finalRot = this.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(this.transform.position, finalPos);

        if (distance > 0.05)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, finalPos, Time.deltaTime);
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, finalRot, 0.05f);

        }
    }

    public void ZoomOutTable()
    {
        finalPos = new Vector3(0, 1.55f, -10.1f);
        finalRot = Quaternion.Euler(3.93f, 0, 0);

    }

    public void ZoomInToTable()
    {
        finalPos = new Vector3(0, 1.55f, -8);
        finalRot = Quaternion.Euler(52.4f, 0, 0);
    }

    public void ZoomOutToBalcony()
    {
        finalPos = new Vector3(-2.505672f, 2.086575f, -8.794814f);
        finalRot = Quaternion.Euler(13.384f, 44.863f, 0);
    }

    public void ZoomInNewLocation()
    {
        /*finalPos = new Vector3(4.7f, 0.75f, -3.5f);
        finalRot = Quaternion.Euler(17.509f, 53.457f, 0);*/
        finalPos = new Vector3(4.75f, 0.75f, -2.711f);
        finalRot = Quaternion.Euler(0f, 90f, 0);
    }

    public void ZoomInNewLocationWrong()
    {
/*        finalPos = new Vector3(4.7f, 0.75f, -7.05f);
        finalRot = Quaternion.Euler(17.509f, 53.457f, 0);*/
        finalPos = new Vector3(4.75f, 0.75f, -5.75f);
        finalRot = Quaternion.Euler(0f, 90f, 0);
    }
}
