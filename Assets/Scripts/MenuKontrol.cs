using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuKontrol : MonoBehaviour
{
    [SerializeField]
    Sprite[] muzikIkonlar;

    [SerializeField]
    Button muzikButon;

    void Start()
    {
        if (KullaniciTercihleri.Kayitvarmi() == false)
        {
            KullaniciTercihleri.OrtaDegerAta(1);
        }

        if (KullaniciTercihleri.MuzikAcikKayitvarmi() == false)
        {
            KullaniciTercihleri.MuzikAcikDegerAta(1);
        }

        MuzikAyarlariniDenetle();
    }

    void Update()
    {
        
    }

    public void OyunuBaslat()
    {
        SceneManager.LoadScene("Oyun");
    }

    public void EnYuksekPuan()
    {
        SceneManager.LoadScene("Puan");
    }

    public void Ayarlar()
    {
        SceneManager.LoadScene("Ayarlar");
    }

    public void Muzik()
    {
        if (KullaniciTercihleri.MuzikAcikDegerOku() == 1)
        {
            KullaniciTercihleri.MuzikAcikDegerAta(0);
            MuzikKontrol.instance.MuzikCal(false);
            muzikButon.image.sprite = muzikIkonlar[0];
        }
        else
        {
            KullaniciTercihleri.MuzikAcikDegerAta(1);
            MuzikKontrol.instance.MuzikCal(true);
            muzikButon.image.sprite = muzikIkonlar[1];
        }
    }

    void MuzikAyarlariniDenetle()
    {
        if (KullaniciTercihleri.MuzikAcikDegerOku() == 1)
        {
            muzikButon.image.sprite = muzikIkonlar[1];
            MuzikKontrol.instance.MuzikCal(true);
        }
        else
        {
            muzikButon.image.sprite = muzikIkonlar[0];
            MuzikKontrol.instance.MuzikCal(false);
        }
    }


}
