using UnityEngine;
using UnityEngine.SceneManagement; // 1. مكتبة إدارة المشاهد (ضرورية جداً)

public class FinishPoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 2. الشرط: هل الكائن الذي لمس العلم هو "اللاعب"؟
        if (collision.gameObject.CompareTag("Player"))
        {
            // 3. الانتقال للمشهد التالي تلقائياً
            // (رقم المشهد الحالي + 1)
            // يعني لو كنت في Level 1 سينقلك لـ Level 2
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}