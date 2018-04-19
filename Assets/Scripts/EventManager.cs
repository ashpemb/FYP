using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoSingleton<EventManager>
{ 

    public delegate void PlayerTutorialAction(GameObject sender, PlayerTutorialArgs args);
    public delegate void PlayerBurgerAction(GameObject sender, PlayerBurgerArgs args);

    public static event PlayerTutorialAction E_PlayerTutorial;

    public static event PlayerTutorialAction E_PlayerOpenUI;

    public static event PlayerTutorialAction E_PlayerPickUpBurger;
    public static event PlayerTutorialAction E_PlayerCookBurger;
    public static event PlayerTutorialAction E_PlayerPlaceBun;

    public static event PlayerBurgerAction E_PlayerFinishBurger;

    public static void PlayerOpenUI(GameObject sender, PlayerTutorialArgs args)
    {
        if (E_PlayerOpenUI != null)
        {
            E_PlayerOpenUI(sender, args);
        }
    }
    public static void PlayerPickUpBurger(GameObject sender, PlayerTutorialArgs args)
    {
        if (E_PlayerPickUpBurger != null)
        {
            E_PlayerPickUpBurger(sender, args);
        }
    }

    public static void PlayerCookBurger(GameObject sender, PlayerTutorialArgs args)
    {
        if (E_PlayerCookBurger != null)
        {
            E_PlayerCookBurger(sender, args);
        }
    }

    public static void PlayerPlaceBun(GameObject sender, PlayerTutorialArgs args)
    {
        if (E_PlayerPlaceBun != null)
        {
            E_PlayerPlaceBun(sender, args);
        }
    }

    public static void PlayerFinishBurger(GameObject sender, PlayerBurgerArgs args)
    {
        if (E_PlayerFinishBurger != null)
        {
            E_PlayerFinishBurger(sender, args);
        }
    }

    public static void PlayerTutorial(GameObject sender, PlayerTutorialArgs args)
    {
        if (E_PlayerTutorial != null)
        {
            E_PlayerTutorial(sender, args);
        }
    }

}

public class EventArgs
{
    public static readonly EventArgs Empty;

    public EventArgs() { }
}

public class PlayerBurgerArgs
{
    public float timeTaken;
    public bool burgerCorrect;

    public PlayerBurgerArgs(float timeTaken, bool correct)
    {
        this.timeTaken = timeTaken;
        burgerCorrect = correct;
    }
}

public class PlayerTutorialArgs
{
    public GameObject gameObject;

    public PlayerTutorialArgs()
    {
        gameObject = null;
    }

    public PlayerTutorialArgs(GameObject obj)
    {
        gameObject = obj;
    }
}
