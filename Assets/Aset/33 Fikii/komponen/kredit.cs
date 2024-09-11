using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditController : MonoBehaviour
{
    public float scrollSpeed = 50f; // Kecepatan scroll kredit
    public float endPositionY = 100f; // Posisi Y akhir kredit

    private RectTransform rectTransform;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    private void Update()
    {
        if (rectTransform != null)
        {
            // Menggerakkan kredit ke atas
            rectTransform.anchoredPosition += Vector2.up * scrollSpeed * Time.deltaTime;

            // Jika kredit sudah mencapai posisi akhir, berhenti scroll
            if (rectTransform.anchoredPosition.y > endPositionY)
            {
                // Jika tidak ada scene lain, kita tidak perlu pindah scene
                // Anda bisa menambahkan logika lain di sini jika diperlukan
                // Misalnya, menampilkan pesan atau melakukan sesuatu yang lain
                // Namun, jika ini adalah scene terakhir, Anda bisa membiarkannya berhenti di sini
                enabled = false; // Mematikan skrip agar tidak melakukan update lagi
            }
        }
    }
}
