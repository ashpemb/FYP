using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpBurger : PrimaryObjective {

    public override void Activated()
    {
        base.Activated();
        EventManager.E_PlayerPickUpBurger += BurgerPickedUp;
    }

    void BurgerPickedUp(GameObject sender, PlayerTutorialArgs args)
    {
        if (sender.GetComponent<VRInput>().GetPickUp().GetComponent<Ingredient>() != null)
        {
            if (sender.GetComponent<VRInput>().GetPickUp().GetComponent<Ingredient>().ingredientType == IngredientType.Burger)
            {
                Complete();
            }
        }
        
    }

    public override void Complete()
    {
        EventManager.E_PlayerPickUpBurger -= BurgerPickedUp;
        base.Complete();
    }
}
