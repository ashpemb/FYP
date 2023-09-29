using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UI_ObjectiveProgress : UI_Objective,IHasProgress {

    public Text objectiveProgress;

    public void SetProgressText(string newProgress)
    {
        objectiveProgress.text = newProgress;
    }
}
