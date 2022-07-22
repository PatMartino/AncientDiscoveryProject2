using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MyCharacter : MonoBehaviour
{
    //public GameObject ak47;
    //public AudioSource takeWeapon;
    public float range;
    public float range2;
    public Camera cam;
    public GameObject Note1;
    public GameObject Read;
    public GameObject Enter;
    public AudioSource journalSound;
    public GameObject journal2;
    public GameObject journal2Text;

    bool note1setactive=false;
    bool readsetactive = true;
    bool entersetactive = true;
    bool journalSetActive = false;
    bool journalOnetime=true;
    public GameObject PyramidDiscoveredText;
    bool pyramidbool=true;
    public AudioSource darkSouls;
    
    
    

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        
            Journal3();
        
            journal();
        enter();
        

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("1")&&pyramidbool)
        {
            StartCoroutine(Pyramid());


        }
    }
    IEnumerator Pyramid()
    {
        darkSouls.Play();
        PyramidDiscoveredText.SetActive(true);
        yield return new WaitForSeconds(5);
        PyramidDiscoveredText.SetActive(false);
        pyramidbool = false;
    }


    void journal()
    {
        RaycastHit hit;
        if (Input.GetKeyDown(KeyCode.E) && Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range) && hit.transform.gameObject.CompareTag("Journal"))
        {
            journalSound.Play();
            Note1.SetActive(true);
            note1setactive = true;
            Read.SetActive(false);
            readsetactive = false;
            Debug.Log("Bum");

        }
        else if (note1setactive && Input.GetKeyDown(KeyCode.E))
        {
            
            Note1.SetActive(false);
            note1setactive = false;
        }

        else if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range) && hit.transform.gameObject.CompareTag("Journal") && !note1setactive)
        {

            Read.SetActive(true);
            readsetactive = true;


        }
        else if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range) && !hit.transform.gameObject.CompareTag("Journal") && readsetactive)
        {
            Read.SetActive(false);
            readsetactive = false;
        }
    }
    void Journal3()
    {
        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range) && hit.transform.gameObject.CompareTag("Journal2"))
        {
            Read.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                journalSound.Play();
                journal2.SetActive(true);
                Read.SetActive(false);
                journalSetActive = true;
            }

        }
        else if (Input.GetKeyDown(KeyCode.E) && journalSetActive)
        {
            journal2.SetActive(false);
            if (journalOnetime)
            {
                StartCoroutine(journalText());
            }
            
        }
        else
        {
            Read.SetActive(false);
        }
    }
    IEnumerator journalText()
    {
        journal2Text.SetActive(true);
        yield return new WaitForSeconds(3);
        journal2Text.SetActive(false);
        journalOnetime = false;
    }
    void enter()
    {
        RaycastHit hit;
        if (Input.GetKeyDown(KeyCode.E) && Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range2) && hit.transform.gameObject.CompareTag("Pyramid"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            Enter.SetActive(false);
            entersetactive = false;
        }
        else if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range2) && hit.transform.gameObject.CompareTag("Pyramid") && !readsetactive)
        {

            Enter.SetActive(true);
            entersetactive = true;
        }
        else if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range2) && !hit.transform.gameObject.CompareTag("Pyramid") && readsetactive)
        {
            Enter.SetActive(false);
            entersetactive = false;
        }
    }
}
