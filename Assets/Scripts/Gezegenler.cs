using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gezegenler : MonoBehaviour
{
    List<GameObject> gezegenler = new List<GameObject>();
    List<GameObject> kullan�lanGezegenler = new List<GameObject>();


    void Awake()  //kaynaklar en ba�ta y�klensin diye awake kulland�k
    {
        Object[] sprites = Resources.LoadAll("Gezegenler"); //resources klasorundeki gezegenler dosyas�nda birden fazla eleman var o y�zden obje array i kulland�k
        
        for (int i = 1; i < 17; i++)
        {
            GameObject gezegen = new GameObject(); //bo� bir oyun objesi olu�turduk
            SpriteRenderer sRenderer = gezegen.AddComponent<SpriteRenderer>();  // hem spriterendereri tan�mlad�k hemde bile�ene ekledik
            sRenderer.sprite = (Sprite)sprites[i];  //renderer a sprite lar� g�nderdik unity bunlar�n sprite oldu�unu bilmedi�i i�in parantez i�inde sprite yazarak cast i�lemi yaptik ve biz soyledik
            Color spriteColor = sRenderer.color;    //sprite lar�n daha s�n�k olmas� i�in .a dedi�imiz alfa de�erini azaltt�k bu de�erler 0 ile 1 f aras�nda olur
            spriteColor.a = 0.5f;
            sRenderer.color = spriteColor;
            gezegen.name = sprites[i].name;  //gezegen ismi olarak spritelar�n isimlerini koyduk
            sRenderer.sortingLayerName = ("Gezegenler");
            Vector2 pozisyon = gezegen.transform.position;  //gezegenlerin pozisyonunu ayarlamak i�in kameran�n g�rmedi�i bir yere g�t�rd�k
            pozisyon.x = -10;
            gezegen.transform.position = pozisyon;
            gezegenler.Add(gezegen);  //gezegenler ad�ndaki listeye olu�turulan elemanlar� ekledik
        }
    }

   public void GezegenYerlestir(float refY)
    {
        float yukseklik = EkranHesaplayici.instance.Yukseklik;  //yerle�tirilecveck gezegenlerin konumlar�n� belirledik
        float genislik = EkranHesaplayici.instance.Genislik;

        //1.b�lge
        float xDeger1 = Random.Range(0.0f, genislik);
        float yDeger1 = Random.Range(refY, refY + yukseklik);
        GameObject gezegen1 = RandomGezegen();
        gezegen1.transform.position = new Vector2(xDeger1, yDeger1);


        //2.b�lge
        float xDeger2 = Random.Range(-genislik, 0.0f);
        float yDeger2 = Random.Range(refY, refY + yukseklik);
        GameObject gezegen2 = RandomGezegen();
        gezegen2.transform.position = new Vector2(xDeger2, yDeger2);


        //3.b�lge
        float xDeger3 = Random.Range(-genislik, 0.0f);
        float yDeger3 = Random.Range(refY - yukseklik, refY);
        GameObject gezegen3 = RandomGezegen();
        gezegen3.transform.position = new Vector2(xDeger3, yDeger3);


        //4.b�lge
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
            if (gezegenler.Count == 1)  //random gezegen �retilirken listede sadece s�f�r�nc� eleman yani 1 eleman kald�ysa kod hata verecek bunun i�in eger listede 1 eleman kald�ysa random de�erini 0 yap 
            {
                random = 0;
            }
            else
            {
                random = Random.Range(0, gezegenler.Count - 1);
            }
            GameObject gezegen = gezegenler[random];  //gezegen gezegenler listesinin randomuncu eleman�n�
            gezegenler.Remove(gezegen); // gezegenler listesinden ��kar
            kullan�lanGezegenler.Add(gezegen);// kullan�lan gezegenler listesine ekle
            return gezegen;//�a��r�ld��� metoda geri d�ns�n
        }
        else
        {
            for (int i = 0; i < 8; i++)  //gezegenler listesinde eleman yok ise kullan�langezegenler listesinin ilk 8 eleman�n� gezegenler listesine ekle
            {
                gezegenler.Add(kullan�lanGezegenler[i]);
            }
            kullan�lanGezegenler.RemoveRange(0, 8); //eklenen 8 eleman� kullan�lan gezegenler lsitesinden sil
            int random = Random.Range(0, 8);
            GameObject gezegen = gezegenler[random]; //random eleman� 
            gezegenler.Remove(gezegen); //gezegenler list ten sil
            kullan�lanGezegenler.Add(gezegen);  //ekle
            return gezegen;
        }
    }



}
 