using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Stats  {
    public int run;
    public List<int> fps = new List<int>();
    public float tutorialTime;
    public List<float> burgerTimes = new List<float>();
    public int burgersCreated;
    public int incorrectOrders;
}
