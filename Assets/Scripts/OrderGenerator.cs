using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderGenerator : MonoSingleton<OrderGenerator> {

    public BunA bunA;
    public Burger burger;
    public BunB bunB;
    public Cheese cheese;
    public Tomato tomato;
    public Salad salad;

    public List<Ingredient> GenerateOrder(int complexity)
    {
        List<Ingredient> newOrder = new List<Ingredient>();

        newOrder.Add(bunA);

        for (int i = 0; i < complexity; ++i)
        {
            if (i == complexity / 2)
            {
                newOrder.Add(burger);
            }
            else
            {
                int rand = Random.Range((int)IngredientType.Burger, (int)IngredientType.Salad + 1);
                newOrder.Add(FindIngredient(rand));
            }
        }

        newOrder.Add(bunB);
        
        return newOrder;
    }

    Ingredient FindIngredient(int index)
    {
        if (index == (int)burger.ingredientType)
        {
            return burger;
        }
        else if (index == (int)cheese.ingredientType)
        {
            return cheese;
        }
        else if (index == (int)tomato.ingredientType)
        {
            return tomato;
        }
        else if(index == (int)salad.ingredientType)
        {
            return salad;
        }
        else
        {
            return null;
        }
    }
}
