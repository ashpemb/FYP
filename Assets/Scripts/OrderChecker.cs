using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderChecker : MonoBehaviour {

    
    List<Ingredient> createdBurger = new List<Ingredient>();
    public BunA bunA;
    public Burger burger;
    public BunB bunB;

    bool burgerCorrect = false;

    public void OrderUp()
    {
        BurgerOrder bOrder = new BurgerOrder();
        bOrder.OrderList = new List<Ingredient>();
        bOrder.OrderList.Add(bunA);
        bOrder.OrderList.Add(burger);
        bOrder.OrderList.Add(bunB);
        Debug.Log(CheckOrder(this.gameObject, bOrder));
    }

    public bool CheckOrder(GameObject Meal, BurgerOrder bOrder)
    {

        
        if (Meal.transform.childCount > 2)
        {
            for (int i = 2; i < Meal.transform.childCount; ++i)
            {
                createdBurger.Add(Meal.transform.GetChild(i).GetComponent<Ingredient>());
            }
        }

        for (int j = 0; j < bOrder.OrderList.Count; ++j)
        {
            if (bOrder.OrderList[j].ingredientType == createdBurger[j].ingredientType )
            {
                burgerCorrect = true;
            }
            else
            {
                burgerCorrect = false;
                break;
            }
        }

        
        return burgerCorrect;
        
    }
}
