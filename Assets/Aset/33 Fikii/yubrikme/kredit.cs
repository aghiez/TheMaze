using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditController : MonoBehaviour
{
    public float scrollSpeed = 50f; // Kecepatan scroll kredit
    public float endPositionY = 2000f; // Posisi Y akhir kredit

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
                enabled = false; // Mematikan skrip agar tidak melakukan update lagi
            }
        }
    }
}
