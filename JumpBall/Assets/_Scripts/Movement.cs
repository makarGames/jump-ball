using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] [Min(0)] private int movespeed = 5;
    private Rigidbody2D thisRigidbody;

    private void Awake()
    {
        thisRigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        thisRigidbody.velocity = Vector3.left * movespeed;
    }
}
