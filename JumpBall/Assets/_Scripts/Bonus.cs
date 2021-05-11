using UnityEngine;

public class Bonus : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
            Gravity.S.ActivatingBonus();
        Destroy(gameObject);
    }
}
