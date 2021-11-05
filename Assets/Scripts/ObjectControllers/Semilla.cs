using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Semilla : MonoBehaviour
{
    public Collider coll;
    private Vector3 mOffset;
    private float mZCoord;
    private bool pickup = false;
    private Vector3 stationaryPosition;

    // Start is called before the first frame update
    void Start()
    {
        coll = GetComponent<Collider>();
        stationaryPosition = this.transform.position;
    }

    public void activatePickUp()
    {
        pickup = true;
    }

    void Update()
    {
        //creates a ray that originates from the position of the mouse
        //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //RaycastHit data;

        //if (Physics.Raycast(ray, out data, 100) && Input.GetMouseButtonDown(0))
        //{
        //    Debug.Log("you selected" + gameObject.name);
        //    selected = true;
        //    //Select();
        //}

        /*        if (Input.GetMouseButtonDown(0) && !pickup)
                {
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    RaycastHit hit;

                    if (coll.Raycast(ray, out hit, 100.0f))
                    {
                        Debug.Log("you selected" + gameObject.name);
                        Select();
                    }
                }*/

        if (!pickup)
        {
            this.transform.position = stationaryPosition;
        }

    }

    void OnMouseDown()
    {
        if (pickup)
        {
            mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;

            mOffset = gameObject.transform.position - GetMouseWorldPos();
        }

    }

    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;

        mousePoint.z = mZCoord;

        return Camera.main.ScreenToWorldPoint(mousePoint);

    }

    private void OnMouseDrag()
    {
        if (pickup)
        {
            transform.position = GetMouseWorldPos() + mOffset;
        }

    }

    public void Select()
    {
        if (!pickup)
        {
            GameObject.Find("SimulationController").GetComponent<SimulationController>().VerifyUserAction(new SimulationObject.Action(gameObject.name, "Select", ""));
        }
        
    }
}
