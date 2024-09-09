using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditController : MonoBehaviour
{
    public float scrollSpeed = 50f; // Kecepatan scroll kredit
    public float endPositionY = 100f; // Posisi Y akhir kredit
    public string nextSceneName = "Ending"; // Nama scene berikutnya setelah kredit

    private RectTransform rectTransform;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();

        // Pastikan kredit hanya muncul sekali
        if (PlayerPrefs.HasKey("CreditsSeen"))
        {
            LoadNextScene();
        }
        else
        {
            PlayerPrefs.SetInt("CreditsSeen", 1);
            PlayerPrefs.Save();
        }
    }

    private void Update()
    {
        if (rectTransform != null)
        {
            // Menggerakkan kredit ke atas
            rectTransform.anchoredPosition += Vector2.up * scrollSpeed * Time.deltaTime;

            // Jika kredit sudah mencapai posisi akhir, lanjutkan ke scene berikutnya
            if (rectTransform.anchoredPosition.y > endPositionY)
            {
                Invoke("LoadNextScene", 2f); // Menunggu beberapa detik sebelum pindah scene
            }
        }
    }

    private void LoadNextScene()
    {
        SceneManager.LoadScene(nextSceneName);
    }
}
