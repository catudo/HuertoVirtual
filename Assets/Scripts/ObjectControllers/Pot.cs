using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Pot : MonoBehaviour
{
    public bool selected;
    public Collider coll;
    private bool plantado = false;
    private Vector3 oldSize = new Vector3(2, 2, 2);
    private Vector3 newSize = new Vector3(3.4f, 4.6f, 3.4f);
    

    // Start is called before the first frame update
    void Start()
    {
        selected = false;
        coll = GetComponent<Collider>();

    }

    // Update is called once per frame
    //void Update()
    //{

    //}

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

        

/*
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (coll.Raycast(ray, out hit, 100.0f))
            {
                Debug.Log("you selected" + gameObject.name);
                Select();
            }
        }*/
    }


    public void Select()
    {
        GameObject.Find("SimulationController").GetComponent<SimulationController>().VerifyUserAction(new SimulationObject.Action(gameObject.name, "Select", ""));
    }

    public void DestroyPot()
    {
        Destroy(gameObject);
    }

    public void TransformPosition()
    {
        gameObject.transform.position = new Vector3(6.49f, 0.7f, -2.04f);
        gameObject.transform.localScale = newSize;
        //gameObject.transform.position = new Vector3(6.49f, 0.02f, -2.04f);
        
    }

    public void TransformPositionWrong()
    {
        gameObject.transform.localScale = newSize;
        //gameObject.transform.position = new Vector3(6.49f, 0.02f, -5.59f);
        gameObject.transform.position = new Vector3(6.49f, 0.7f, -5.59f);
    }

    void OnCollisionEnter(Collision col)
    {
        Debug.Log("The following is hittin the pot " + col.gameObject.name);

        if (col.gameObject.name == "SemillaCorrecta")
        {
            Debug.Log(col.gameObject.name);
            Plant();
        }
        if (col.gameObject.name == "Entorado" && !plantado)
        {
            Entutorado();
            plantadoSwitch();
        }
    }

    public void plantadoSwitch()
    {
        plantado = true;
    }

    public void Plant()
    {
        GameObject.Find("SimulationController").GetComponent<SimulationController>().VerifyUserAction(new SimulationObject.Action(gameObject.name, "Plant", ""));
    }
    public void Entutorado()
    {
        GameObject.Find("SimulationController").GetComponent<SimulationController>().VerifyUserAction(new SimulationObject.Action(gameObject.name, "Entutorado", ""));
    }
}
