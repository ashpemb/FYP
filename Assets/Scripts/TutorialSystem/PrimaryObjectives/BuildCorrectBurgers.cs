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
            GameManager.instance.NewOrder();
        }
        else
        {
            sender.GetComponent<BurgerBuilder>().DeleteChildren();
        }

        if (progress == maxProgress)
        {
            Complete();
        }

    }

    public override void Complete()
    {
        EventManager.E_PlayerFinishBurger -= BurgerFinished;
        GameManager.instance.NewOrder();
        base.Complete();
    }
}
