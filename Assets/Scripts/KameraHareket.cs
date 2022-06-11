using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KameraHareket : MonoBehaviour
{

    float hiz;  //kameranýn hýzý
    float hizlanma;  //artacak hýz
    float maksimumHiz;  //max hýz

    bool hareket;  //kamera hareketini kontrol etmek için


    void Start()
    {
        hareket = true;

        if (KullaniciTercihleri.KolayDegerOku() == 1)
        {
            hiz = 0.3f;     //hýz deðeri
            hizlanma = 0.03f;   //artacak hýz deðeri
            maksimumHiz = 2.5f; //max hýz deðeri
        }
        if (KullaniciTercihleri.OrtaDegerOku() == 1)
        {
            hiz = 0.5f;     //hýz deðeri
            hizlanma = 0.1f;   //artacak hýz deðeri
            maksimumHiz = 3.0f; //max hýz deðeri
        }
        if (KullaniciTercihleri.ZorDegerOku() == 1)
        {
            hiz = 0.8f;     //hýz deðeri
            hizlanma = 0.08f;   //artacak hýz deðeri
            maksimumHiz = 3.5f; //max hýz deðeri
        }
        
    }
    void Update()
    {
        if (hareket)
        {
            KamerayiHareketEttir();
        }
    }
    void KamerayiHareketEttir()
    {
        transform.position += transform.up * hiz * Time.deltaTime;  //scriptin ekli olduðu oyun objesinin y deðerine hiz deðiþkenini ekledik
        hiz += hizlanma * Time.deltaTime;       //hiz deðerine hizlanma çarpaný da eklendi 
        if (hiz > maksimumHiz)      //hiz deðeri max hýz deðerini geçerse
        {
            hiz = maksimumHiz;      //hýz deðeri max hýz deðeriyle eþit 
        }
    }

    public void OyunBitti()
    {
        hiz = 0.3f;
        hizlanma = 0.0f;
    }
}
