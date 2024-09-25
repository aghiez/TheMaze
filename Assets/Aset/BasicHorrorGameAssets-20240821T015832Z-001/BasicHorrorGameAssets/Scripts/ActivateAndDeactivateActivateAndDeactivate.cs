using System.Collections;
using UnityEngine;

public class ActivateAndDeactivate : MonoBehaviour
{
    public GameObject objectToActivate;  // Drag dan drop GameObject yang ingin diaktifkan dan dinonaktifkan
    public float delayTime = 1f;         // Durasi (1 detik) sebelum menonaktifkan kembali

    // Method untuk mengaktifkan GameObject dan kemudian menonaktifkannya setelah delay
    public void ActivateAndDeactivateObject()
    {
        if (objectToActivate != null)
        {
            StartCoroutine(ActivateThenDeactivate());
        }
        else
        {
            Debug.LogError("No GameObject assigned to activate/deactivate!");
        }
    }

    // Coroutine untuk mengaktifkan GameObject, tunggu beberapa saat, lalu menonaktifkan kembali
    private IEnumerator ActivateThenDeactivate()
    {
        objectToActivate.SetActive(true);    // Aktifkan GameObject
        Debug.Log("GameObject activated!");

        yield return new WaitForSeconds(delayTime); // Tunggu selama 1 detik (atau sesuai delayTime)

        objectToActivate.SetActive(false);   // Nonaktifkan GameObject
        Debug.Log("GameObject deactivated after " + delayTime + " seconds.");
    }
}
