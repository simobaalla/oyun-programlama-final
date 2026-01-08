using UnityEngine;
using TMPro;

public class HealthManager : MonoBehaviour
{
    public TMP_Text heartText;

    void Update()
    {
        // نحدث النص ليأخذ القيمة من سكريبت صحة اللاعب
        heartText.text = "" + PlayerHealth.health;
    }
}