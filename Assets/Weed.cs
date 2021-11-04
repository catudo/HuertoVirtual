using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weed : MonoBehaviour
{
    public Transform HoeTransform;
    public float distanceFromHoe = 0.5f;
    public GameObject potsController;
    private PotsController controller;

    // Start is called before the first frame update
    void Start()
    {
        controller = potsController.GetComponent<PotsController>();

    }

    public void ShowWeed()
    {
        gameObject.SetActive(true);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Vector3.Distance(this.transform.position, HoeTransform.position) < distanceFromHoe)
        {
            PullWeed();
        }
    }
    public void PullWeed()
    {
        gameObject.SetActive(false);
        controller.BroteRemoved();
    }
}
