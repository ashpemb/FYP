using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateButton : MonoBehaviour {

	public void Deactivate(GameObject obj)
    {
        obj.SetActive(false);
    }
}
