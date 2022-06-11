using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformPool : MonoBehaviour
{
    //sahnedeki objeleri s�rekli yok edip yeniden var etmektense onlar�n yerini de�i�tirme i�lemine object pooling yani nesne havuzu diyoruz


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
        if (platforms[platforms.Count -1].transform.position.y < Camera.main.transform.position.y + EkranHesaplayici.instance.Yukseklik)    //ekrandaki platformlar kamera a��s�ndan ��kmadan onlar� yukar� ta��mam�z gerekiyor bunun i�in listede olu�an son platformun pzosiyonunun camera pozisyonuyla kar��la�t�r�p kameran�n a��s�ndan ��kmadan g�r�nmeyen platformlar�n yukar� ta��nmas� sa�lanack
        {
            PlatformYerlestir();
        }
    }
    void PlatformUret()
    {
        platformPozisyon = new Vector2(0, 0);  // �retilen platformun pozisyonu 0,0 noktas� 
        playerPozisyon = new Vector2(0, 0.5f);  //player oyun ba�lay�nca platformun �zerinde olsun diye

        GameObject player = Instantiate(playerPrefab, playerPozisyon, Quaternion.identity);  //player yarat�ld�
        GameObject ilkPlatform = Instantiate(platformPrefab, platformPozisyon, Quaternion.identity);  //ilk platform yarat�ld�
        player.transform.parent = ilkPlatform.transform;  //ilk platform ile karakter aras�nda parent child ili�kisi kurduk , �uan oyunda ilk platform sabit oldu�u i�in sorun de�il ama e�er ilk platform da hareketli olsayd� karakter bazen platformun �zerinde �retilmiyordu
        platforms.Add(ilkPlatform);     //ilk platform listeye eklend�
        SonrakiPlatformPozisyon();      //sonraki platform pozisyonu belirlend�
        ilkPlatform.GetComponent<Platform>().Hareket = true;       //ilk platform sabit


        for (int i = 0; i < 8; i++)        //8 tane �ret ��nk� ilk platform + 1 tane de �l�mc�l platform var toplam 10
        {
            GameObject platform = Instantiate(platformPrefab, platformPozisyon, Quaternion.identity);  //platformu �reten kod birinci parametre prefab�m�z ikinci parametre pozisyonu
            platforms.Add(platform);  //�ertilen platformu list e ekle
            platform.GetComponent<Platform>().Hareket = true;  //platfom scriptindeki hareket metodunu �a��r�p true yapt�k
            if(i % 2 == 0)
            {
                platform.GetComponent<Altin>().AltinAc();
            }
            SonrakiPlatformPozisyon();      // bundan sonra olu�acak olan platformun pozisyonunu beklirledik   
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
            temp = platforms[i + 5];    //ge�ici olarak listenin i+5  inci eleman�n� temp objesinin i�ine al�yoruz ��nk� ilk 5 eleman�n yerini de�i�tirince i+5 te bulunan platform en baa gelmeli onlara dokunmuyoruz
            platforms[i + 5] = platforms[i];   //en baitaki platformu 5 birim �teliyoruz
            platforms[i] = temp;     //tempe ald���m�z objeyi en ba�a yerle�tirdik
            platforms[i + 5].transform.position = platformPozisyon;  //i + 5 teki objenin pozisyonunu de�i�tiriyoruz
            if (platforms[i + 5].gameObject.tag == "Platform")
            {
                platforms[i + 5].GetComponent<Altin>().AltinKapat();
                float rastgeleAltin = Random.Range(0.0f, 1.0f);
                if (rastgeleAltin > 0.5f)
                {
                    platforms[i + 5].GetComponent<Altin>().AltinAc();
                }
            }
            SonrakiPlatformPozisyon();      //her yerle�tirme i�leminden sonra konumu tekrar hesaplatmam�z laz�m
        }
    }

    void SonrakiPlatformPozisyon()
    {
        platformPozisyon.y += platformArasiMesafe;      //editor �zerinden girilen de�er platformlar aras�ndaki mesafeyi belirledi
        SiraliPozisyon();
        
    }

    void KarmaPozisyon()
    {
        float random = Random.Range(0.0f, 1.0f);        // sa� veya sol olmas�n� random belirledik 
        if (random < 0.5f)
        {
            platformPozisyon.x = EkranHesaplayici.instance.Genislik / 2;    //gelen random say�ya g�re sa�da veya solda var olacak
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
