using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSpwaner : MonoBehaviour
{
    public GameObject prefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnWeapon()
    {
        Instantiate(prefab);
    }
}
