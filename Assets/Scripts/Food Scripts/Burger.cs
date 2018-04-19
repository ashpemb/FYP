using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Burger : Ingredient {

    public int cookState = 0;
    public Burger()
    {
        ingredientType = IngredientType.Burger;
    }
}
