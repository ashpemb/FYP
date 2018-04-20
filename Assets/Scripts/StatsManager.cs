using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsManager : MonoSingleton<StatsManager> {

    public int burgersBuilt = 0;
    private void Start()
    {
        EventManager.E_PlayerFinishBurger += TakeStats;
    }

    void TakeStats(GameObject sender, PlayerBurgerArgs args)
    {
        if(args.burgerCorrect == true)
        {
            burgersBuilt++;
        }
        else
        {

        }
    }

}
