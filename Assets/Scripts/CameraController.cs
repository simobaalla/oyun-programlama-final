using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Kamera hareketinin yumuşaklık hızı (Daha düşük = Daha hızlı)
    [SerializeField] private float speed = 0.25f;

    // SmoothDamp fonksiyonunun hız hesaplaması için kullandığı geçici değişken
    private Vector3 velocity = Vector3.zero;

    // Takip edilecek oyuncu (Player objesini buraya sürükle)
    [SerializeField] private Transform player;

    // Kameranın oyuncunun ne kadar önünde duracağı (X Ekseni)
    [SerializeField] private float aheadDistance = 1f;

    // Kameranın oyuncudan ne kadar yüksekte duracağı (Y Ekseni)
    [SerializeField] private float yOffset = 1f;

    private void Update()
    {
        // 1. Yatay (X) Hedef Pozisyonu
        // Oyuncunun X pozisyonuna "aheadDistance" ekleyerek kameranın biraz önde olmasını sağlıyoruz
        float targetX = player.position.x + aheadDistance;

        // 2. Dikey (Y) Hedef Pozisyonu
        // Oyuncunun Y pozisyonuna "yOffset" ekleyerek kameranın yukarıda kalmasını sağlıyoruz
        float targetY = player.position.y + yOffset;

        // 3. Hareketi Uygula (SmoothDamp)
        // Kamerayı, belirlediğimiz (targetX, targetY) noktasına yumuşak bir şekilde kaydırıyoruz.
        // Z pozisyonunu değiştirmiyoruz (transform.position.z) çünkü kamera derinliği sabit kalmalı.
        transform.position = Vector3.SmoothDamp(
            transform.position,                                  // Şu anki konum
            new Vector3(targetX, targetY, transform.position.z), // Gitmek istediğimiz konum
            ref velocity,                                        // Hız referansı
            speed                                                // Geçiş süresi
        );
    }
}