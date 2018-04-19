using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    VRInput currentController;
    public OrderDisplay display;

    public void OpenUI(VRInput controller)
    {
        if(currentController == null)
        {
            gameObject.SetActive(true);
            
        }
        else
        {
            VRInput temp = currentController;
            currentController = controller;
            temp.CloseUI();
        }

        currentController = controller;
        transform.SetParent(controller.transform);
        transform.localPosition = Vector3.zero;
        transform.localRotation = new Quaternion(0.5f,0,0,1);
        
    }

    public void CloseUI(VRInput controller)
    {
        if(controller == currentController)
        {
            currentController = null;
            gameObject.SetActive(false);
        }
    }

}
