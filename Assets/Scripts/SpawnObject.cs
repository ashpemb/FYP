using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour {

    public GameObject spawnObject;

	public GameObject Spawn(Vector3 pos)
    {
        return Instantiate(spawnObject, pos, Quaternion.identity);
    }

    
}
