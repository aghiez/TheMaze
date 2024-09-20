using System.Collections;
using UnityEngine;

public class SlowDownPlayer : MonoBehaviour
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
            PlayerController.walkSpeed = 0.5f;
            PlayerController.runSpeed = 1.5f;
            aaz.SetActive(true);
            Invoke("speedbalik", 1f);
        }
    }

    private void speedbalik()
    {
        aaz.SetActive(false);
        PlayerController.walkSpeed = 3f;
        PlayerController.runSpeed = 5f;
        Destroy(gameObject);
    }
}
