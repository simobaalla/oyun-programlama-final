using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    // المتغير الذي نضع فيه اللوحة (Panel)
    public GameObject pausePanel;

    // 1. هذه الدالة نربطها بزر التوقف (Pause Button)
    public void PauseGame()
    {
        pausePanel.SetActive(true); // أظهر القائمة
        Time.timeScale = 0f;        // جمد الوقت
    }

    // 2. هذه الدالة نربطها بزر الاستكمال (Resume Button)
    public void ResumeGame()
    {
        pausePanel.SetActive(false); // أخفِ القائمة
        Time.timeScale = 1f;         // أعد الوقت
    }

    // 3. هذه الدالة نربطها زر القائمة (Menu Button)
    public void GoToMenu()
    {
        Time.timeScale = 1f;         // مهم: فك التجميد
        SceneManager.LoadScene(0);   // العودة للمشهد 0
    }
}