using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanturnPickUp : MonoBehaviour
{
    private GameObject OB;
    public GameObject handUI;
    public GameObject lanturn;
    public GameObject button;

    int a = 0;



    private bool inReach;


    void Start()
    {
        OB = this.gameObject;

        handUI.SetActive(false);

        lanturn.SetActive(false);


    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = true;
            handUI.SetActive(true);
            button.SetActive(true);
        }

    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = false;
            handUI.SetActive(false);
            button.SetActive(false);
        }
    }

    void Update()
    {


        if (inReach && a == 1)
        {
           handUI.SetActive(false);
            lanturn.SetActive(true);
            StartCoroutine(end());
            a = 0;
        }
    }
    
    IEnumerator end()
    {
        yield return new WaitForSeconds(.01f);
        Destroy(OB);
    }


    public void ambil(){
        a = 1;
    }
}
