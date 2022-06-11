using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OyuncuHareket : MonoBehaviour
{
    Rigidbody2D rb2D;       //hareket ettirebilmek i�in objenin rigidbody bile�enine eri�memiz gerek
    Animator animator;      //animator componentini ekledik

    Vector2 velocity;       //karakterin h�z�n� ayarlayabilmemiz i�in vectore ihtiyac�m�z var

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
        float hareketInput = Input.GetAxisRaw("Horizontal");        //kalvyede ad veya sa� sol tu�lar�na bas�l�nca hareket de�eri -1 0 1 aras�nda de�i�ecek
        Vector2 scale = transform.localScale;  //ilk ba�taki scale de�erinin referans�

        if (hareketInput > 0)
        {
            velocity.x = Mathf.MoveTowards(velocity.x, hareketInput * hiz, hizlanma* Time.deltaTime); //hareketimiz x ekseninde oldugu i�in velocity.x dedik ve mathf.MoveTowards metodunu �a��rd�k bu metod ileriye hareket demek 3 parametre al�r bunlar ,ge�erli de�er,ula��lmak istenen de�er ve uygulanacak olan de�i�im miktar� 
            animator.SetBool("Walk", true);  //y�r�me animasyonu true
            scale.x = 0.3f;    //karakterin y�n�,karakterin scale de�eri neyse burda da onu yazmam�z gerekiyor aksi halde karakterin �ekli bozuluyor
        }
        else if (hareketInput < 0)      // > 0 ile ayn� kodlar sadece scale de�er, -1 oldu 
        {
            velocity.x = Mathf.MoveTowards(velocity.x, hareketInput * hiz, hizlanma * Time.deltaTime);
            animator.SetBool("Walk", true);
            scale.x = -0.3f;
        }
        else        // =0 ise 
        {
            velocity.x = Mathf.MoveTowards(velocity.x, 0, yavaslama * Time.deltaTime); //ula��lmak istenen de�er 0 
            animator.SetBool("Walk", false);    //y�r�me animasyonu false 
        }

        transform.localScale = scale;   //olu�turdu�umuz scale de�erini karaktere att�k
        gameObject.transform.Translate(velocity * Time.deltaTime); //olu�turdu�umuz velocity vectorunu karakterimizin transform bile�enine att�k

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
        Vector2 scale = transform.localScale;  //ilk ba�taki scale de�erinin referans�

        if (hareketInput > 0)
        {
            velocity.x = Mathf.MoveTowards(velocity.x, hareketInput * hiz, hizlanma * Time.deltaTime); //hareketimiz x ekseninde oldugu i�in velocity.x dedik ve mathf.MoveTowards metodunu �a��rd�k bu metod ileriye hareket demek 3 parametre al�r bunlar ,ge�erli de�er,ula��lmak istenen de�er ve uygulanacak olan de�i�im miktar� 
            animator.SetBool("Walk", true);  //y�r�me animasyonu true
            scale.x = 0.3f;    //karakterin y�n�,karakterin scale de�eri neyse burda da onu yazmam�z gerekiyor aksi halde karakterin �ekli bozuluyor
        }
        else if (hareketInput < 0)      // > 0 ile ayn� kodlar sadece scale de�er, -1 oldu 
        {
            velocity.x = Mathf.MoveTowards(velocity.x, hareketInput * hiz, hizlanma * Time.deltaTime);
            animator.SetBool("Walk", true);
            scale.x = -0.3f;
        }
        else        // =0 ise 
        {
            velocity.x = Mathf.MoveTowards(velocity.x, 0, yavaslama * Time.deltaTime); //ula��lmak istenen de�er 0 
            animator.SetBool("Walk", false);    //y�r�me animasyonu false 
        }

        transform.localScale = scale;   //olu�turdu�umuz scale de�erini karaktere att�k
        gameObject.transform.Translate(velocity * Time.deltaTime); //olu�turdu�umuz velocity vectorunu karakterimizin transform bile�enine att�k

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
