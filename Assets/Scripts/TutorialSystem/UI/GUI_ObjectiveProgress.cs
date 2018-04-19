using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GUI_ObjectiveProgress : GUI_Objective,IHasProgress {

    public Text objectiveProgress;

    public void SetProgressText(string newProgress)
    {
        objectiveProgress.text = newProgress;
    }
}
