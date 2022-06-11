using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TamEkran : MonoBehaviour
{
 void Start()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();  //sprite �zerinde �al��aca��m�z i�in �a��rd�k
        Vector2 tempScale = transform.localScale;       //sprite �n �zerinde de�i�iklik yapaca��m�z i�in sprite �n referans�n� ald�k,referans�n� ald���m�z tempScale de�eri ile x ve y de ki �arpanlar� kameraya g�re ayarl�ycaz,yani m�dahale edece�imiz scalenin referans�n� ald�k

        float spriteGenislik = spriteRenderer.size.x;       // x ekseninde ka� birim uzunlu�a sahip oldu�unu sorguluyoruz
        float ekranYukseklik = Camera.main.orthographicSize * 2.0f;     //cameran�n uzunlu�u yukar� ve a�a�� olarak ikiye b�l�nd��� i�in �arp� 2 dedik,ekran�n y�ksekli�ini hesaplad�k
        float ekranGenislik = ekranYukseklik / Screen.height * Screen.width;        //kendi kameram�z� referans alarak �al��an cihaza g�re en boy oran� hesaplad�k
        tempScale.x = ekranGenislik / spriteGenislik;       //ald���m�z sprite referans�nda geni�lik de�erlerimizi oranlad�k
        transform.localScale = tempScale;       //objemizin scale de�erini de de�i�tirdi�imiz temp de�i�kenine e�itlememiz laz�m
    }
}
