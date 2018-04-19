using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class VRInput : MonoBehaviour {

    private EVRButtonId triggerButton = EVRButtonId.k_EButton_SteamVR_Trigger;

    private SteamVR_Controller.Device controller { get { return SteamVR_Controller.Input((int)trackedObj.index); } }
    private SteamVR_TrackedObject trackedObj;

    PlayerController playerController;
    LineRenderer line;
    public GameObject teleportMarker;
    float teleportDistance = 20;

    List<VRInteractable> VRInteractables;
    VRInteractable pickedUpObject;
    bool inSpawner;
    SpawnObject spawner;

    public UIManager UIManager;
    bool UIOpen;
    float UIInputTimer;
    const float UIInputTime = 0.4f;
    const float UIInputDeadZone = 0.3f;

    // Use this for initialization
    void Start () {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
        playerController = transform.root.GetComponent<PlayerController>();
        line = GetComponent<LineRenderer>();
        VRInteractables = new List<VRInteractable>();
        UIManager.gameObject.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        
        if (controller == null)
        {
            Debug.Log("Controller not initialized");
            return;
        }

        var device = SteamVR_Controller.Input((int)trackedObj.index);

        //triggers
        if (controller.GetPressDown(triggerButton))
        {
            if (inSpawner)
            {
                
                VRInteractables.Add((spawner.Spawn(transform.position)).gameObject.GetComponent<VRInteractable>());
            }

            VRInteractable closestObj = FindClosestObject();

            if (closestObj != null)
            {
                pickedUpObject = closestObj;
                pickedUpObject.PickUp(transform);
                EventManager.PlayerPickUpBurger(this.gameObject, new PlayerTutorialArgs());
            }
        }

        if (controller.GetPressUp(triggerButton))
        {
            //DropObj();
            if(pickedUpObject != null)
            {
                VRInteractables.Remove(pickedUpObject);
                pickedUpObject.Drop(controller.velocity, controller.angularVelocity);
                pickedUpObject = null;
            }
        }

        //touchpad
        if (controller.GetPressDown(EVRButtonId.k_EButton_SteamVR_Touchpad))
        {
            Debug.Log("Touch down");
            
                
        }

        if (controller.GetPressUp(EVRButtonId.k_EButton_SteamVR_Touchpad))
            Debug.Log("Touch up");

        Vector2 touchPad = controller.GetAxis(EVRButtonId.k_EButton_SteamVR_Touchpad);
        if (touchPad != Vector2.zero)
        {
            //Debug.Log(touchPad);

            if (pickedUpObject != null)
            {
                pickedUpObject.Interact(touchPad);
            }
            else
            {
                Teleport();
            }
        }
        else
        {
            if (teleportMarker.activeSelf)
                teleportMarker.SetActive(false);

            if (line.enabled == true)
                line.enabled = false;
        }

        //grip
        if (controller.GetPressDown(EVRButtonId.k_EButton_Grip))
        {
            Debug.Log("Grip down");
            if (!UIOpen)
            {
                OpenUI();
                UIManager.display.UpdateText();
                EventManager.PlayerOpenUI(this.gameObject, new PlayerTutorialArgs());
            }
            else
            {
                CloseUI();
            }
        }

        if (controller.GetPressUp(EVRButtonId.k_EButton_Grip))
            Debug.Log("Grip up");

        //menu
        if (controller.GetPressDown(EVRButtonId.k_EButton_ApplicationMenu))
            Debug.Log("Menu down");

        if (controller.GetPressUp(EVRButtonId.k_EButton_ApplicationMenu))
            Debug.Log("Menu up");
    }

    void FixedUpdate()
    {
        
    }

    public void OpenUI()
    {
        if(pickedUpObject == null)
        {
            UIManager.OpenUI(this);
            UIOpen = true;
            
        }
    }

    public void CloseUI()
    {
        UIManager.CloseUI(this);
        UIOpen = false;
    }

    public void RemoveFromList(VRInteractable obj)
    {
        VRInteractables.Remove(obj);
    }

    void Teleport()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, teleportDistance, LayerMask.GetMask("TeleportLocation")))
        {
            if (!teleportMarker.activeSelf)
                teleportMarker.SetActive(true);
            if (line.enabled == false)
                line.enabled = true;
            line.SetPosition(0, transform.position);
            line.SetPosition(1, hit.point);

            teleportMarker.transform.position = hit.point;
            if(controller.GetPressDown(EVRButtonId.k_EButton_SteamVR_Touchpad))
            {
                SteamVR_Render.Top().origin.position = new Vector3(hit.point.x, hit.point.y/* + playerController.PlayerHeight*/, hit.point.z);
            }
        }
        else
        {
            if (teleportMarker.activeSelf)
                teleportMarker.SetActive(false);

            if (line.enabled == true)
                line.enabled = false;
        }
    }

    VRInteractable FindClosestObject()
    {
        float distance = float.MaxValue;
        int closestObjectIndex = -1;
        for (int i = 0; i < VRInteractables.Count; ++i)
        {
            if (VRInteractables[i] != null)
            {
                if (VRInteractables[i].holder == null)
                {
                    float tempDistance = Vector3.Distance(transform.position, VRInteractables[i].transform.position);

                    if (tempDistance < distance)
                    {
                        distance = tempDistance;
                        closestObjectIndex = i;
                    }
                }
                else
                {
                    continue;
                }
            }

        }

        if (closestObjectIndex >= 0)
            return VRInteractables[closestObjectIndex];

        return null;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Interactable")
        {
            VRInteractables.Add(other.gameObject.GetComponent<VRInteractable>());
            //SteamVR_Controller.Input((int)trackedObj.index).TriggerHapticPulse(500);
        }
        else if (other.tag == "Spawner")
        {
            inSpawner = true;
            spawner = other.gameObject.GetComponent<SpawnObject>();
        }
    }

    void OnTriggerStay(Collider other)
    {
        
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Interactable")
        {
            VRInteractables.Remove(other.GetComponent<VRInteractable>());
        }
        else if (other.tag == "Spawner")
        {
            inSpawner = false;
            spawner = null;
        }
    }

    public GameObject GetPickUp()
    {
        if(pickedUpObject != null)
        {
            return pickedUpObject.gameObject;
        }
        else
        {
            return null;
        }
    }
}
