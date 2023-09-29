using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsManager : MonoSingleton<StatsManager> {

    public Stats currentSession;
    public bool isInTutorial = false;
    float fpsTimer=0;

    private void Start()
    {
        SaveLoad.Load();
        currentSession = new Stats();
        if (SaveLoad.savedStats.Count != 0)
        {
            currentSession.run = SaveLoad.savedStats[SaveLoad.savedStats.Count - 1].run + 1;
        }
        else
        {
            currentSession.run = 1;
        }
        EventManager.E_PlayerFinishBurger += TakeStats;
    }

    private void Update()
    {
        if (isInTutorial == true)
        {
            currentSession.tutorialTime += Time.deltaTime;
        }
        fpsTimer += Time.deltaTime;
        if (fpsTimer >= 1.0f)
        {
            currentSession.fps.Add((int)(1 / Time.deltaTime));
            fpsTimer = 0;
        }
    }

    void TakeStats(GameObject sender, PlayerBurgerArgs args)
    {
        if(args.burgerCorrect == true)
        {
            currentSession.burgersCreated++;
            currentSession.burgerTimes.Add(args.timeTaken);
        }
        else
        {
            currentSession.incorrectOrders++;
        }
    }

    private void OnApplicationQuit()
    {
        SaveLoad.Save(currentSession);
    }

}
