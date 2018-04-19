using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceBun : PrimaryObjective {

    public override void Activated()
    {
        base.Activated();
        EventManager.E_PlayerPlaceBun += BunPlaced;
    }

    void BunPlaced(GameObject sender, PlayerTutorialArgs args)
    {
        if (args.gameObject != null)
        {
            if (args.gameObject.GetComponent<Ingredient>().ingredientType == IngredientType.BottomBun)
            {
                Complete();
            }
        }

    }

    public override void Complete()
    {
        EventManager.E_PlayerPlaceBun -= BunPlaced;
        base.Complete();
    }
}
