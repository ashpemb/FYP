using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredient : MonoBehaviour {

    MeshRenderer mr;
    public Material floorMaterial;
    float destroyTimer = 10f;
    float timer = 0;
    bool destroyThis;
    public IngredientType ingredientType;

    public Ingredient()
    {

    }

    private void Awake()
    {
        mr = this.GetComponent<MeshRenderer>();
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawCube(this.GetComponent<Collider>().bounds.center, this.GetComponent<Collider>().bounds.size);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Floor" && !destroyThis)
        {
            mr.material = floorMaterial;

            if (this.GetComponent<VRInteractable>().holder != null)
            {
                this.GetComponent<VRInteractable>().GetComponentInParent<VRInput>().RemoveFromList(this.GetComponent<VRInteractable>());
                this.GetComponent<VRInteractable>().Drop(new Vector3(0, 0, 0), new Vector3(0, 0, 0));
            }

            Destroy(this.GetComponent<VRInteractable>());
            destroyThis = true;
        }
    }

    void Update()
    {
        if(destroyThis == true)
        {
            if (timer >= destroyTimer)
            {
                Destroy(this.gameObject);
            }
            timer += Time.deltaTime;
        }
    }
}
