using UnityEngine;

public class Coin : MonoBehaviour
{
    public static int coinsCount = 0;

    // 1. متغير لنضع فيه ملف الصوت
    public AudioClip coinSound;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            coinsCount++;

            // 2. السطر السحري: شغل الصوت في مكان العملة
            // (اسم الصوت، المكان)
            AudioSource.PlayClipAtPoint(coinSound, transform.position);

            Destroy(gameObject);
        }
    }
}