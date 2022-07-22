using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Dusman : MonoBehaviour
{
    NavMeshAgent ajan;
    public GameObject Hedef;
    public float health;
    public float darbeGucu;
    Animator myAnimator;
    public static bool isAlive = true;
    bool isAttack = false;
    
    void Start()
    {
        myAnimator = GetComponent<Animator>();
        ajan = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isAlive&& !isAttack)
        {
            ajan.SetDestination(Hedef.transform.position);
        }
       
    }
    public void darbeAl()
    {
        
            health -= darbeGucu;
            if (health <= 0)
            {
                oldun();
            }
        
        
        void oldun()
        {
            myAnimator.Play("Death");
            isAlive = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (isAlive)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                StartCoroutine(attack());
            }
        }
        
    }
    IEnumerator attack()
    {
        isAttack = true;
        GameObject myController = GameObject.FindWithTag("myControl");
        myAnimator.Play("attack");
        myController.GetComponent<GameControl>().hitTaken();
        yield return new WaitForSeconds(2f);
        isAttack = false;
    }
    public bool getalive()
    {
        return isAlive;
    }
}
