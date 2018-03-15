using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    VRInput currentController;
    public Button StartingButton;
    Button currentButton;

    void RefreshUI()
    {
        currentButton = StartingButton;
        currentButton.Select();
        currentButton.OnSelect(null);
    }

    public void OpenUI(VRInput controller)
    {
        if(currentController == null)
        {
            gameObject.SetActive(true);
            RefreshUI();
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

    public void Input(Vector3 dir)
    {
        Selectable selectable = currentButton.FindSelectable(dir);
        if(selectable != null)
        {
            selectable.Select();
            selectable.OnSelect(null);
            currentButton = selectable as Button;
        }
    }

    public void Interact()
    {
        currentButton.onClick.Invoke();
    }
}
