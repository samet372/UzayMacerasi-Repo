using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformPool : MonoBehaviour
{
    //sahnedeki objeleri sürekli yok edip yeniden var etmektense onlarýn yerini deðiþtirme iþlemine object pooling yani nesne havuzu diyoruz


    [SerializeField]
    GameObject platformPrefab;

    [SerializeField]
    GameObject olumculPlatformPrefab;

    [SerializeField]
    GameObject playerPrefab;

    List<GameObject> platforms = new List<GameObject>();

    Vector2 platformPozisyon;
    Vector2 playerPozisyon;

    [SerializeField]
    float platformArasiMesafe;

    void Start()
    {
        PlatformUret();
    }
    void Update()
    {
        if (platforms[platforms.Count -1].transform.position.y < Camera.main.transform.position.y + EkranHesaplayici.instance.Yukseklik)    //ekrandaki platformlar kamera açýsýndan çýkmadan onlarý yukarý taþýmamýz gerekiyor bunun için listede oluþan son platformun pzosiyonunun camera pozisyonuyla karþýlaþtýrýp kameranýn açýsýndan çýkmadan görünmeyen platformlarýn yukarý taþýnmasý saðlanack
        {
            PlatformYerlestir();
        }
    }
    void PlatformUret()
    {
        platformPozisyon = new Vector2(0, 0);  // üretilen platformun pozisyonu 0,0 noktasý 
        playerPozisyon = new Vector2(0, 0.5f);  //player oyun baþlayýnca platformun üzerinde olsun diye

        GameObject player = Instantiate(playerPrefab, playerPozisyon, Quaternion.identity);  //player yaratýldý
        GameObject ilkPlatform = Instantiate(platformPrefab, platformPozisyon, Quaternion.identity);  //ilk platform yaratýldý
        player.transform.parent = ilkPlatform.transform;  //ilk platform ile karakter arasýnda parent child iliþkisi kurduk , þuan oyunda ilk platform sabit olduðu için sorun deðil ama eðer ilk platform da hareketli olsaydý karakter bazen platformun üzerinde üretilmiyordu
        platforms.Add(ilkPlatform);     //ilk platform listeye eklendý
        SonrakiPlatformPozisyon();      //sonraki platform pozisyonu belirlendý
        ilkPlatform.GetComponent<Platform>().Hareket = true;       //ilk platform sabit


        for (int i = 0; i < 8; i++)        //8 tane üret çünkü ilk platform + 1 tane de ölümcül platform var toplam 10
        {
            GameObject platform = Instantiate(platformPrefab, platformPozisyon, Quaternion.identity);  //platformu üreten kod birinci parametre prefabýmýz ikinci parametre pozisyonu
            platforms.Add(platform);  //üertilen platformu list e ekle
            platform.GetComponent<Platform>().Hareket = true;  //platfom scriptindeki hareket metodunu çaðýrýp true yaptýk
            if(i % 2 == 0)
            {
                platform.GetComponent<Altin>().AltinAc();
            }
            SonrakiPlatformPozisyon();      // bundan sonra oluþacak olan platformun pozisyonunu beklirledik   
        }
        GameObject olumculPlatform = Instantiate(olumculPlatformPrefab, platformPozisyon, Quaternion.identity);
        olumculPlatform.GetComponent<OlumculPlatform>().Hareket = true;
        platforms.Add(olumculPlatform);
        SonrakiPlatformPozisyon();
    }

    void PlatformYerlestir()
    {
        for (int i = 0; i < 5; i++)  //5 kere donecek
        {
            GameObject temp;
            temp = platforms[i + 5];    //geçici olarak listenin i+5  inci elemanýný temp objesinin içine alýyoruz çünkü ilk 5 elemanýn yerini deðiþtirince i+5 te bulunan platform en baa gelmeli onlara dokunmuyoruz
            platforms[i + 5] = platforms[i];   //en baitaki platformu 5 birim öteliyoruz
            platforms[i] = temp;     //tempe aldýðýmýz objeyi en baþa yerleþtirdik
            platforms[i + 5].transform.position = platformPozisyon;  //i + 5 teki objenin pozisyonunu deðiþtiriyoruz
            if (platforms[i + 5].gameObject.tag == "Platform")
            {
                platforms[i + 5].GetComponent<Altin>().AltinKapat();
                float rastgeleAltin = Random.Range(0.0f, 1.0f);
                if (rastgeleAltin > 0.5f)
                {
                    platforms[i + 5].GetComponent<Altin>().AltinAc();
                }
            }
            SonrakiPlatformPozisyon();      //her yerleþtirme iþleminden sonra konumu tekrar hesaplatmamýz lazým
        }
    }

    void SonrakiPlatformPozisyon()
    {
        platformPozisyon.y += platformArasiMesafe;      //editor üzerinden girilen deðer platformlar arasýndaki mesafeyi belirledi
        SiraliPozisyon();
        
    }

    void KarmaPozisyon()
    {
        float random = Random.Range(0.0f, 1.0f);        // sað veya sol olmasýný random belirledik 
        if (random < 0.5f)
        {
            platformPozisyon.x = EkranHesaplayici.instance.Genislik / 2;    //gelen random sayýya göre saðda veya solda var olacak
        }
        else
        {
            platformPozisyon.x = -EkranHesaplayici.instance.Genislik / 2;
        }
    }

    bool yon = true;
    void SiraliPozisyon()
    {
        if (yon)
        {
            platformPozisyon.x = EkranHesaplayici.instance.Genislik / 2;
            yon = false;
        }
        else
        {
            platformPozisyon.x = -EkranHesaplayici.instance.Genislik / 2;
            yon = true;
        }
    }
}
