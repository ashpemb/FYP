using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObject : MonoBehaviour {

    private Valve.VR.EVRButtonId triggerButton = Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger;

    private SteamVR_Controller.Device controller { get { return SteamVR_Controller.Input((int)trackedObj.index); } }
    private SteamVR_TrackedObject trackedObj;

    [SerializeField]
    private GameObject obj;
    private FixedJoint fJoint;

    private bool thrown;
    private Rigidbody pickupRigidbody;

    // Use this for initialization
    void Start () {
        trackedObj = GetComponent<SteamVR_TrackedObject>();

        fJoint = GetComponent<FixedJoint>();
    }
	
	// Update is called once per frame
	void Update () {
        if (controller == null)
        {
            Debug.Log("Controller not initialized");
            return;
        }

        var device = SteamVR_Controller.Input((int)trackedObj.index);

        if (controller.GetPressDown(triggerButton))
        {
            PickUpObj();
        }

        if (controller.GetPressUp(triggerButton))
        {
            DropObj();
        }
    }

    void FixedUpdate()
    {
        if (thrown)
        {
            Transform origin;
            if (trackedObj.origin != null)
            {
                origin = trackedObj.origin;
            }
            else
            {
                origin = trackedObj.transform.parent;
            }

            if (origin != null)
            {
                pickupRigidbody.velocity = origin.TransformVector(controller.velocity);
                pickupRigidbody.angularVelocity = origin.TransformVector(controller.angularVelocity * 0.5f);
            }
            else
            {
                pickupRigidbody.velocity = controller.velocity;
                pickupRigidbody.angularVelocity = controller.angularVelocity * 0.5f;
            }

            pickupRigidbody.maxAngularVelocity = pickupRigidbody.angularVelocity.magnitude;

            thrown = false;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Pickupable"))
        {
            obj = other.gameObject;
        }
    }

    void OnTriggerExit(Collider other)
    {
        obj = null;
    }

    void PickUpObj()
    {
        if (obj != null)
        {
            fJoint.connectedBody = obj.GetComponent<Rigidbody>();
            thrown = false;
            pickupRigidbody = null;
        }
        else
        {
            fJoint.connectedBody = null;
        }
    }

    void DropObj()
    {
        if (fJoint.connectedBody != null)
        {
            pickupRigidbody = fJoint.connectedBody;
            fJoint.connectedBody = null;
            thrown = true;
        }

        
    }
}
