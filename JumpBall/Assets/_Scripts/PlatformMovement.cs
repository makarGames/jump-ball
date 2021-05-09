using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlatformMovement : MonoBehaviour
{
    [SerializeField] [Min(0)] private int speed = 5;

    private Rigidbody2D thisRigidbody;

    private void Awake()
    {
        thisRigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        thisRigidbody.velocity = Vector3.left * speed;
    }
}
