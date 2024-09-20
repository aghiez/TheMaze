using UnityEngine;
using UnityEngine.EventSystems;

public class CameraControl : MonoBehaviour, IDragHandler, IPointerDownHandler
{
    public Camera playerCam; // Kamera yang ingin diputar
    public float lookSpeed = 2f; // Kecepatan rotasi kamera
    public float lookXLimit = 75f; // Batas rotasi vertikal (pitch)
    public float cameraRotationSmooth = 5f; // Kehalusan rotasi kamera

    private float rotationX = 0; // Untuk mengatur rotasi vertikal (pitch)
    private float rotationY = 0; // Untuk mengatur rotasi horizontal (yaw)
    private Vector2 lastTouchPosition; // Menyimpan posisi sentuhan terakhir

    public bool canMove = true; // Menentukan apakah kamera dapat diputar

    void Start()
    {
        // Ambil rotasi awal dari objek kamera untuk horizontal (yaw)
        rotationY = playerCam.transform.parent.eulerAngles.y;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        // Simpan posisi awal saat jari menyentuh panel
        lastTouchPosition = eventData.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (canMove)
        {
            // Hitung perbedaan posisi jari di layar (delta)
            Vector2 delta = eventData.position - lastTouchPosition;

            // Update rotasi kamera
            rotationX -= delta.y * lookSpeed * Time.deltaTime;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit); // Batasi rotasi vertikal (pitch)

            rotationY += delta.x * lookSpeed * Time.deltaTime;

            // Terapkan rotasi pada kamera:
            Quaternion targetRotationX = Quaternion.Euler(rotationX, 0, 0); // Pitch (vertikal)
            Quaternion targetRotationY = Quaternion.Euler(0, rotationY, 0); // Yaw (horizontal)

            // Rotasi vertikal pada kamera (pitch)
            playerCam.transform.localRotation = targetRotationX;

            // Rotasi horizontal pada parent dari kamera (yaw)
            playerCam.transform.parent.rotation = targetRotationY;

            // Perbarui posisi sentuhan terakhir
            lastTouchPosition = eventData.position;
        }
    }
}
