using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Değişkenler (Variables)
    [SerializeField] private float speed = 5f;        // Hareket hızı
    [SerializeField] private float jumpPower = 10f;   // Zıplama gücü
    [SerializeField] private AudioSource walkAudio;   // Yürüme sesi kaynağı (Speaker)

    private Rigidbody2D body;      // Fizik bileşeni
    private Animator anim;         // Animasyon kontrolcüsü
    private bool grounded;         // Oyuncu yerde mi? (Kontrol değişkeni)

    private void Awake()
    {
        // Oyuncunun üzerindeki bileşenleri alıyoruz
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        // 1. Yatay Hareket (Horizontal Movement)
        // Klavyeden sağ/sol girişini al (-1 ile 1 arası)
        float horizontalInput = Input.GetAxis("Horizontal");

        // Hızı oyuncuya uygula
        body.linearVelocity = new Vector2(horizontalInput * speed, body.linearVelocity.y);

        // 2. Yön Çevirme (Flip Face)
        // Eğer sağa gidiyorsa yüzünü sağa çevir
        if (horizontalInput > 0.01f)
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        // Eğer sola gidiyorsa yüzünü sola çevir
        else if (horizontalInput < -0.01f)
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);

        // 3. Zıplama Girdisi (Jump Input)
        // Boşluk tuşuna basıldıysa VE oyuncu yerdeyse
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            Jump();
        }

        // 4. Animasyon Güncelleme (Update Animation)
        // "run" parametresini ayarla: Hareket varsa true, yoksa false
        anim.SetBool("run", horizontalInput != 0);
        // "grounded" parametresini ayarla: Yerdeysek true, havadaysak false
        anim.SetBool("grounded", grounded);

        // 5. Yürüme Sesi Mantığı (Walking Sound Logic)
        // Eğer hareket ediyorsak VE yerdeysek
        if (horizontalInput != 0 && grounded)
        {
            // Ses zaten çalmıyorsa başlat (Makineli tüfek efektini önlemek için)
            if (!walkAudio.isPlaying)
            {
                walkAudio.Play();
            }
        }
        else
        {
            // Duruyorsak veya zıplıyorsak sesi durdur
            walkAudio.Stop();
        }
    }

    private void Jump()
    {
        // Yukarı doğru kuvvet uygula
        body.linearVelocity = new Vector2(body.linearVelocity.x, jumpPower);
        // Artık havada olduğumuz için grounded false olur
        grounded = false;
    }

    // Yere Temas Kontrolü (Collision Check)
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Eğer dokunduğumuz objenin etiketi "Ground" ise
        if (collision.gameObject.tag == "Ground")
        {
            grounded = true; // Tekrar yerdeyiz
        }
    }
}