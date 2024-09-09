using UnityEngine;

public class AnimalMovement : MonoBehaviour
{
    public float speed = 5f; // Kecepatan gerak hewan
    public float turnAngle = 90f; // Sudut belok saat tabrakan (kanan, kiri, atau berbalik)
    public float positionTolerance = 0.1f; // Toleransi posisi untuk mendeteksi tidak bergerak
    public float notMovingTimeThreshold = 2f; // Waktu dalam detik sebelum berbelok
    public float playerDetectionRadius = 15f; // Radius deteksi pemain
    public float playerAvoidanceRadius = 1f; // Radius untuk menghindari pemain

    private Rigidbody rb;  // Referensi ke komponen Rigidbody
    private float direction = 0f; // Arah gerak dalam radian
    private Vector3 lastPosition; // Posisi terakhir
    private float notMovingTimer = 0f; // Timer untuk memantau waktu tidak bergerak
    private Transform player; // Referensi ke pemain

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Mengambil komponen Rigidbody dari objek
        // Set arah awal
        direction = Random.Range(0f, 2f * Mathf.PI);
        lastPosition = transform.position; // Simpan posisi awal
        player = GameObject.FindGameObjectWithTag("Player").transform; // Temukan pemain dengan tag "Player"
    }

    void FixedUpdate()
    {
        Move();
        CheckIfNotMoving();
        CheckPlayerProximity();
    }

    void Move()
    {
        // Menghitung arah gerak
        Vector3 movement = new Vector3(Mathf.Cos(direction), 0, Mathf.Sin(direction)).normalized;

        // Menggerakkan Rigidbody
        rb.velocity = movement * speed;

        // Memutar hewan ke arah gerak
        if (movement != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(movement, Vector3.up);
            rb.rotation = Quaternion.Slerp(rb.rotation, targetRotation, Time.deltaTime * 5f); // 5f adalah kecepatan rotasi
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        TurnRandomly();
    }

    void CheckIfNotMoving()
    {
        // Periksa apakah posisi saat ini sama dengan posisi terakhir
        if (Vector3.Distance(transform.position, lastPosition) < positionTolerance)
        {
            notMovingTimer += Time.deltaTime;

            if (notMovingTimer >= notMovingTimeThreshold)
            {
                TurnRandomly();
                notMovingTimer = 0f; // Reset timer setelah berbelok
            }
        }
        else
        {
            notMovingTimer = 0f; // Reset timer jika hewan mulai bergerak lagi
        }

        // Simpan posisi saat ini sebagai posisi terakhir
        lastPosition = transform.position;
    }

    void CheckPlayerProximity()
    {
        if (player == null) return; // Jika tidak ada pemain, tidak perlu melanjutkan

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer < playerAvoidanceRadius)
        {
            // Jika dalam radius 5 unit, berbelok secara acak
           // TurnRandomly();
        }
        else if (distanceToPlayer < playerDetectionRadius)
        {
            // Jika dalam radius 20 unit, arahkan ke pemain
            direction = Mathf.Atan2(player.position.z - transform.position.z, player.position.x - transform.position.x);
          //  speed= speed+3f ;
        }
    }

    void TurnRandomly()
    {
        // Acak arah belok (kanan, kiri, atau berbalik)
        float turn = Random.Range(0, 3); // 0: kanan, 1: kiri, 2: berbalik

        switch (turn)
        {
            case 0: // Belok kanan
                direction += turnAngle * Mathf.Deg2Rad; // Mengubah arah 90 derajat ke kanan
                break;
            case 1: // Belok kiri
                direction -= turnAngle * Mathf.Deg2Rad; // Mengubah arah 90 derajat ke kiri
                break;
            case 2: // Berbalik
                direction += Mathf.PI; // 180 derajat berbalik
                break;
        }

        // Menjaga arah tetap dalam rentang 0 sampai 2 * PI
        direction = Mathf.Repeat(direction, 2f * Mathf.PI);
    }
}
