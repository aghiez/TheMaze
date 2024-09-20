using System.Collections;
using UnityEngine;

public class SlowDownPlayer : MonoBehaviour
{
    public GameObject aaz;
    public GameObject perangkap;
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
            aaz.SetActive(true);
            Invoke("speedbalik", 2f);

        }
    }

    private void speedbalik()
    {
        aaz.SetActive(false);
        PlayerController.walkSpeed = 2f;
         perangkap.SetActive(false);
        Invoke("PERANGKAP", 8f);
       // Destroy(gameObject);
    }
     private void PERANGKAP()
    {
        perangkap.SetActive(true);
       // PlayerController.walkSpeed = 2f;
       // Invoke("PERANGKAP", 7f);
       // Destroy(gameObject);
    }
}
