using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeedController : MonoBehaviour
{
    public GameObject weed1;
    public GameObject weed2;

    public void ShowWeed(object btnName, object show)
    {
        bool stateShow = (("" + show) == "true")
                    ? true
                    : false;

        switch (btnName)
        {
            case "weed1":
                weed1.SetActive(stateShow);
                break;
            case "weed2":
                weed2.SetActive(stateShow);
                break;

        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
