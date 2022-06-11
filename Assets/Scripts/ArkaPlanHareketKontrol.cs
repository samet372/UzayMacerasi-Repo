using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArkaPlanHareketKontrol : MonoBehaviour
{
    float arkaPlanKonum;        // scriptin ekli olduðu oyun objesinin y deðerini bir deðiþken içine aldýk 
    float mesafe = 10.24f;  // iki oyun objesinin orta noktalarýndaki mesafeyi kaydettik   
    void Start()
    {
        arkaPlanKonum = transform.position.y; // arkaPlanKonum deðiþkeninin objenin y üzerindeki konumu olduðunu söyledik ,float arkaPlanKonum;
        FindObjectOfType<Gezegenler>().GezegenYerlestir(arkaPlanKonum);
    }
    void Update()
    {
        if (arkaPlanKonum + mesafe < Camera.main.transform.position.y) //kameranýn orta noktasý objemizin konumunu mesafe deðeri kadar geçince yani görüþ alanýnýn dýþýna çýkýnca metodu çaðýr
        {
            ArkaPlanYerleþtir();
        }
    }
    void ArkaPlanYerleþtir()
    {
        arkaPlanKonum += (mesafe * 2);      //arkaplanýn gitmesi gereken konumu hesapladý
        FindObjectOfType<Gezegenler>().GezegenYerlestir(arkaPlanKonum); //ekrandaki gezegenler de arkaplan ile birlikte yukarý çýksýn diye yazdýk
        Vector2 yeniPozisyon = new Vector2(0, arkaPlanKonum);   //objenin ekli olduðu oyun objesine gitmesi gereken y deðerinin arkaplankonum olduðunu söyledik
        transform.position = yeniPozisyon;      //arkaplankonum deðiþkeninin pozisyonunu hesaplanan yeni pozisyona eþitledik
    }
}
