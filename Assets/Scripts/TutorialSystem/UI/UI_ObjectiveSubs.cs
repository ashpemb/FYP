using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UI_ObjectiveSubs : UI_Objective, IHasSubObjectives {

    public Text subObjectiveText;

    public void SetCurrentSubObjectiveText(string newSubObjective)
    {
        subObjectiveText.text = newSubObjective;
    }
}
