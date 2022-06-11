using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Puan : MonoBehaviour
{
    int puan;
    int enYuksekPuan;

    int altin;
    int enYuksekAltin;

    bool puanTopla = true;

    [SerializeField]
    Text puanText;

    [SerializeField]
    Text altinText;

    [SerializeField]
    Text oyunBittiPuanText;

    [SerializeField]
    Text oyunBittiAltinText;

    void Start()
    {
        altinText.text = " X " + altin;
    }

    void Update()
    {
        if (puanTopla)
        {
            puan = (int)Camera.main.transform.position.y;   //float olan kameranýn y pozisyon deðerlerini cast iþlemi ile sadece int olan basamaðý aldýk bunu camera main kodunun baþýndaki (int) kodu bize saðladý
            puanText.text = "Puan: " + puan;
        }
    }
    public void AltinKazan()
    {
        FindObjectOfType<SesKontrol>().AltinSes();
        altin++;
        altinText.text = " X " + altin;
    }

    public void OyunBitti()
    {
        if (KullaniciTercihleri.KolayDegerOku() == 1)
        {
            enYuksekPuan = KullaniciTercihleri.KolayPuanDegerOku();
            enYuksekAltin = KullaniciTercihleri.KolayAltinDegerOku();

            if (puan > enYuksekPuan)
            {
                KullaniciTercihleri.KolayPuanDegerAta(puan);
            }
            if (altin > enYuksekAltin)
            {
                KullaniciTercihleri.KolayAltinDegerAta(altin);
            }
        }

        if (KullaniciTercihleri.OrtaDegerOku() == 1)
        {
            enYuksekPuan = KullaniciTercihleri.OrtaPuanDegerOku();
            enYuksekAltin = KullaniciTercihleri.OrtaAltinDegerOku();

            if (puan > enYuksekPuan)
            {
                KullaniciTercihleri.OrtaPuanDegerAta(puan);
            }
            if (altin > enYuksekAltin)
            {
                KullaniciTercihleri.OrtaAltinDegerAta(altin);
            }
        }

        if (KullaniciTercihleri.ZorDegerOku() == 1)
        {
            enYuksekPuan = KullaniciTercihleri.ZorPuanDegerOku();
            enYuksekAltin = KullaniciTercihleri.ZorAltinDegerOku();

            if (puan > enYuksekPuan)
            {
                KullaniciTercihleri.ZorPuanDegerAta(puan);
            }
            if (altin > enYuksekAltin)
            {
                KullaniciTercihleri.ZorAltinDegerAta(altin);
            }
        }
       
        puanTopla = false;
        oyunBittiPuanText.text = "Puan: " + puan;
        oyunBittiAltinText.text = " X " + altin;
    }
}
