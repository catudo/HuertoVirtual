//
//  ReminderController.cs
//  Tweenity
//
//  Created by Vivian Gómez.
//  Copyright © 2021 Vivian Gómez - Pablo Figueroa - Universidad de los Andes
//

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReminderController : MonoBehaviour
{
    static GameObject reminder;
    void Start()
    {
        reminder = gameObject;
    }

    private void Update()
    {
        reminder.transform.Rotate(0, 0, 1);
    }

    public void MoveOverObject(string obj)
    {
        GameObject objeto = GameObject.Find(obj);
        var x = objeto.transform.position.x;
        var y = objeto.transform.position.y;
        var z = objeto.transform.position.z;

        reminder.transform.position = new Vector3(x, y + 0.65f, z);

        if (objeto.GetComponent<OutlineManager>() != null)
        {
            print("Tiene el componente OutlineManager");
            OutlineManager outline = objeto.GetComponent<OutlineManager>();
            outline.ShowObjectiveColor();
        }
        else if (GetParentObject(objeto).GetComponent<OutlineManager>() != null)
        {
            print("El padre tiene el componente OutlineManager");
            OutlineManager outline = GetParentObject(objeto).GetComponent<OutlineManager>();
            outline.ShowObjectiveColor();
        }
    }

    public static void HideReminder()
    {
        if (reminder != null)
            reminder.transform.position = new Vector3(-2.37f, 1.551f, -0.341f);
    }

    public GameObject GetParentObject(GameObject objeto)
    {
        //Debug.Log("Entered this weird thing");
        //Debug.Log(objeto.transform.parent.gameObject);
        return objeto.transform.parent.gameObject;
    }
}
