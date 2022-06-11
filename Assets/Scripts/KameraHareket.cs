using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KameraHareket : MonoBehaviour
{

    float hiz;  //kameran�n h�z�
    float hizlanma;  //artacak h�z
    float maksimumHiz;  //max h�z

    bool hareket;  //kamera hareketini kontrol etmek i�in


    void Start()
    {
        hareket = true;

        if (KullaniciTercihleri.KolayDegerOku() == 1)
        {
            hiz = 0.3f;     //h�z de�eri
            hizlanma = 0.03f;   //artacak h�z de�eri
            maksimumHiz = 2.5f; //max h�z de�eri
        }
        if (KullaniciTercihleri.OrtaDegerOku() == 1)
        {
            hiz = 0.5f;     //h�z de�eri
            hizlanma = 0.1f;   //artacak h�z de�eri
            maksimumHiz = 3.0f; //max h�z de�eri
        }
        if (KullaniciTercihleri.ZorDegerOku() == 1)
        {
            hiz = 0.8f;     //h�z de�eri
            hizlanma = 0.08f;   //artacak h�z de�eri
            maksimumHiz = 3.5f; //max h�z de�eri
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
        transform.position += transform.up * hiz * Time.deltaTime;  //scriptin ekli oldu�u oyun objesinin y de�erine hiz de�i�kenini ekledik
        hiz += hizlanma * Time.deltaTime;       //hiz de�erine hizlanma �arpan� da eklendi 
        if (hiz > maksimumHiz)      //hiz de�eri max h�z de�erini ge�erse
        {
            hiz = maksimumHiz;      //h�z de�eri max h�z de�eriyle e�it 
        }
    }

    public void OyunBitti()
    {
        hiz = 0.3f;
        hizlanma = 0.0f;
    }
}
