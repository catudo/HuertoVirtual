using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedController : MonoBehaviour
{
    public GameObject seed1;
    public GameObject seed2;

    public void ShowSeed(object btnName, object show)
    {
        bool stateShow = (("" + show) == "true")
                    ? true
                    : false;

        switch (btnName)
        {
            case "seed1":
                seed1.SetActive(stateShow);
                break;
            case "seed2":
                seed2.SetActive(stateShow);
                break;

        }
    }

}
