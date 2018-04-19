using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurgerBuilder : MonoBehaviour {

    

	public void DeleteChildren()
    {
        if (transform.childCount > 2)
        {
            for (int i = 2; i < transform.childCount; ++i)
            {
                Destroy(transform.GetChild(i).gameObject);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Interactable")
        {
            if (other.GetComponent<CookBurger>() != null)
            {
                AddIngredient(other.gameObject);
                
                
            }
            else if (other.gameObject.layer == (int)BURGERLAYERS.bunALayer)
            {
                AddIngredient(other.gameObject);
            }
            else if (other.gameObject.layer == (int)BURGERLAYERS.bunBLayer)
            {
                AddIngredient(other.gameObject);
            }
            else if (other.gameObject.layer == (int)BURGERLAYERS.cheeseLayer)
            {
                AddIngredient(other.gameObject);
            }
            else if (other.gameObject.layer == (int)BURGERLAYERS.saladLayer)
            {
                AddIngredient(other.gameObject);
            }
            else if (other.gameObject.layer == (int)BURGERLAYERS.tomatoLayer)
            {
                AddIngredient(other.gameObject);
            }
        }
    }

    void AddIngredient(GameObject child)
    {
        if (child.GetComponent<VRInteractable>().holder != null)
        {
            child.GetComponent<VRInteractable>().GetComponentInParent<VRInput>().RemoveFromList(child.GetComponent<VRInteractable>());
            child.GetComponent<VRInteractable>().Drop(new Vector3(0, 0, 0), new Vector3(0, 0, 0));
        }

        child.transform.SetParent(this.transform);
        child.tag = "Ingredient";
        Destroy(child.GetComponent<VRInteractable>());
        Destroy(child.GetComponent<Rigidbody>());
        child.transform.localRotation = Quaternion.identity;

        int siblingIndex = child.transform.GetSiblingIndex();
        GameObject prevChild = this.transform.GetChild(siblingIndex - 1).gameObject;
        Vector3 prevChildPos = prevChild.transform.localPosition;

        Collider prevChildCollider = prevChild.GetComponent<Collider>();
        Collider childCollider = child.GetComponent<Collider>();
        float yPush =  ((prevChildCollider.bounds.extents.y) + (childCollider.bounds.extents.y));

        child.transform.localPosition = new Vector3(prevChildPos.x, prevChildPos.y + yPush, prevChildPos.z);

        EventManager.PlayerPlaceBun(this.gameObject, new PlayerTutorialArgs(child));

    }
}
