using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lemari : MonoBehaviour
{
    float lemari = 0;
    private GameObject OB;
    public GameObject handUI;


    private bool inReach;


    void Start()
    {

        OB = this.gameObject;

        handUI.SetActive(false);


    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = true;
            handUI.SetActive(true);
        }

    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = false;
            handUI.SetActive(false);
        }
    }

    void Update()
    {

        if (inReach && Input.GetButtonDown("Interact"))
        {
            if(lemari == 0){
                OB.GetComponent<Animator>().SetBool("open", true);
                lemari = 1;
                Debug.Log("aaa");
            }else{
                OB.GetComponent<Animator>().SetBool("open", false);
                Debug.Log("bbb");
                lemari = 0;
            }
        }
    }

}
