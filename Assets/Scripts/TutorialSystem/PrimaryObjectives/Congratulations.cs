using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Congratulations : PrimaryObjective {

    public override void Activated()
    {
        StatsManager.instance.isInTutorial = false;
        base.Activated();
    }
}
