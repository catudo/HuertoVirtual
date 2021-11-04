using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingrediente : MonoBehaviour
{
    public Collider coll;
    public GameObject MezclaGO;
    private MezclaController controller;


    // Start is called before the first frame update
    void Start()
    {
        coll = GetComponent<Collider>();
        //MezclaGO = GameObject.FindGameObjectWithTag("MezcalController");
        controller = MezclaGO.GetComponent<MezclaController>();

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

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (coll.Raycast(ray, out hit, 100.0f))
            {
                Debug.Log("you selected" + gameObject.name);
                //Select();


            }
        }
    }

    public void IngredientAdd()
    {
        controller.AddIngredient(gameObject.name);
        gameObject.SetActive(false);
    }

    public void Select()
    {
        GameObject.Find("SimulationController").GetComponent<SimulationController>().VerifyUserAction(new SimulationObject.Action(gameObject.name, "Select", ""));
    }
}
