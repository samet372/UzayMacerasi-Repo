using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OyuncuHareket : MonoBehaviour
{
    Rigidbody2D rb2D;       //hareket ettirebilmek için objenin rigidbody bileþenine eriþmemiz gerek
    Animator animator;      //animator componentini ekledik

    Vector2 velocity;       //karakterin hýzýný ayarlayabilmemiz için vectore ihtiyacýmýz var

    [SerializeField]
    float hiz;

    [SerializeField]
    float hizlanma;

    [SerializeField]
    float yavaslama;

    [SerializeField]
    float ziplamaGucu;

    [SerializeField]
    int ziplamaLimiti;

    int ziplamaSayisi;

    Joystick joystick;

    JoystickButton joystickButton;

    bool zipliyor;

    void Start()
    {
        joystickButton = FindObjectOfType<JoystickButton>();
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        joystick = FindObjectOfType<Joystick>();

        if (KullaniciTercihleri.KolayDegerOku() == 1)
        {
            ziplamaLimiti = 3;
        }
        if (KullaniciTercihleri.OrtaDegerOku() == 1)
        {
            ziplamaLimiti = 3;
        }
        if (KullaniciTercihleri.ZorDegerOku() == 1)
        {
            ziplamaLimiti = 2;
        }
    }
    void Update()
    {
#if UNITY_EDITOR
        KlavyeKontrol();
#else
                JoystickKontrol();
#endif
    }
    void KlavyeKontrol()
    {
        float hareketInput = Input.GetAxisRaw("Horizontal");        //kalvyede ad veya sað sol tuþlarýna basýlýnca hareket deðeri -1 0 1 arasýnda deðiþecek
        Vector2 scale = transform.localScale;  //ilk baþtaki scale deðerinin referansý

        if (hareketInput > 0)
        {
            velocity.x = Mathf.MoveTowards(velocity.x, hareketInput * hiz, hizlanma* Time.deltaTime); //hareketimiz x ekseninde oldugu için velocity.x dedik ve mathf.MoveTowards metodunu çaðýrdýk bu metod ileriye hareket demek 3 parametre alýr bunlar ,geçerli deðer,ulaþýlmak istenen deðer ve uygulanacak olan deðiþim miktarý 
            animator.SetBool("Walk", true);  //yürüme animasyonu true
            scale.x = 0.3f;    //karakterin yönü,karakterin scale deðeri neyse burda da onu yazmamýz gerekiyor aksi halde karakterin þekli bozuluyor
        }
        else if (hareketInput < 0)      // > 0 ile ayný kodlar sadece scale deðer, -1 oldu 
        {
            velocity.x = Mathf.MoveTowards(velocity.x, hareketInput * hiz, hizlanma * Time.deltaTime);
            animator.SetBool("Walk", true);
            scale.x = -0.3f;
        }
        else        // =0 ise 
        {
            velocity.x = Mathf.MoveTowards(velocity.x, 0, yavaslama * Time.deltaTime); //ulaþýlmak istenen deðer 0 
            animator.SetBool("Walk", false);    //yürüme animasyonu false 
        }

        transform.localScale = scale;   //oluþturduðumuz scale deðerini karaktere attýk
        gameObject.transform.Translate(velocity * Time.deltaTime); //oluþturduðumuz velocity vectorunu karakterimizin transform bileþenine attýk

        if (Input.GetKeyDown("space"))
        {
            ZiplamayiBaslat();
        }

        if (Input.GetKeyUp("space"))
        {
            ZiplamayiDurdur();
        }
    }


    void JoystickKontrol()
    {
        float hareketInput = joystick.Horizontal;
        Vector2 scale = transform.localScale;  //ilk baþtaki scale deðerinin referansý

        if (hareketInput > 0)
        {
            velocity.x = Mathf.MoveTowards(velocity.x, hareketInput * hiz, hizlanma * Time.deltaTime); //hareketimiz x ekseninde oldugu için velocity.x dedik ve mathf.MoveTowards metodunu çaðýrdýk bu metod ileriye hareket demek 3 parametre alýr bunlar ,geçerli deðer,ulaþýlmak istenen deðer ve uygulanacak olan deðiþim miktarý 
            animator.SetBool("Walk", true);  //yürüme animasyonu true
            scale.x = 0.3f;    //karakterin yönü,karakterin scale deðeri neyse burda da onu yazmamýz gerekiyor aksi halde karakterin þekli bozuluyor
        }
        else if (hareketInput < 0)      // > 0 ile ayný kodlar sadece scale deðer, -1 oldu 
        {
            velocity.x = Mathf.MoveTowards(velocity.x, hareketInput * hiz, hizlanma * Time.deltaTime);
            animator.SetBool("Walk", true);
            scale.x = -0.3f;
        }
        else        // =0 ise 
        {
            velocity.x = Mathf.MoveTowards(velocity.x, 0, yavaslama * Time.deltaTime); //ulaþýlmak istenen deðer 0 
            animator.SetBool("Walk", false);    //yürüme animasyonu false 
        }

        transform.localScale = scale;   //oluþturduðumuz scale deðerini karaktere attýk
        gameObject.transform.Translate(velocity * Time.deltaTime); //oluþturduðumuz velocity vectorunu karakterimizin transform bileþenine attýk

        if (joystickButton.tusaBasildi == true && zipliyor == false)
        {
            zipliyor = true;
            ZiplamayiBaslat();
        }

        if (joystickButton.tusaBasildi == false && zipliyor == true)
        {
            zipliyor = false;
            ZiplamayiDurdur();
        }
    }


    void ZiplamayiBaslat()
    {
        if (ziplamaSayisi < ziplamaLimiti)
        {
            FindObjectOfType<SesKontrol>().ZiplamaSes();
            rb2D.AddForce(new Vector2(0, ziplamaGucu), ForceMode2D.Impulse);
            animator.SetBool("Jump", true);
            FindObjectOfType<SliderKontrol>().SliderDeger(ziplamaLimiti, ziplamaSayisi);
        }
    }
    void ZiplamayiDurdur()
    {
        animator.SetBool("Jump", false);
        ziplamaSayisi++;
        FindObjectOfType<SliderKontrol>().SliderDeger(ziplamaLimiti, ziplamaSayisi);
    }

    public void ZiplamayiSifirla()
    {
        ziplamaSayisi = 0;
        FindObjectOfType<SliderKontrol>().SliderDeger(ziplamaLimiti, ziplamaSayisi);

    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Olum")
        {
            FindObjectOfType<OyunKontrol>().OyunuBitir();
        }
    }

    public void OyunBitti()
    {
        Destroy(gameObject);
    }
}
