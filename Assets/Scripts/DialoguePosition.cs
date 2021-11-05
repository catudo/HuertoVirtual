using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialoguePosition : MonoBehaviour
{
    private Vector3 DragUpPos;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangePositionCorrectLocation()
    {
        //this.transform.localPosition = new Vector3(2.31f, 1.6f, 6.07f);
        //this.transform.Rotate(new Vector3(14.6f, 53.3f, 0f));
        this.transform.localPosition = new Vector3(7.558F, 0.77f, 7.59f);
        this.transform.Rotate(new Vector3(-2.8f, 88.863f, -1.941f));

        DragUpPos = this.transform.localPosition;

    }

    public void ChangePositionIncorrectLocation()
    {
        //this.transform.localPosition = new Vector3(2.31f, 1.6f, 6.07f);
        //this.transform.Rotate(new Vector3(14.6f, 53.3f, 0f));
        this.transform.localPosition = new Vector3(7.558F, 0.82f, 5.54f);
        this.transform.Rotate(new Vector3(-2.8f, 88.863f, -1.941f));
        DragUpPos = this.transform.localPosition;

    }

    public void DragDown()
    {
        this.transform.localPosition = new Vector3(2.31f, -10.6f, 6.07f);
    }

    public void DragUp()
    {
        //this.transform.localPosition = new Vector3(2.31f, 1.6f, 6.07f);
        this.transform.localPosition = DragUpPos;
    }
}
