using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grow : MonoBehaviour
{
    float growth;
    public float growthSpeed = 1;
    [SerializeField] List<Vegetable> vegetables;

    // Start is called before the first frame update
    void Start()
    {
        this.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        growth = 0.1f;
    }

    void Growth()
    {
        growth += Time.deltaTime * growthSpeed;
        growth = Mathf.Clamp(growth, 0.1f, 1);

        this.transform.localScale = new Vector3(growth, growth, growth);
    }

    // Update is called once per frame
    void Update()
    {
        //Growth();
        growth += Time.deltaTime * growthSpeed;
        growth = Mathf.Clamp(growth, 0.1f, 1);

        if (growth >= 1)
        {
            foreach (Vegetable veg in vegetables)
            {
                veg.isGrowing = true;
            }
        }
    }
}
