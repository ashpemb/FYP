using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UI_Objective: MonoBehaviour {

    public Text objectiveDescription;

    public void SetObjectiveDescriptionText (string description)
    {
        objectiveDescription.text = description;
    }

}
