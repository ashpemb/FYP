using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager> {

    public BurgerOrder currentOrder;
    public BurgerBuilder builder;
    [SerializeField]
    public OrderDisplay OrderUI;

	// Use this for initialization
	void Start () {
        
        currentOrder.OrderList = new List<Ingredient>();
        currentOrder.OrderList.Add(new BunA());
        currentOrder.OrderList.Add(new Burger());
        currentOrder.OrderList.Add(new BunB());
    }
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.N))
        {
            NewOrder();
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            TestOrder();
        }
	}

    public void NewOrder()
    {
        currentOrder.OrderList = OrderGenerator.instance.GenerateOrder(Random.Range(1, 5));
        builder.DeleteChildren();
        OrderUI.UpdateText();
    }

    public void TestOrder()
    {
        currentOrder.OrderList.Clear();
        currentOrder.OrderList.Add(new BunA());
        currentOrder.OrderList.Add(new Burger());
        currentOrder.OrderList.Add(new BunB());
        builder.DeleteChildren();
        OrderUI.UpdateText();
    }
}
