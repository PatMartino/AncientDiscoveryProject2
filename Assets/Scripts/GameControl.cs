using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{
    float health=100;
    public Image healthBar;
    public GameObject flashlightText;
    public GameObject myPlayer;
    bool oll = false;
    void Start()
    {
        StartCoroutine(flaslight());
    }

    // Update is called once per frame
    void Update()
    {
        if (oll)
        {
            myPlayer.transform.gameObject.GetComponent<Level2_Characther>().gameOver2();
        }
        
    }
    public void hitTaken()
    {
        health -= 10;
        healthBar.fillAmount = health / 100; ;
        if (health <= 10)
        {
            Debug.Log("ollll");
            oll = true;

        }
    }
    IEnumerator flaslight()
    {
        flashlightText.SetActive(true);
        yield return new WaitForSeconds(4);
        flashlightText.SetActive(false);

    }
}
