using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prangkap : MonoBehaviour
{
    public GameObject aaz;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController.walkSpeed = 0f;
            Invoke("speedbalik", 3f);
        }
    }

    private void speedbalik()
    {
        PlayerController.walkSpeed = 3f;
    }
}
