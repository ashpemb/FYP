using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


public class ObjectiveManager : MonoSingleton<ObjectiveManager>
{


    public GameObject ObjectiveUI;
    
    public List<PrimaryObjective> primaryObjectives = new List<PrimaryObjective>();
    public Dictionary<string, PrimaryObjective> objectivesDictionary = new Dictionary<string, PrimaryObjective>();
    public List<PrimaryObjective> activeObjectives = new List<PrimaryObjective>(); //use for saving/loading


    public void Start()
    {
        primaryObjectives = GetComponentsInChildren<PrimaryObjective>().ToList();

        foreach (PrimaryObjective primaryObjective in primaryObjectives)
        {
            objectivesDictionary.Add(primaryObjective.nameOfObjective, primaryObjective);
        }

        LoadObjective("StartTutorial", 0, 0); //loads first objective
    }



    public GameObject CreateObjectivePanel(bool hasProgress, bool hasTips)
    {
        //there are four prefabs that have been set up to accomodate different objective attibutes
        string GUIPrefabPath;
        if (hasProgress)
        {
            if (hasTips)
            {
                GUIPrefabPath = "Objective_Tips+Progress";
            }
            else
            {
                GUIPrefabPath = "Objective_Progress";
            }
        }
        else
        {
            if (hasTips)
            {
                GUIPrefabPath = "Objective_Tips";
            }
            else
            {
                GUIPrefabPath = "Objective_Basic";
            }
        }

        GameObject newObjectiveGUI = Instantiate(Resources.Load("GUI/" + GUIPrefabPath), ObjectiveUI.transform) as GameObject;
        return newObjectiveGUI;
    }

    public void LoadObjective(string key, int subObjectiveStep, int progressToLoad)
    {
        PrimaryObjective objectiveToLoad = objectivesDictionary[key];
        objectiveToLoad.currentSubObjective = subObjectiveStep;
        objectiveToLoad.progress = progressToLoad;
        objectiveToLoad.ProgressChanged();

        objectiveToLoad.SetGUIPanelPrefab(CreateObjectivePanel(objectiveToLoad.hasProgress, objectiveToLoad.hasSubObjectives));
        objectiveToLoad.Activated();

        activeObjectives.Add(objectivesDictionary[key]);

    }

    public void RemoveActiveObjective(PrimaryObjective toRemove)
    {
        activeObjectives.Remove(toRemove);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.S))
        {
            foreach (PrimaryObjective a in activeObjectives)
            {
                a.Complete();
            }
        }
    }

    #region saving/loading
    public ObjectiveData SaveObjectives()
    {
        string[] keysToSave = new string[activeObjectives.Count];
        int[] stepsToSave = new int[activeObjectives.Count];
        int[] progressValues = new int[activeObjectives.Count];

        for (int i = 0; i < activeObjectives.Count; i++)
        {
            keysToSave[i] = activeObjectives[i].nameOfObjective;
            stepsToSave[i] = activeObjectives[i].currentSubObjective;
            progressValues[i] = activeObjectives[i].progress;

        }
        ObjectiveData dataToSave = new ObjectiveData(keysToSave, stepsToSave, progressValues);
        return dataToSave;

    }

    public void LoadObjectives(ObjectiveData dataToLoad)
    {
        if (activeObjectives.Count > 0)
        {
            for (int i = 0; i < activeObjectives.Count; i++)
            {
                activeObjectives[i].DestroyGUIPanelInstance();
                activeObjectives.Remove(activeObjectives[i]);
            }

        }
        string[] keysToLoad = dataToLoad.activeKeys;
        int[] stepsToLoad = dataToLoad.subObjectiveSteps;
        int[] progressToLoad = dataToLoad.progressValues;
        for (int i = 0; i < keysToLoad.Length; i++)
        {
            LoadObjective(keysToLoad[i], stepsToLoad[i], progressToLoad[i]);
        }


    }

}

//serializable data for saving and loading objectives
[System.Serializable]
public class ObjectiveData
{
    public string[] activeKeys;
    public int[] subObjectiveSteps;
    public int[] progressValues;
    public ObjectiveData(string[] keys, int[] subSteps, int[] progressVals)
    {
        activeKeys = keys;
        subObjectiveSteps = subSteps;
        progressValues = progressVals;
    }
}
#endregion