using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{

    PolygonCollider2D polygonCollider2D;

    float randomHiz;

    bool hareket;

    float min, max;


    public bool Hareket  // bu hareket de�i�kenine d��ardan eri�ebilmemiz laz�m ��nk� bir �e�it kontrolc� bu platformu harekete ge�irecek yada durduracak o yuzden property yaz�k 
    {
        get
        {
            return hareket; //de�i�kenin suanki de�erini donuyor
        }

        set
        {
            hareket = value;  //bu preperty bool bir de�er ile �a��r�l�rsa ona hareket de�i�kenini at�yoruz �unku bu de�i�kene direkt olarak eri�im vermiyoruz
        }
    }
    void Start()
    {
        polygonCollider2D = GetComponent<PolygonCollider2D>();
        
        if (KullaniciTercihleri.KolayDegerOku() == 1)
        {
            randomHiz = Random.Range(0.2f, 0.8f);  //random bir h�z belirledik
        }

        if (KullaniciTercihleri.OrtaDegerOku() == 1)
        {
            randomHiz = Random.Range(0.5f, 1.0f);  //random bir h�z belirledik
        }
        if (KullaniciTercihleri.ZorDegerOku() == 1)
        {
            randomHiz = Random.Range(0.8f, 1.5f);  //random bir h�z belirledik
        }

        float objeGenislik = polygonCollider2D.bounds.size.x / 2;

        if (transform.position.x > 0)
        {
            min = objeGenislik;
            max = EkranHesaplayici.instance.Genislik - objeGenislik;
        }
        else
        {
            min = -EkranHesaplayici.instance.Genislik + objeGenislik;
            max = -objeGenislik;
        }

    }

    void Update()
    {
        if (hareket)  //hareket bool true ise ba�la 
        {
            float pingPongX = Mathf.PingPong(Time.time * randomHiz, max - min) + min;  //objenin yapaca�� hareketi belirledik,pingpong ekli oldu�u objenin gidip gelmesini sa�layan metotdur mathf class �nda �al���r bizden iki de�er ister bunlar zaman ve mesafe time.time * random h�z deme sebebi ise pingpong metodu objenin zamana g�re hareket etmesini sa�l�yor o yuzden bizde zamana random de�erler vererek platformlar�n farkl� h�zlarda hareket etmesini sa�lad�k, max - min i yukar�daki if blogunda hesaplad�k  max - min objenin gidece�i mesafe + min deme sebebi ise ba�lang�� noktas�n� tekrar eklememiz gerekir ki geri gelebilsin
            Vector2 pingPong = new Vector2(pingPongX, transform.position.y);  //obje hareket edece�i i�in vector tan�mlad�k ve vectorun x de�eri �stte hesaplanan pingpongX de�eri y de�eri ise objenin kendi de�eri
            transform.position = pingPong;      //objenin transform bile�enine de�eri atad�k
        }
    }


    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Ayaklar")
        {
            GameObject.FindGameObjectWithTag("Player").transform.parent = transform;  //player objesini bulunca playerin parent i bu scriptin ekli oldu�u platformun transpormuna e�it olsun
            GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<OyuncuHareket>().ZiplamayiSifirla();
        }
    }
}
