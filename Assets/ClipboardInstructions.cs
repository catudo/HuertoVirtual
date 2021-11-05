using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ClipboardInstructions : MonoBehaviour
{
    public TextMeshProUGUI text;
    public GameObject seedPic;
    // Start is called before the first frame update
    void Start()
    {
        ChangeInstructions("intro");
    }



    // Update is called once per frame
    public void ChangeLocation()
    {
        this.transform.position = new Vector3(7.078f, 0.104f, -4.39f);
    }

    public void ChangeInstructions(string stage)
    {
        switch (stage)
        {
            case "intro":
                text.SetText("Hola! Usame como referencia cuando necesitas ayuda o acordarte de informacion :). Puedes interactuar con las intrucciones con el boton de trigger. Puedes interactuar con los objetos en la escena usando el boton de grip.");
                break;
            case "semillero":
                text.SetText("El semillero ideal tendran hoyos para drenar. Los semilleros de arcilla tienden a tener hoyos mientras los de roca no.");
                break;
            case "ingredientes":
                text.SetText("Puedes destinguir los 5 ingredientes necesarios de la siguiente manera: Humus de lombriz tendra lombrizes, Fibra de coco tiene un color marron y se ven las fibras, Perlita es blanca, la tierra organica tiene un tinte oscuro, la vermiculita es un mix de color claro y oscuro.");
                break;
            case "semillaChoice":
                text.SetText("Compara las semillas con la imagen de referencia para saber que semillas debes elegir");
                seedPic.SetActive(true);
                break;
            case "sembrar":
                text.SetText("Recoge la semilla con el boton de grip y siembrala dentro del semillero!");
                seedPic.SetActive(false);
                break;
            case "regar":
                text.SetText("Recoge el regadero con el boton de grip y riega un litro de agua en el semillero");
                break;
            case "lugarDeCrecer":
                text.SetText("Debes elegir entre los dos puestos sugeridos. Eliges apuntando a la locacion y presionando el boton de grip. Recuerda que quieres maximizar la cantidad de luz que le llegara a los tomates");
                break;
            case "entorar":
                text.SetText("Recoge el entorador con el boton de grip y sueltalo dentro del semillero!");
                break;
            case "podar":
                text.SetText("Recoge la herramiento con el boton de grip y poda los brotes que han salido!");
                break;
            default:
                text.SetText("");
                seedPic.SetActive(false);
                break;
        }
    }
}
