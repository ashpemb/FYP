using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UI_ObjectiveProgressSubs : UI_ObjectiveProgress, IHasSubObjectives
{

    public Text subObjectiveText;

    public void SetCurrentSubObjectiveText(string newSubObjective)
    {
        subObjectiveText.text = newSubObjective;
    }
}
