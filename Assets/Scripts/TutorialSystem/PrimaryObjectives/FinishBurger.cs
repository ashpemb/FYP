using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishBurger : PrimaryObjective {

    public override void Activated()
    {
        base.Activated();
        EventManager.E_PlayerFinishBurger += BurgerFinished;
    }

    void BurgerFinished(GameObject sender, PlayerBurgerArgs args)
    {
        if (args.burgerCorrect == true)
        {
            Complete();
        }
        else
        {
            sender.GetComponent<BurgerBuilder>().DeleteChildren();
        }

    }

    public override void Complete()
    {
        EventManager.E_PlayerFinishBurger -= BurgerFinished;
        GameManager.instance.NewOrder();
        base.Complete();
    }
}
