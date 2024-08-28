using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BukaLaci : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject laci;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GeserLaci(){
        sfloat moveSpeed = 5f;
        Vector3 customDirection = new Vector3(0, -5, 0);
        laci.transform.Translate(customDirection * moveSpeed * Time.deltaTime);
    }
}
