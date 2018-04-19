using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrderDisplay : MonoBehaviour {

    public Text text;
    string orderText;

    private void Start()
    {
        text = GetComponent<Text>();
        //UpdateText();
    }

    public string OrderFormat(BurgerOrder order)
    {
        orderText = "";
        for (int i = 0; i < order.OrderList.Count; ++i)
        {
            if (order.OrderList[i].ingredientType == IngredientType.TopBun)
            {
                orderText += "Top Bun\n";
            }
            else if (order.OrderList[i].ingredientType == IngredientType.BottomBun)
            {
                orderText += "Botttom Bun\n";
            }
            else
            {
                orderText += order.OrderList[i].ingredientType.ToString() + " \n";
            }
        }


        return orderText;
    }

    public void UpdateText()
    {
        text.text = OrderFormat(GameManager.instance.currentOrder);
    }
}
