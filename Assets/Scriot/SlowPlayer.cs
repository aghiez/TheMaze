using UnityEngine;

public class SlowPlayer : MonoBehaviour
{
    public float slowSpeed = 2f;  // Kecepatan saat pemain diperlambat
    public float normalSpeed = 5f;  // Kecepatan normal pemain
    private bool isSlowed = false;
    
    private PlayerMovement playerMovement;

    void Start()
    {
        // Mendapatkan komponen PlayerMovement dari pemain
        playerMovement = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && !isSlowed)
        {
            // Memperlambat pemain saat bersentuhan
            playerMovement.speed = slowSpeed;
            isSlowed = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && isSlowed)
        {
            // Mengembalikan kecepatan normal saat pemain meninggalkan objek
            playerMovement.speed = normalSpeed;
            isSlowed = false;
        }
    }
}
