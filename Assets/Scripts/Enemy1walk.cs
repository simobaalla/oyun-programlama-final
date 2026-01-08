using UnityEngine;

public class EnemyWalk : MonoBehaviour
{
    public float speed = 2f;      // Düşmanın hızı
    public float distance = 3f;   // Ne kadar uzağa gidecek? (Devriye mesafesi)

    private float startPos;       // Başlangıç konumu (X ekseni)
    private bool isGoingLeft = true; // 1. Başlangıçta sola doğru gidiyor mu?

    void Start()
    {
        // Oyun başladığında düşmanın nerede olduğunu kaydediyoruz (Referans noktası)
        startPos = transform.position.x;
    }

    void Update()
    {
        if (isGoingLeft)
        {
            // Sola Hareket
            // Space.World: Dünyaya göre hareket et (Dönüşten etkilenmemesi için çok önemli!)
            transform.Translate(Vector2.left * speed * Time.deltaTime, Space.World);

            // Kontrol: Başlangıç noktasından (startPos) belirlenen mesafe (distance) kadar uzaklaştı mı?
            // (Sola gittiği için X değeri azalır, bu yüzden çıkarma işlemi yapıyoruz)
            if (transform.position.x < startPos - distance)
            {
                Flip(); // Yön değiştir
            }
        }
        else
        {
            // Sağa Hareket
            transform.Translate(Vector2.right * speed * Time.deltaTime, Space.World);

            // Kontrol: Başlangıç noktasına geri döndü mü?
            if (transform.position.x > startPos)
            {
                Flip(); // Yön değiştir
            }
        }
    }

    // Yön Değiştirme ve Dönme Fonksiyonu
    void Flip()
    {
        // Mantıksal yönü tersine çevir (True <-> False)
        isGoingLeft = !isGoingLeft;

        // Düşmanı Y ekseninde 180 derece döndür (Yüzünü diğer tarafa çevir)
        transform.Rotate(0, 180, 0);
    }
}