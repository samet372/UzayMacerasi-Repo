using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gezegenler : MonoBehaviour
{
    List<GameObject> gezegenler = new List<GameObject>();
    List<GameObject> kullanýlanGezegenler = new List<GameObject>();


    void Awake()  //kaynaklar en baþta yüklensin diye awake kullandýk
    {
        Object[] sprites = Resources.LoadAll("Gezegenler"); //resources klasorundeki gezegenler dosyasýnda birden fazla eleman var o yüzden obje array i kullandýk
        
        for (int i = 1; i < 17; i++)
        {
            GameObject gezegen = new GameObject(); //boþ bir oyun objesi oluþturduk
            SpriteRenderer sRenderer = gezegen.AddComponent<SpriteRenderer>();  // hem spriterendereri tanýmladýk hemde bileþene ekledik
            sRenderer.sprite = (Sprite)sprites[i];  //renderer a sprite larý gönderdik unity bunlarýn sprite olduðunu bilmediði için parantez içinde sprite yazarak cast iþlemi yaptik ve biz soyledik
            Color spriteColor = sRenderer.color;    //sprite larýn daha sönük olmasý için .a dediðimiz alfa deðerini azalttýk bu deðerler 0 ile 1 f arasýnda olur
            spriteColor.a = 0.5f;
            sRenderer.color = spriteColor;
            gezegen.name = sprites[i].name;  //gezegen ismi olarak spritelarýn isimlerini koyduk
            sRenderer.sortingLayerName = ("Gezegenler");
            Vector2 pozisyon = gezegen.transform.position;  //gezegenlerin pozisyonunu ayarlamak için kameranýn görmediði bir yere götürdük
            pozisyon.x = -10;
            gezegen.transform.position = pozisyon;
            gezegenler.Add(gezegen);  //gezegenler adýndaki listeye oluþturulan elemanlarý ekledik
        }
    }

   public void GezegenYerlestir(float refY)
    {
        float yukseklik = EkranHesaplayici.instance.Yukseklik;  //yerleþtirilecveck gezegenlerin konumlarýný belirledik
        float genislik = EkranHesaplayici.instance.Genislik;

        //1.bölge
        float xDeger1 = Random.Range(0.0f, genislik);
        float yDeger1 = Random.Range(refY, refY + yukseklik);
        GameObject gezegen1 = RandomGezegen();
        gezegen1.transform.position = new Vector2(xDeger1, yDeger1);


        //2.bölge
        float xDeger2 = Random.Range(-genislik, 0.0f);
        float yDeger2 = Random.Range(refY, refY + yukseklik);
        GameObject gezegen2 = RandomGezegen();
        gezegen2.transform.position = new Vector2(xDeger2, yDeger2);


        //3.bölge
        float xDeger3 = Random.Range(-genislik, 0.0f);
        float yDeger3 = Random.Range(refY - yukseklik, refY);
        GameObject gezegen3 = RandomGezegen();
        gezegen3.transform.position = new Vector2(xDeger3, yDeger3);


        //4.bölge
        float xDeger4 = Random.Range(0.0f, genislik);
        float yDeger4 = Random.Range(refY - yukseklik, refY);
        GameObject gezegen4 = RandomGezegen();
        gezegen4.transform.position = new Vector2(xDeger4, yDeger4);
    }

    GameObject RandomGezegen()
    {
        if (gezegenler.Count > 0)
        {
            int random;
            if (gezegenler.Count == 1)  //random gezegen üretilirken listede sadece sýfýrýncý eleman yani 1 eleman kaldýysa kod hata verecek bunun için eger listede 1 eleman kaldýysa random deðerini 0 yap 
            {
                random = 0;
            }
            else
            {
                random = Random.Range(0, gezegenler.Count - 1);
            }
            GameObject gezegen = gezegenler[random];  //gezegen gezegenler listesinin randomuncu elemanýný
            gezegenler.Remove(gezegen); // gezegenler listesinden çýkar
            kullanýlanGezegenler.Add(gezegen);// kullanýlan gezegenler listesine ekle
            return gezegen;//çaðýrýldýðý metoda geri dönsün
        }
        else
        {
            for (int i = 0; i < 8; i++)  //gezegenler listesinde eleman yok ise kullanýlangezegenler listesinin ilk 8 elemanýný gezegenler listesine ekle
            {
                gezegenler.Add(kullanýlanGezegenler[i]);
            }
            kullanýlanGezegenler.RemoveRange(0, 8); //eklenen 8 elemaný kullanýlan gezegenler lsitesinden sil
            int random = Random.Range(0, 8);
            GameObject gezegen = gezegenler[random]; //random elemaný 
            gezegenler.Remove(gezegen); //gezegenler list ten sil
            kullanýlanGezegenler.Add(gezegen);  //ekle
            return gezegen;
        }
    }



}
 