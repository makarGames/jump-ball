using UnityEngine;

[RequireComponent(typeof(CircleCollider2D), typeof(Rigidbody2D))]
public class Bonus : MonoBehaviour
{
    [SerializeField] [Min(0)] private int speed = 5;

    private Rigidbody2D thisRigidbody;
    private CircleCollider2D thisCollider;

    private void Awake()
    {
        thisRigidbody = GetComponent<Rigidbody2D>();
        thisCollider = GetComponent<CircleCollider2D>();
    }

    private void FixedUpdate()
    {
        thisRigidbody.velocity = Vector3.left * speed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
            Gravity.S.ActivatingBonus();
        Destroy(gameObject);
    }
}
