using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tertabrak : MonoBehaviour
{
    private GameObject OB;

    // Start is called before the first frame update
    void Start()
    {
        OB = this.gameObject;
    }
   

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OB.GetComponent<Animator>().SetBool("fall", true);
        }
    }
}
