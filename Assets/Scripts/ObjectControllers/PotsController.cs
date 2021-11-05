using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotsController : MonoBehaviour
{
    public GameObject pot1;
    public GameObject pot2;
    public GameObject WaterContainer;
    public GameObject plant;
    public GameObject entorado;

    PourDetector PourTrigger;
    public List<string> potsToGrow = new List<string>();
    [SerializeField] List<Vegetable> vegetables;

    private float size = 0f;
    public float speed = 0.25f;
    bool inRange = false;
    bool firstGrowth = false;
    bool secondGrowth = false;
    private float plantSize = 0f;
    public float sizeFactor = 0.5f;
    public int BrotesRemoved = 0;
    private bool firstStepAlreadyGrown = false;
    private bool secondtStepAlreadyGrown = false;
    private float fruitSize;

    private void Start()
    {
        PourTrigger = WaterContainer.GetComponent<PourDetector>();
    }

    public void ShowPot(object btnName, object show)
    {
        bool stateShow = (("" + show) == "true")
                    ? true
                    : false;

        switch (btnName)
        {
            case "pot1":
                pot1.SetActive(stateShow);
                break;
            case "pot2":
                pot2.SetActive(stateShow);
                break;

        }
    }

    public void ShowEntorado()
    {
        entorado.SetActive(true);
    }

    public void Grow(object potName)
    {
        Debug.Log("Adding Name!");
        potsToGrow.Add((string)potName);
    }

    public void PlantGrew()
    {
        Debug.Log("Plant Grew");
        Debug.Log(gameObject.name);
        GameObject.Find("SimulationController").GetComponent<SimulationController>().VerifyUserAction(new SimulationObject.Action(gameObject.name, "PlantGrew", ""));

    }

    public void PlantGrewFirstStage()
    {
        Debug.Log("executing growing first stage");
        GameObject.Find("SimulationController").GetComponent<SimulationController>().VerifyUserAction(new SimulationObject.Action(gameObject.name, "PlantGrewFirstStage", ""));

    }

    public void PlantGrewSecondStage()
    {
        GameObject.Find("SimulationController").GetComponent<SimulationController>().VerifyUserAction(new SimulationObject.Action(gameObject.name, "PlantGrewSecondStage", ""));

    }

    public void GrowFirstStep()
    {
        if (!firstStepAlreadyGrown)
        {
           firstGrowth = true;
            plantSize = 0;
            firstStepAlreadyGrown = true;
        }
 

    }

    public void GrowSecondStep(string idealLocation)
    {
        if (!secondtStepAlreadyGrown)
        {
           sizeFactor = idealLocation == "true" ? sizeFactor : sizeFactor * 0.65f ;
            fruitSize = idealLocation == "true" ? 0.85f : 0.65f;
            secondGrowth = true;
            plantSize = 0.3f;
            secondtStepAlreadyGrown = true;
        }


    }

    public void BroteRemoved()
    {
        BrotesRemoved++;
        Debug.Log("Se han quitado " + BrotesRemoved + " brotes");

        if (BrotesRemoved == 2)
        {
            AllBrotesRemoved();
        }
    }

    public void AllBrotesRemoved()
    {
        GameObject.Find("SimulationController").GetComponent<SimulationController>().VerifyUserAction(new SimulationObject.Action(gameObject.name, "AllBrotesRemoved", ""));

    }

    private void Update()
    {
        Vector2 XZposPot = new Vector2(pot1.transform.position.x, pot1.transform.position.z);
        Vector2 XZWaterCont = new Vector2(WaterContainer.transform.position.x, WaterContainer.transform.position.z);
        //float distanceToContainer = Vector3.Distance(pot1.transform.position, WaterContainer.transform.position);
        float distanceToContainer = Vector2.Distance(XZposPot, XZWaterCont);

        inRange = distanceToContainer < 0.9 ? true : false;
        Debug.Log("inRange:" + inRange);

        //if (potsToGrow.Contains("pot1") && inRange && PourTrigger.isPouring)
        if (inRange && PourTrigger.isPouring)
        {
            size += Time.deltaTime * speed;
            size = Mathf.Clamp(size, 0, 1);
            Debug.Log("We have begin to pour" + size);

            if (size >= 1)
            {
                //potsToGrow.Remove("pot1");
                PlantGrew();

            }

            //if (size >= 1)
            //{
            //    foreach (Vegetable veg in vegetables)
            //    {
            //        veg.isGrowing = true;
            //    }
            //}
        }

        if (firstGrowth || secondGrowth)
        {
            //float limit = firstGrowth ? 0.3f : secondGrowth ? 1.0f : 0.3f;
            plantSize += Time.deltaTime * speed;
            //plantSize = Mathf.Clamp(size, 0, limit);
            plant.transform.localScale = new Vector3(plantSize, plantSize, plantSize) * sizeFactor;

            if (plantSize >= 0.3 && firstGrowth)
            {
                //potsToGrow.Remove("pot1");
                //PlantGrewFirstStage();
                firstGrowth = false;
                PlantGrewFirstStage();
            }
            if (plantSize >= 1 && secondGrowth)
            {
                secondGrowth = false;
                foreach (Vegetable veg in vegetables)
                {
                    veg.isGrowing = true;
                    veg.growthFactor = fruitSize;
                }
                PlantGrewSecondStage();

            }

        }


    }
}
