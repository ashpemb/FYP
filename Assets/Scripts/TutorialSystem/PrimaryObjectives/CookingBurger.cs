using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookingBurger : PrimaryObjective {

    public override void Activated()
    {
        base.Activated();
        EventManager.E_PlayerCookBurger += BurgerCooked;
    }

    void BurgerCooked(GameObject sender, PlayerTutorialArgs args)
    {
        Complete();

    }

    public override void Complete()
    {
        EventManager.E_PlayerCookBurger -= BurgerCooked;
        base.Complete();
    }
}
