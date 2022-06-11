using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EkrandaTut : MonoBehaviour
{



    void Update()
    {
        if (transform.position.x < -EkranHesaplayici.instance.Genislik)  //karakter ekranýn solundan dýþarý çýkýyor mu
        {
            Vector2 temp = transform.position;  //anlýk konumu bu deðiþken tutacak
            temp.x = -EkranHesaplayici.instance.Genislik;  //konumuzu ekran hesaplayýcýnýn sol kenardaki deðeriyle eþitledik ki daha fazla ileri gidemesin
            transform.position = temp;  //deðiþtirdiðimiz deðeri karakterin konumuna atadýk
        }

        if (transform.position.x > EkranHesaplayici.instance.Genislik)  //karakter ekranýn saðýndan dýþarý çýkýyor mu
        {
            Vector2 temp = transform.position;
            temp.x = EkranHesaplayici.instance.Genislik;
            transform.position = temp;
        }
    }
}
