using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flying : MonoBehaviour
{
    public GameObject Player;
    public GameObject Alas;
    public float time = 3;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(Player.transform.position.y);
        Debug.Log(Alas.transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        if(Player.transform.position.y >= Alas.transform.position.y)
        {
            Player.transform.Translate(Vector3.down * Time.deltaTime);
            Player.transform.Translate(Vector3.forward * Time.deltaTime);


            // if(muter == 0){
            //     Vector3 rotate = new Vector3(0, 90, 0);
            //     Debug.Log("ahah");
            //     Player.transform.Rotate(rotate * 0.1f);
            //     muter = 1;
            // }


            

            if(time >= 0){

                time -= Time.deltaTime;
            } else if(time <= 0){
                Debug.Log("ggg");
                time = 3;
            }



        }

    }
}
