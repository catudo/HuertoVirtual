using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ClipboardInstructions : MonoBehaviour
{
    public TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        ChangeInstructions("intro");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeInstructions(string stage)
    {
        switch (stage)
        {
            case "intro":
                text.SetText("Hola! Usame como referencia cuando necesitas ayuda o acordarte de informacion :)");
                break;
            case "semillero":
                text.SetText("El semillero ideal tendran hoyos para drenar. Los semilleros de arcilla tienden a tener hoyos mientras los de roca no.");
                break;
            case "ingredientes":
                break;
            default:
                text.SetText("");
                break;
        }
    }
}
