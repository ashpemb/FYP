using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class VRInteractable : MonoBehaviour {

    Rigidbody rb;

    public Transform holder { get; private set; }

    float RotationSpeed = 50f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void PickUp(Transform parent)
    {
        rb.isKinematic = true;
        holder = parent;
        transform.SetParent(holder);
        //transform.localPosition = Vector3.zero;
    }
	
	public void Drop(Vector3 velocity, Vector3 angularVelocity)
    {
        rb.isKinematic = false;
        rb.velocity = velocity;
        rb.angularVelocity = angularVelocity;
        transform.SetParent(null);
        holder = null;
    }

    public void Interact(Vector2 touchPadPosition)
    {
        transform.Rotate(Camera.main.transform.up * -touchPadPosition.x * RotationSpeed * Time.deltaTime, Space.World);
        transform.Rotate(Camera.main.transform.right * touchPadPosition.y * RotationSpeed * Time.deltaTime, Space.World);
    }
}
