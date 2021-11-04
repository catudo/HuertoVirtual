using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationsController : MonoBehaviour
{
    public GameObject loc1;
    public GameObject loc2;

    public void ShowLoc(object btnName, object show)
    {
        bool stateShow = (("" + show) == "true")
                    ? true
                    : false;

        switch (btnName)
        {
            case "loc1":
                loc1.SetActive(stateShow);
                break;
            case "loc2":
                loc2.SetActive(stateShow);
                break;

        }
    }

}
