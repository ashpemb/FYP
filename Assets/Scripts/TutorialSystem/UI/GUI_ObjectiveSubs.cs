using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GUI_ObjectiveSubs : GUI_Objective, IHasSubObjectives {

    public Text subObjectiveText;

    public void SetCurrentSubObjectiveText(string newSubObjective)
    {
        subObjectiveText.text = newSubObjective;
    }
}
