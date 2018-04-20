using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildCorrectBurgers : PrimaryObjective {

    public override void Activated()
    {
        base.Activated();
        EventManager.E_PlayerFinishBurger += BurgerFinished;
    }

    void BurgerFinished(GameObject sender, PlayerBurgerArgs args)
    {
        if (args.burgerCorrect == true)
        {
            ++progress;
            ProgressChanged();
        }

        if (progress == maxProgress)
        {
            Complete();
        }

    }

    public override void Complete()
    {
        EventManager.E_PlayerFinishBurger -= BurgerFinished;
        
        base.Complete();
    }
}
