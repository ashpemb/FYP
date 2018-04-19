using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GUI_ObjectiveProgressSubs : GUI_ObjectiveProgress, IHasSubObjectives {

    public Text subObjectiveText;

    public void SetCurrentSubObjectiveText(string newSubObjective)
    {
        subObjectiveText.text = newSubObjective;
    }
}
