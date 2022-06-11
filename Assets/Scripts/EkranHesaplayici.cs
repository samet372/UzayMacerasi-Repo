using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EkranHesaplayici : MonoBehaviour
{
                                                //bu instance bize ekran�n yuksekli�ini ve genisli�ini hesaplayacak

    float yukseklik;               
    float genislik;


    public float Yukseklik      //buldu�umuz de�erlere d��ar�dan eri�eblimek i�in property yazd�k
    {
        get
        {
            return yukseklik; //buldu�umuz float de�eri g�nderdik
        }
    }
    public float Genislik       //buldu�umuz de�erlere d��ar�dan eri�eblimek i�in property yazd�k
    {
        get
        {
            return genislik;   //buldu�umuz float de�eri g�nderdik
        }
    }




    //bir objeyi singleton yapmam�z i�in gerekli olanlar bunlar......................

    public static EkranHesaplayici instance;    //ayn� t�rde instance isimli statik bir obje olu�turuyoruz

    void Awake()                    
    {
        if (instance == null)       //instance yani �rne�e de�er atanmam��sa 
        {
            instance = this;        //objenin kendisi bizim instance �m�z yani �rne�imiz
        }

        else if (instance != this)  //instance a de�er atanm��sa ve kendisine e�it de�ilse
        {
            Destroy(gameObject);    //yok et.............................................
        }

        yukseklik = Camera.main.orthographicSize;       //y�ksekli�i hesaplad�k kameran�n size �na g�re
        genislik = yukseklik * Camera.main.aspect;      //geni�li�i ise aspect metodu ile kameran�n y�ksekli�iyle oranlayarak bulduk

    }   
}
