using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public static int health = 4;

    // 1. متغير "الحماية" (هل يمكنه تلقي الضرر؟)
    private bool canTakeDamage = true;

    void Start()
    {
        health = 4;
    }
    public AudioClip hurtSound;
    void OnCollisionEnter2D(Collision2D other)
    {
        // 2. الشرط الجديد: هل هو عدو؟ وهل الحماية مفتوحة؟
        if (other.gameObject.CompareTag("Enemy") && canTakeDamage == true)
        {
            AudioSource.PlayClipAtPoint(hurtSound, transform.position);
            health--;

            // أغلق الحماية فوراً (ممنوع الضرب مرة أخرى حالياً)
            canTakeDamage = false;

           

            if (health <= 0)
            {
                RestartGame();
            }
            else
            {
                // 3. شغل المؤقت: اطلب دالة فتح الحماية بعد ثانية واحدة
                Invoke("ResetDamage", 1f);
            }
        }
    }

    // دالة صغيرة لفتح الحماية
    void ResetDamage()
    {
        canTakeDamage = true;
    }

    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}