using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Magnum : MonoBehaviour
{
    Animator myAnimator;
    [Header("Ayarlar")]
    public bool atesEdebilirMi;
    float iceridenAtesEtmeSikligi;
    public float disaridanAtesEtmesiklik;
    public float menzil;
    [Header("Silah Ayarlarý")]
    int toplamMermiSayisi=36;
    public int sarjorKapasitesi;
    public int kalanMermi;
    public TextMeshProUGUI toplamMermi_Text;
    public TextMeshProUGUI kalanMermi_Text;
    [Header("Sesler")]
    public AudioSource magnumAtes;

    public ParticleSystem atesEfeceti;
    public Camera cam;
    int aradakiFark;
    void Start()
    {
        myAnimator = GetComponent<Animator>();
        sarjorDoldurmaTeknikFonlsiyon("NormalYaz");
    }

    // Update is called once per frame
    void Update()
    {
        ateset();
        if (Input.GetKey(KeyCode.R))
        {
            StartCoroutine(ReloadYap());


        }

    }
    void ateset()
    {
        RaycastHit hit;

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (atesEdebilirMi && Time.time > iceridenAtesEtmeSikligi && kalanMermi != 0)
            {
                myAnimator.Play("Fire");
                magnumAtes.Play();
                atesEfeceti.Play();
                iceridenAtesEtmeSikligi = Time.time + disaridanAtesEtmesiklik;
                if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, menzil))
                {
                    if (hit.transform.gameObject.CompareTag("Dusman"))
                    {

                        hit.transform.gameObject.GetComponent<Dusman>().darbeAl();
                    }

                }
                if (kalanMermi == 0)
                {

                }
                kalanMermi--;
                kalanMermi_Text.text = kalanMermi.ToString();
            }
        }
    }
    IEnumerator ReloadYap()
    {
        if (kalanMermi < sarjorKapasitesi && toplamMermiSayisi != 0)
        {
            atesEdebilirMi = false;
            myAnimator.Play("sarjordegis");
        }

        yield return new WaitForSeconds(0.7f);
        if (kalanMermi < sarjorKapasitesi && toplamMermiSayisi != 0)
        {

            sarjorDoldurmaTeknikFonlsiyon("MermiYok");
            atesEdebilirMi = true;


        }
    }
    void sarjorDoldurmaTeknikFonlsiyon(string tur)
    {
        switch (tur)
        {
            case "MermiVar":
                break;
            case "MermiYok":
                if (toplamMermiSayisi + kalanMermi < sarjorKapasitesi)
                {
                    kalanMermi += toplamMermiSayisi;
                    toplamMermiSayisi = 0;
                    toplamMermi_Text.text = toplamMermiSayisi.ToString();
                    kalanMermi_Text.text = kalanMermi.ToString();
                    
                }
                else
                {
                    aradakiFark = sarjorKapasitesi - kalanMermi;
                    kalanMermi = sarjorKapasitesi;
                    toplamMermiSayisi -= aradakiFark;
                    toplamMermi_Text.text = toplamMermiSayisi.ToString();
                    kalanMermi_Text.text = kalanMermi.ToString();
                    
                }

                break;
            case "NormalYaz":
                toplamMermi_Text.text = toplamMermiSayisi.ToString();
                kalanMermi_Text.text = kalanMermi.ToString();
                break;

        }
    }
}
