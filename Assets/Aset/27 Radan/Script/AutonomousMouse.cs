using UnityEngine;

public class AutonomousMouse : MonoBehaviour
{
    // Mouse properties
    public float speed = 2.0f;
    public float turnSpeed = 5.0f;
    public float boundaryPadding = 1.0f;
    public float collisionTurnAngle = 90.0f; // Angle to turn when collision occurs

    // Mouse's current direction
    private float direction = 0.0f;

    // Update is called once per frame
    void Update()
    {
        // Calculate movement direction
        Vector3 movementDirection = new Vector3(Mathf.Cos(direction), 0, Mathf.Sin(direction));

        // Move the mouse
        transform.Translate(speed * Time.deltaTime * movementDirection);

        // Update rotation to face the direction of movement
        if (movementDirection != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);
        }

        // Update direction
        direction += Random.Range(-turnSpeed, turnSpeed) * Time.deltaTime;
        direction = Mathf.Repeat(direction, 90.0f);

        // Ensure the mouse stays within the boundaries
        Vector3 position = transform.position;
        if (position.x < boundaryPadding)
            position.x = boundaryPadding;
        else if (position.x > Screen.width - boundaryPadding)
            position.x = Screen.width - boundaryPadding;
        if (position.z < boundaryPadding)
            position.z = boundaryPadding;
        else if (position.z > Screen.height - boundaryPadding)
            position.z = Screen.height - boundaryPadding;
        transform.position = position;
        
    }

    // Handle collision
    private void OnCollisionEnter(Collision collision)
    {
        // Change direction by a set angle upon collision
        direction += collisionTurnAngle;
        direction = Mathf.Repeat(direction, 360.0f);
    }
}
