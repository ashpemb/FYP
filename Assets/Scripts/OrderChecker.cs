using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderChecker : MonoBehaviour {

    
    List<Ingredient> createdBurger = new List<Ingredient>();
    float timeTaken = 0;

    bool burgerCorrect = false;
    bool buttonPushed = false;

    private void Start()
    {
        EventManager.E_PlayerFinishBurger += ResetBurger;
    }

    private void Update()
    {
        timeTaken += Time.deltaTime;
    }

    public void NoOrderUp()
    {
        buttonPushed = true;
    }

    private void ResetBurger(GameObject sender, PlayerBurgerArgs args)
    {
        if (args.burgerCorrect == true)
        {
            SoundManager.instance.PlaySingle("Correct");
            GameManager.instance.NewOrder();
        }
        else
        {
            sender.GetComponent<BurgerBuilder>().DeleteChildren();
            SoundManager.instance.PlaySingle("Incorrect");
        }
    }

    public void OrderUp()
    {
        if (buttonPushed != true)
        {
            EventManager.PlayerFinishBurger(this.gameObject, new PlayerBurgerArgs(timeTaken, CheckOrder(this.gameObject, GameManager.instance.currentOrder)));
            //Debug.Log(CheckOrder(this.gameObject, GameManager.instance.currentOrder));
            //GameManager.instance.NewOrder();
            
        }
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
        if (createdBurger.Count != bOrder.OrderList.Count)
        {
            burgerCorrect = false;
            createdBurger.Clear();
            return burgerCorrect;
        }
        for (int j = 0; j < bOrder.OrderList.Count; ++j)
        {
            
            if (bOrder.OrderList[j].ingredientType == createdBurger[j].ingredientType)
            {
                if (createdBurger[j].ingredientType == IngredientType.Burger)
                {
                    if (createdBurger[j].GetComponent<Burger>().cookState == 1)
                    {
                        burgerCorrect = true;
                    }
                    else
                    {
                        burgerCorrect = false;
                        break;
                    }
                }
                else
                {
                    burgerCorrect = true;
                    
                }
            }
            else
            {
                burgerCorrect = false;
                break;
            }
        }

        
        createdBurger.Clear();
        return burgerCorrect;
        
    }

    public void ButtonNotPressed()
    {
        buttonPushed = false;
    }
}
