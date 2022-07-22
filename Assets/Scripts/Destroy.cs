using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    public static bool isDoor1Destroyed = false;
    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.SetActive(false);
        Debug.Log("BUMAT");
        
    }
}
