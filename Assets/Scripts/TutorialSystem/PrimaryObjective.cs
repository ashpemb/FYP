using UnityEngine;
using System.Collections;

public class PrimaryObjective : Objective
{

    public bool hasSubObjectives;
    public SubObjective[] subObjectives;
    public int currentSubObjective;
    public bool hasProgress; //could use interface or inheritace for primary objectives with progress
    string progressToDisplay;
    public int progress;
    public int maxProgress;
    public bool sequential;
    public string[] nextObjectives;
    GameObject GUIPanel;
    GUI_Objective objectiveGUI;

    public override void Activated()
    {

        base.Activated();
        subObjectives = GetComponentsInChildren<SubObjective>();

        objectiveGUI = GUIPanel.GetComponent<GUI_Objective>();
        objectiveGUI.SetObjectiveDescriptionText(description);
        UpdateGUI();

        if (hasSubObjectives)
        {
            if (subObjectives[currentSubObjective] != null)
            {
                subObjectives[currentSubObjective].Activated();
            }
        }
        if (hasProgress)
        {
            progressToDisplay = progress.ToString() + "/" + maxProgress.ToString();
            UpdateGUI();
        }

    }


    public virtual void NextSubObjective()
    {
        if (hasSubObjectives)
        {
            if (currentSubObjective < subObjectives.Length - 1)
            {
                currentSubObjective++;
                subObjectives[currentSubObjective].Activated();
                UpdateGUI();
            }
        }
    }

    public virtual void ProgressChanged()
    {
        progressToDisplay = progress + "/" + maxProgress;
        UpdateGUI();
    }

    public override void Complete()
    {
        DestroyGUIPanelInstance();


        base.Complete();

        if (sequential)
        {
            for (int i = 0; i < nextObjectives.Length; i++)
            {
                ObjectiveManager.instance.LoadObjective(nextObjectives[i], 0, 0);
            }
        }

        ObjectiveManager.instance.RemoveActiveObjective(this);
    }

    public void SetGUIPanelPrefab(GameObject guiPanel)
    {
        GUIPanel = guiPanel;
    }
    public void DestroyGUIPanelInstance()
    {
        Destroy(GUIPanel);
    }

    void UpdateGUI()
    {
        if (hasProgress)
        {
            if (objectiveGUI is IHasProgress)
            {
                IHasProgress iHasProgress = objectiveGUI.GetComponent<IHasProgress>();
                iHasProgress.SetProgressText(progressToDisplay);
            }
        }
        if (hasSubObjectives)
        {
            if (objectiveGUI is IHasSubObjectives)
            {
                IHasSubObjectives iHasSubObjectives = objectiveGUI.GetComponent<IHasSubObjectives>();
                iHasSubObjectives.SetCurrentSubObjectiveText(subObjectives[currentSubObjective].description);
            }
        }
    }


}
