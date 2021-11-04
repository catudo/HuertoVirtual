using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entorado : MonoBehaviour
{
    public Collider coll;
    private Vector3 mOffset;
    private float mZCoord;
    private bool pickup = true;
    public Transform PotLocation;

    // Start is called before the first frame update
    void Start()
    {
        coll = GetComponent<Collider>();
    }

    public void activatePickUp()
    {
        //Destroy(this.GetComponent<Rigidbody>());
        pickup = !pickup;
        //this.GetComponent<Rigidbody>().velocity = Vector3.zero;
        this.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 90));
        //this.transform.localPosition = new Vector3(0.61f, 0.64f, 0.86f);
        this.transform.position = new Vector3(PotLocation.position.x, PotLocation.position.y + 0.7f, PotLocation.position.z);
        this.GetComponent<Rigidbody>().isKinematic = true;
        this.GetComponent<Rigidbody>().velocity = Vector3.zero;
    }

    void FixedUpdate()
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

        //if (Input.GetMouseButtonDown(0) && !pickup)
        //{
        //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //    RaycastHit hit;

        //    if (coll.Raycast(ray, out hit, 100.0f))
        //    {
        //        Debug.Log("you selected" + gameObject.name);
        //        Select();
        //    }
        //}

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

    //public void Select()
    //{
    //    GameObject.Find("SimulationController").GetComponent<SimulationController>().VerifyUserAction(new SimulationObject.Action(gameObject.name, "Select", ""));
    //}
}
