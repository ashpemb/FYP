using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideController : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "GameController")
            other.GetComponent<SphereCollider>().isTrigger = false;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "GameController")
            other.GetComponent<SphereCollider>().isTrigger = true;
    }
}
