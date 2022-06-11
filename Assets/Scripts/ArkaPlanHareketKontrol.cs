using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArkaPlanHareketKontrol : MonoBehaviour
{
    float arkaPlanKonum;        // scriptin ekli oldu�u oyun objesinin y de�erini bir de�i�ken i�ine ald�k 
    float mesafe = 10.24f;  // iki oyun objesinin orta noktalar�ndaki mesafeyi kaydettik   
    void Start()
    {
        arkaPlanKonum = transform.position.y; // arkaPlanKonum de�i�keninin objenin y �zerindeki konumu oldu�unu s�yledik ,float arkaPlanKonum;
        FindObjectOfType<Gezegenler>().GezegenYerlestir(arkaPlanKonum);
    }
    void Update()
    {
        if (arkaPlanKonum + mesafe < Camera.main.transform.position.y) //kameran�n orta noktas� objemizin konumunu mesafe de�eri kadar ge�ince yani g�r�� alan�n�n d���na ��k�nca metodu �a��r
        {
            ArkaPlanYerle�tir();
        }
    }
    void ArkaPlanYerle�tir()
    {
        arkaPlanKonum += (mesafe * 2);      //arkaplan�n gitmesi gereken konumu hesaplad�
        FindObjectOfType<Gezegenler>().GezegenYerlestir(arkaPlanKonum); //ekrandaki gezegenler de arkaplan ile birlikte yukar� ��ks�n diye yazd�k
        Vector2 yeniPozisyon = new Vector2(0, arkaPlanKonum);   //objenin ekli oldu�u oyun objesine gitmesi gereken y de�erinin arkaplankonum oldu�unu s�yledik
        transform.position = yeniPozisyon;      //arkaplankonum de�i�keninin pozisyonunu hesaplanan yeni pozisyona e�itledik
    }
}
