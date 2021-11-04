using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MezclaController : MonoBehaviour
{
    public GameObject ingredient1;
    public GameObject ingredient2;
    public GameObject ingredient3;
    public GameObject ingredient4;
    public GameObject ingredient5;
    public GameObject ingredient6;

    public List<GameObject> IngredientsList;
    public List<GameObject> CorrectIngredients;
    public List<string> CorrectIngredientsName;
    public List<string> SelectedIngredients;
    private bool correctIngredientsHaveBeenSelected;

    private void Start()
    {
        if (CorrectIngredients.Count > 0)
        {
            foreach (GameObject ing in CorrectIngredients)
            {
                CorrectIngredientsName.Add(ing.name);
            }
        }

        correctIngredientsHaveBeenSelected = false;
    }

    public void ShowMezcla(object btnName, object show)
    {
        bool stateShow = (("" + show) == "true")
                    ? true
                    : false;

        switch (btnName)
        {
            case "ingredient1":
                ingredient1.SetActive(stateShow);
                break;
            case "ingredient2":
                ingredient2.SetActive(stateShow);
                break;
            case "ingredient3":
                ingredient3.SetActive(stateShow);
                break;
            case "ingredient4":
                ingredient4.SetActive(stateShow);
                break;
            case "ingredient5":
                ingredient5.SetActive(stateShow);
                break;
            case "ingredient6":
                ingredient6.SetActive(stateShow);
                break;

        }
    }

    public void AddIngredient(string Name)
    {
        SelectedIngredients.Add(Name);
    }



    private void Update()
    {
        if (SelectedIngredients.Count == CorrectIngredients.Count && !correctIngredientsHaveBeenSelected)
        {
            if (CheckIngredients())
            {
                CorrectIngredientsSelected();
            }
            else
            {
                SelectedIngredients = new List<string>();
                IncorrectIngredientsSelected();

            }

        }
    }

    private bool CheckIngredients()
    {
        foreach (string ingredient in SelectedIngredients)
        {
            if (!CorrectIngredientsName.Contains(ingredient))
            {
                return false;
            }
        }
        return true;
    }

    public void CorrectIngredientsSelected()
    {
        correctIngredientsHaveBeenSelected = true;
        GameObject.Find("SimulationController").GetComponent<SimulationController>().VerifyUserAction(new SimulationObject.Action(gameObject.name, "CorrectIngredientsSelected", ""));
    }

    public void IncorrectIngredientsSelected()
    {
        GameObject.Find("SimulationController").GetComponent<SimulationController>().VerifyUserAction(new SimulationObject.Action(gameObject.name, "IncorrectIngredientsSelected", ""));
    }

}
