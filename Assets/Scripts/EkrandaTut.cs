using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EkrandaTut : MonoBehaviour
{



    void Update()
    {
        if (transform.position.x < -EkranHesaplayici.instance.Genislik)  //karakter ekran�n solundan d��ar� ��k�yor mu
        {
            Vector2 temp = transform.position;  //anl�k konumu bu de�i�ken tutacak
            temp.x = -EkranHesaplayici.instance.Genislik;  //konumuzu ekran hesaplay�c�n�n sol kenardaki de�eriyle e�itledik ki daha fazla ileri gidemesin
            transform.position = temp;  //de�i�tirdi�imiz de�eri karakterin konumuna atad�k
        }

        if (transform.position.x > EkranHesaplayici.instance.Genislik)  //karakter ekran�n sa��ndan d��ar� ��k�yor mu
        {
            Vector2 temp = transform.position;
            temp.x = EkranHesaplayici.instance.Genislik;
            transform.position = temp;
        }
    }
}
