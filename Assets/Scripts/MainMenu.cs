using UnityEngine;
using UnityEngine.SceneManagement; // 1. مكتبة إدارة المشاهد (مهمة جداً)

public class MainMenu : MonoBehaviour
{
    // هذه الدالة نربطها بزر Play
    public void PlayGame()
    {
        // 2. الانتقال للمشهد التالي في الترتيب
        // (Index الحالي + 1)
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // هذه الدالة نربطها بزر Quit
    public void QuitGame()
    {
        // 3. طباعة رسالة للتأكد أن الزر يعمل
        Debug.Log("Quit Game!");

        // 4. إغلاق اللعبة نهائياً (يعمل بعد التصدير)
        Application.Quit();
    }
}