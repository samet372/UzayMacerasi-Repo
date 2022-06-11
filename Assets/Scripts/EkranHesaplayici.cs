using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EkranHesaplayici : MonoBehaviour
{
                                                //bu instance bize ekranýn yuksekliðini ve genisliðini hesaplayacak

    float yukseklik;               
    float genislik;


    public float Yukseklik      //bulduðumuz deðerlere dýþarýdan eriþeblimek için property yazdýk
    {
        get
        {
            return yukseklik; //bulduðumuz float deðeri gönderdik
        }
    }
    public float Genislik       //bulduðumuz deðerlere dýþarýdan eriþeblimek için property yazdýk
    {
        get
        {
            return genislik;   //bulduðumuz float deðeri gönderdik
        }
    }




    //bir objeyi singleton yapmamýz için gerekli olanlar bunlar......................

    public static EkranHesaplayici instance;    //ayný türde instance isimli statik bir obje oluþturuyoruz

    void Awake()                    
    {
        if (instance == null)       //instance yani örneðe deðer atanmamýþsa 
        {
            instance = this;        //objenin kendisi bizim instance ýmýz yani örneðimiz
        }

        else if (instance != this)  //instance a deðer atanmýþsa ve kendisine eþit deðilse
        {
            Destroy(gameObject);    //yok et.............................................
        }

        yukseklik = Camera.main.orthographicSize;       //yüksekliði hesapladýk kameranýn size ýna göre
        genislik = yukseklik * Camera.main.aspect;      //geniþliði ise aspect metodu ile kameranýn yüksekliðiyle oranlayarak bulduk

    }   
}
