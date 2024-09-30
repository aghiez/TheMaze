using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseChest : MonoBehaviour
{
    private GameObject OB;
    public GameObject handUI;
    public GameObject objToActivate;
    
    int a = 0;

    private bool inReach;


    void Start()
    {

        OB = this.gameObject;

        handUI.SetActive(false);

        objToActivate.SetActive(false);

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


        if (inReach && a == 1)
        {
            handUI.SetActive(false);
            objToActivate.SetActive(true);
            OB.GetComponent<Animator>().SetBool("open", true);
            OB.GetComponent<BoxCollider>().enabled = false;
            a = 0;
        }
    }
      public void ambil()
    {
        a = 1;
        StartCoroutine(SetAtoZeroAfterDelay(1f)); // Menunggu 1 detik sebelum mengubah a jadi 0
    }

    // Coroutine untuk mengubah a menjadi 0 setelah 1 detik
    private IEnumerator SetAtoZeroAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay); // Tunggu selama 1 detik
        a = 0; // Setelah 1 detik, ubah nilai a menjadi 0
    }
}
