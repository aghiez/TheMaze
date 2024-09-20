using UnityEngine;
using UnityEngine.EventSystems;

public class CameraControl : MonoBehaviour, IDragHandler, IPointerDownHandler
{
    public Camera playerCam; // Kamera pemain yang ingin diatur
    public float lookSpeed = 2f; // Kecepatan rotasi kamera
    public float lookXLimit = 75f; // Batas vertikal rotasi kamera
    public float cameraRotationSmooth = 5f; // Kehalusan rotasi kamera

    private float rotationX = 0; // Variabel untuk rotasi vertikal
    private float rotationY = 0; // Variabel untuk rotasi horizontal
    private Vector2 lastTouchPosition; // Menyimpan posisi sentuhan terakhir

    public bool canMove = true; // Mengatur apakah kamera bisa bergerak

    public void OnPointerDown(PointerEventData eventData)
    {
        // Simpan posisi sentuhan saat jari pertama kali menyentuh panel
        lastTouchPosition = eventData.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (canMove)
        {
            // Hitung perubahan posisi sentuhan
            Vector2 delta = eventData.position - lastTouchPosition;

            // Update rotasi berdasarkan gerakan sentuhan jari
            rotationX -= delta.y * lookSpeed * Time.deltaTime;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit); // Batasi rotasi vertikal

            rotationY += delta.x * lookSpeed * Time.deltaTime;

            // Tentukan rotasi target untuk sumbu X dan Y
            Quaternion targetRotationX = Quaternion.Euler(rotationX, 0, 0);
            Quaternion targetRotationY = Quaternion.Euler(0, rotationY, 0);

            // Lakukan rotasi kamera secara halus
            playerCam.transform.localRotation = Quaternion.Slerp(playerCam.transform.localRotation, targetRotationX, Time.deltaTime * cameraRotationSmooth);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotationY, Time.deltaTime * cameraRotationSmooth);

            // Perbarui posisi sentuhan terakhir
            lastTouchPosition = eventData.position;
        }
    }
}