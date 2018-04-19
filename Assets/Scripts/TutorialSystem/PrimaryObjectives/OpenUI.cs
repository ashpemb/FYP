using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenUI : PrimaryObjective {

    public override void Activated()
    {
        base.Activated();
        EventManager.E_PlayerOpenUI += UIOpened;
    }

    void UIOpened(GameObject sender, PlayerTutorialArgs args)
    {
        Complete();
    }

    public override void Complete()
    {
        EventManager.E_PlayerOpenUI -= UIOpened;
        base.Complete();
    }
}
