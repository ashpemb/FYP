using UnityEngine;
using System.Collections;

public class SubObjective : Objective
{

    PrimaryObjective primaryObjective;

    public void Start()
    {
        primaryObjective = GetComponentInParent<PrimaryObjective>();
    }

    public override void Complete()
    {
        primaryObjective.NextSubObjective();
        base.Complete();
    }




}
