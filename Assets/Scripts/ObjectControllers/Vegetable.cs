using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vegetable : MonoBehaviour
{
    public bool isGrowing;
    float growthSpeed = 0.5f;
    float growth;

    void Grow()
    {
        growth += Time.deltaTime * growthSpeed;
        growth = Mathf.Clamp(growth, 0.1f, 1);

        this.transform.localScale = new Vector3(growth, growth, growth);
    }

    // Start is called before the first frame update
    void Start()
    {
        isGrowing = false;
        growth = 0;
        this.transform.localScale = new Vector3(growth, growth, growth);
    }

    // Update is called once per frame
    void Update()
    {
        if (isGrowing)
        {
            Grow();
        }
    }
}
