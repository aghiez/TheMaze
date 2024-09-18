using System.Collections;
using UnityEngine;

public class SlowDownPlayer : MonoBehaviour
{
    public float slowDuration = 3f;      // Durasi efek perlambatan
    public float slowMultiplier = 0.5f;  // Faktor perlambatan (0.5 artinya kecepatan berkurang setengah)

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Mulai coroutine untuk memperlambat pemain
            StartCoroutine(SlowPlayer(other));

            // Menghilangkan objek setelah terkena pemain
            Destroy(gameObject);
        }
    }

    private IEnumerator SlowPlayer(Collider player)
    {
        // Ambil komponen PlayerMovement dari pemain
        PlayerMovement playerMovement = player.GetComponent<PlayerMovement>();

        if (playerMovement != null)
        {
            // Kurangi kecepatan pemain
            playerMovement.speed *= slowMultiplier;

            // Tunggu selama durasi perlambatan
            yield return new WaitForSeconds(slowDuration);

            // Kembalikan kecepatan normal pemain
            playerMovement.speed /= slowMultiplier;
        }
    }
}
