using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookBurger : MonoBehaviour {

    public float cookTime = 10.0f;
    public float burnTime = 15.0f;
    public float cookingTimer = 0.0f;
    public bool isCooking = false;
    public Material raw;
    public Material cooked;
    public Material burnt;

    MeshRenderer mr;
    Burger ingredient;

    private void Start()
    {
        mr = this.GetComponent<MeshRenderer>();
        ingredient = GetComponent<Burger>();
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "GrillPlate")
        {
            isCooking = true;
            //SoundManager.instance.PlayLoopingDistance(this.gameObject, "Sizzle", 0.0f, 20.0f);
            SoundManager.instance.PlayLoopingDistance(this.gameObject,"Sizzle");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "GrillPlate")
        {
            isCooking = false;
            SoundManager.instance.StopPlay(this.gameObject);
        }
    }

    void Update()
    {
        if (isCooking)
        {
            cookingTimer += Time.deltaTime;
        }
        ChangeCookState();
    }

    void ChangeCookState()
    {
        if (cookingTimer >= cookTime && cookingTimer < burnTime)
        {
            ingredient.cookState = 1;
            mr.material = cooked;
            EventManager.PlayerCookBurger(this.gameObject, new PlayerTutorialArgs());
        }
        else if (cookingTimer >= burnTime)
        {
            ingredient.cookState = 2;
            mr.material = burnt;
        }
    }
}
