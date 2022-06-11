using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{

    PolygonCollider2D polygonCollider2D;

    float randomHiz;

    bool hareket;

    float min, max;


    public bool Hareket  // bu hareket deðiþkenine dýþardan eriþebilmemiz lazým çünkü bir çeþit kontrolcü bu platformu harekete geçirecek yada durduracak o yuzden property yazýk 
    {
        get
        {
            return hareket; //deðiþkenin suanki deðerini donuyor
        }

        set
        {
            hareket = value;  //bu preperty bool bir deðer ile çaðýrýlýrsa ona hareket deðiþkenini atýyoruz çunku bu deðiþkene direkt olarak eriþim vermiyoruz
        }
    }
    void Start()
    {
        polygonCollider2D = GetComponent<PolygonCollider2D>();
        
        if (KullaniciTercihleri.KolayDegerOku() == 1)
        {
            randomHiz = Random.Range(0.2f, 0.8f);  //random bir hýz belirledik
        }

        if (KullaniciTercihleri.OrtaDegerOku() == 1)
        {
            randomHiz = Random.Range(0.5f, 1.0f);  //random bir hýz belirledik
        }
        if (KullaniciTercihleri.ZorDegerOku() == 1)
        {
            randomHiz = Random.Range(0.8f, 1.5f);  //random bir hýz belirledik
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
        if (hareket)  //hareket bool true ise baþla 
        {
            float pingPongX = Mathf.PingPong(Time.time * randomHiz, max - min) + min;  //objenin yapacaðý hareketi belirledik,pingpong ekli olduðu objenin gidip gelmesini saðlayan metotdur mathf class ýnda çalýþýr bizden iki deðer ister bunlar zaman ve mesafe time.time * random hýz deme sebebi ise pingpong metodu objenin zamana göre hareket etmesini saðlýyor o yuzden bizde zamana random deðerler vererek platformlarýn farklý hýzlarda hareket etmesini saðladýk, max - min i yukarýdaki if blogunda hesapladýk  max - min objenin gideceði mesafe + min deme sebebi ise baþlangýþ noktasýný tekrar eklememiz gerekir ki geri gelebilsin
            Vector2 pingPong = new Vector2(pingPongX, transform.position.y);  //obje hareket edeceði için vector tanýmladýk ve vectorun x deðeri üstte hesaplanan pingpongX deðeri y deðeri ise objenin kendi deðeri
            transform.position = pingPong;      //objenin transform bileþenine deðeri atadýk
        }
    }


    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Ayaklar")
        {
            GameObject.FindGameObjectWithTag("Player").transform.parent = transform;  //player objesini bulunca playerin parent i bu scriptin ekli olduðu platformun transpormuna eþit olsun
            GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<OyuncuHareket>().ZiplamayiSifirla();
        }
    }
}
