using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartTutorial : PrimaryObjective {

    public override void Complete()
    {
        StatsManager.instance.isInTutorial = true;
        GameManager.instance.TestOrder();
        base.Complete();
    }
}
