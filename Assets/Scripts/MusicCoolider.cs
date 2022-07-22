using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MusicCoolider : MonoBehaviour
{
    public AudioSource Music;
    private void OnTriggerEnter(Collider other)
    {
            if (other.gameObject.CompareTag("Player"))
            {
            Music.Play();
            }
        

    }
}
