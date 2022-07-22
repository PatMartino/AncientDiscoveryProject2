using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Level2_Characther : MonoBehaviour
{
    public float range;
    public Camera cam;
    public GameObject Wall1;
    public GameObject Read;
    public GameObject Read1;
    bool wallsetactive = false;
    bool readsetactive = true;
    public GameObject flashLight;
    public GameObject cat1;
    public GameObject cat2;
    public GameObject cat3;
    public GameObject cat4;
    bool flaslightBool = false;
    public Animator colon1;
    public Animation colon2;
    bool havecat1 = false;
    bool havecat2 = false;
    bool drapCat1 = false;
    bool drapCat2 = false;
    public GameObject door1;
    public Rigidbody doorRigidbody;
    public Rigidbody door2Rigidbody;
    public GameObject door1Collider;
    public GameObject door2Collider;
    public int Jumping_Speed;
    public GameObject takeText;
    bool istaketext = false;
    public GameObject dropText;
    public GameObject TextWall2;
    bool wall2active = false;
    public GameObject TextWall3;
    public GameObject kus;
    public GameObject ayak;
    public GameObject baston;
    public GameObject OpenWallText;
    bool wall3active = false;
    public Texture2D cursorArrow;
    bool press1=false;
    bool press2 = false;
    bool press3 = false;
    public GameObject pushText;
    public GameObject Engel1;
    public GameObject Engel2;
    public GameObject locked;
    public GameObject locked1;
    public GameObject locked2;
    bool isdropCat1=false;
    bool isdropCat2=false;
    public GameObject journal;
    bool journalsetactive=false;
    public GameObject KeyDoor;
    bool isKeyTaken = false;
    public GameObject openText;
    public Rigidbody Door4Rigidbody;
    public GameObject door4Collider;
    public GameObject magnumPistol;
    public GameObject enemy;
    public GameObject magnum;
    public GameObject magnumCanvas;
    public GameObject health;
    public GameObject death;
    public GameObject Enemy;
    public GameObject zombieSound;
    public AudioSource doorSound;
    public AudioSource JournalSound;
    bool door1Sound = true;
    bool door2Sound = true;
    bool door3Sound = true;
    public AudioSource dropItemSound;
    public AudioSource takeItemSound;
    public Rigidbody Door5Rigidbody;
    public GameObject door5Collider;
    bool door5Sound = true;
    public GameObject DiamondObject;
    bool haveDiamond=false;
    public GameObject endPanel;
    public GameObject exitPanel;
    public GameObject exitText;
    bool d1 = true;
    bool d2 = true;
    bool d3 = true;

    void Update()
    {
        
        RaycastHit hit;
        
        if (!Enemy.transform.gameObject.GetComponent<Dusman>().getalive())
        {
            zombieSound.SetActive(false);
            
        }
        if (!Enemy.transform.gameObject.GetComponent<Dusman>().getalive()&&door5Sound)
        {
            
            opendoor5();
        }
        if (haveDiamond)
        {
            EndGame();
        }
        if (Input.GetKeyDown(KeyCode.F)&&!flaslightBool)
        {
            flaslight();
            
        }
        else if (Input.GetKeyDown(KeyCode.F) && flaslightBool)
        {
            flaslight2();
        }
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range) && !hit.transform.gameObject.CompareTag("cat2"))
        {
            cat1Take();
        }
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range) && !hit.transform.gameObject.CompareTag("cat1"))
        {
            cat2Take();
        }

            
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range) && !hit.transform.gameObject.CompareTag("kedi2") && havecat1)
        {
            dropCat1();
        }
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range) && !hit.transform.gameObject.CompareTag("kedi1") && havecat2)
        {
            dropCat2();
        }
        Wall2();

        
        opendoor2();

        press();
        openDoor1();
        
        
            Door1();
        
        
            Door2();
        
           
        Journal();
        exit();
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range) && hit.transform.gameObject.CompareTag("Key"))
        {
            Key();
        }
        
            Door4();
        
            
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range) && hit.transform.gameObject.CompareTag("Diamond"))
        {
            diamond();
        }
        
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range) && hit.transform.gameObject.CompareTag("Magnum"))
        {
           takeMagnum();
        }
        
    }
    void exit()
    {
        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range) && hit.transform.gameObject.CompareTag("Exit"))
        {
            exitText.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                StartCoroutine(exitPanelFunction());
                exitText.SetActive(false);
            }
        }
        else
        {
            exitText.SetActive(false);
        }
    }
    IEnumerator exitPanelFunction()
    {
        exitPanel.SetActive(true);
        yield return new WaitForSeconds(3);
        exitPanel.SetActive(false);
    }
    public void gameOver2()
    {
        StartCoroutine(gameOver());
    }
    public IEnumerator gameOver()
    {
        death.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
    void EndGame()
    {
        endPanel.SetActive(true);
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
            Debug.Log("Finito");
        }
    }
    void takeMagnum()
    {
        RaycastHit hit;
        if(Physics.Raycast(cam.transform.position,cam.transform.forward,out hit,range) && hit.transform.gameObject.CompareTag("Magnum"))
        {
            takeText.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                magnumCanvas.SetActive(true);
                health.SetActive(true);
                magnum.SetActive(true);
                Destroy(magnumPistol);
                takeText.SetActive(false);
            }
        }
        else
        {
            takeText.SetActive(false);
        }
        
    }
    IEnumerator enemyactive()
    {
        yield return new WaitForSeconds(5f);
        enemy.SetActive(true);
    }
    void Door4()
    {
        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range) && hit.transform.gameObject.CompareTag("Door4")&& !isKeyTaken&&d3)
        {
            locked2.SetActive(true);
        }
        else if(Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range) && hit.transform.gameObject.CompareTag("Door4") && isKeyTaken)
        {
            openText.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E)&&door3Sound)
            {
                doorSound.Play();
                door3Sound = false;
                d3 = false;
                openText.SetActive(false);
                door4Collider.SetActive(false);
                Door4Rigidbody.velocity = Vector2.down * Jumping_Speed;
                StartCoroutine(enemyactive());
            }
        }
        else
        {
            locked2.SetActive(false);
            openText.SetActive(false);
        }

    }
    void diamond()
    {
        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range) && hit.transform.gameObject.CompareTag("Diamond"))
        {
            takeText.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                takeItemSound.Play();
                DiamondObject.SetActive(false);
                haveDiamond = true;
                takeText.SetActive(false);
            }
        }
        else
        {
            takeText.SetActive(false);
        }
    }
    void Key()
    {
        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range) && hit.transform.gameObject.CompareTag("Key"))
        {
            takeText.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                KeyDoor.SetActive(false);
                isKeyTaken = true;
                
            }
        }
        else
        {
            takeText.SetActive(false);
        }
    }
    void Journal()
    {
        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range) && hit.transform.gameObject.CompareTag("Journal"))
        {
            Read.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                JournalSound.Play();
                journal.SetActive(true);
                Read.SetActive(false);
                journalsetactive = true;
            }

        }
        else if (Input.GetKeyDown(KeyCode.E) && journalsetactive)
        {
            journal.SetActive(false);
        }
        else
        {
            Read.SetActive(false);
        }
    }
    void Door1()
    {
        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range) && hit.transform.gameObject.CompareTag("Door1")&&d1)
        {
            locked.SetActive(true);
           
        }
        else
        {
            locked.SetActive(false);
           
        }
        
    }
    void Door2()
    {
        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range) && hit.transform.gameObject.CompareTag("Door2")&&d2)
        {
            locked1.SetActive(true);
            
            
        }
        else
        {
            locked1.SetActive(false);
        }
    }

    void openDoor1()
    {
        if (drapCat1 && drapCat2&&door1Sound)
        {
            doorSound.Play();
            door1Sound = false;
            door2Collider.SetActive(false);
            doorRigidbody.velocity = Vector2.down * Jumping_Speed ;
            locked1.SetActive(false);
            d2 = false;

        }
    }
    void opendoor2()
    {
        if (press1 && press2 && press3&&door2Sound)
        {
            doorSound.Play();
            door2Sound = false;
            door1Collider.SetActive(false);
            door2Rigidbody.velocity = Vector2.down * Jumping_Speed;
            locked.SetActive(false);
            d1 = false;
        }
    }
    void opendoor5()
    {
        doorSound.Play();
        door2Sound = false;
        door5Collider.SetActive(false);
        Door5Rigidbody.velocity = Vector2.down * Jumping_Speed;
        
    }
    void dropCat1()
    {
        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range) && hit.transform.gameObject.CompareTag("kedi1")&&havecat1&&!isdropCat1)
        {
            dropText.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                dropItemSound.Play();
                cat1.SetActive(true);
                drapCat1 = true;
                dropText.SetActive(false);
                isdropCat1 = true;
            } 
        }
        else {
            dropText.SetActive(false);
        }
    }
    void dropCat2()
    {
        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range) && hit.transform.gameObject.CompareTag("kedi2") && havecat2&&!isdropCat2)
        {
            dropText.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                dropItemSound.Play();
                cat2.SetActive(true);
                drapCat2 = true;
                dropText.SetActive(false);
                isdropCat2 = true;
            }
            
        }
        else
        {
            dropText.SetActive(false);
        }
    }
    void cat1Take()
    {
        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range) && hit.transform.gameObject.CompareTag("cat1"))
        {

            takeText.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                takeItemSound.Play();
                cat3.SetActive(false);
                havecat1 = true;
                Debug.Log("Bum");
                takeText.SetActive(false);
            }
        }
        /*if (Input.GetKeyDown(KeyCode.E) && Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range) && hit.transform.gameObject.CompareTag("cat1"))
        {

            cat3.SetActive(false);
            havecat1=true;
            Debug.Log("Bum");
            takeText.SetActive(false);
        }*/
        else
        {
            takeText.SetActive(false);
        }
    }
    void cat2Take()
    {
        RaycastHit hit;
        if (  Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range) && hit.transform.gameObject.CompareTag("cat2"))
        {
            takeText.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                takeItemSound.Play();
                cat4.SetActive(false);
                havecat2 = true;
                Debug.Log("Bum");
                takeText.SetActive(false);
            }
        }
        else
        {
            takeText.SetActive(false);
        }
    }
    void flaslight()
    {
        flashLight.SetActive(true);
        flaslightBool = true;
    }
    void flaslight2()
    {
        flashLight.SetActive(false);
        flaslightBool = false;
    }
    
    void wall()
    {
        RaycastHit hit;
        if (Input.GetKeyDown(KeyCode.E) && Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range) && hit.transform.gameObject.CompareTag("Wall1"))
        {

            Wall1.SetActive(true);
            wallsetactive = true;
            Read.SetActive(false);
            readsetactive = false;
            Debug.Log("Bum");

        }
        else if (wallsetactive && Input.GetKeyDown(KeyCode.E))
        {
            Wall1.SetActive(false);
            wallsetactive = false;
        }

        else if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range) && hit.transform.gameObject.CompareTag("Wall1") && !wallsetactive)
        {

            Read.SetActive(true);
            readsetactive = true;


        }
        else if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range) && !hit.transform.gameObject.CompareTag("Wall1") && readsetactive)
        {
            Read.SetActive(false);
            readsetactive = false;
        }
       
    }
    void Wall2()
    {
        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range) && hit.transform.gameObject.CompareTag("Wall2"))
        {
            Read1.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                TextWall2.SetActive(true);
                Read1.SetActive(false);
                wall2active = true;
            }

        }
        else if (Input.GetKeyDown(KeyCode.E) && wall2active)
        {
            TextWall2.SetActive(false);
        }
        else
        {
            Read1.SetActive(false);
        }
    }
    /*void Wall3()
    {
        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range) && hit.transform.gameObject.CompareTag("Wall3")&& !wall3active)
        {
            OpenWallText.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                TextWall3.SetActive(true);
                OpenWallText.SetActive(false);
                wall3active = true;
                if (Input.GetKeyDown(KeyCode.T))
                {
                    kus.SetActive(true);
                    Debug.Log("kus");
                }
                
                
            }

        }
        else if (Input.GetKeyDown(KeyCode.E) && wall3active)
        {
            TextWall3.SetActive(false);
            wall3active = false;

        }
        else
        {
            OpenWallText.SetActive(false);
        }
    }*/
    void press()
    {
        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range) && (hit.transform.gameObject.CompareTag("press") || hit.transform.gameObject.CompareTag("1")|| hit.transform.gameObject.CompareTag("2") || hit.transform.gameObject.CompareTag("3")))
        {
            pushText.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                
                pushText.SetActive(false);
                takeItemSound.Play();
                if (hit.transform.gameObject.CompareTag("1"))
                {
                    press1 = true;
                }
                else if (hit.transform.gameObject.CompareTag("2")&& press1)
                {
                    press2 = true;
                }
                else if (hit.transform.gameObject.CompareTag("3") && press2)
                {
                    press3 = true;
                }
                else
                {
                    press1 = false;
                    press2 = false;
                    press3 = false;
                }

            }

        }
        else
        {
            pushText.SetActive(false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Trap"))
        {
            StartCoroutine(gameOver());

        }
        if (other.gameObject.CompareTag("x"))
        {

            Engel1.SetActive(false);
            Engel2.SetActive(false);
            
            zombieSound.SetActive(true);
            

        }
    }
}
