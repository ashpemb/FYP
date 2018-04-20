using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartTutorial : PrimaryObjective {

    public override void Complete()
    {
        GameManager.instance.TestOrder();
        base.Complete();
    }
}
