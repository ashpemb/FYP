using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct BurgerOrder
{
    public List<Ingredient> OrderList;
    //public BurgerOrder(int i)
    //{
    //    OrderList = new List<Ingredient>();
    //}
}

enum BURGERLAYERS
{
    bunALayer = 20,
    bunBLayer = 21,
    cheeseLayer = 22,
    saladLayer = 23,
    tomatoLayer = 24,
    burgerLayer = 25
}

public enum IngredientType
{
    Burger,
    Cheese,
    BunA,
    BunB,
    Tomato,
    Salad
}


public class Commons {

    
}
