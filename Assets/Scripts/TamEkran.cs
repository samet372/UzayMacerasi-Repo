using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TamEkran : MonoBehaviour
{
 void Start()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();  //sprite üzerinde çalýþacaðýmýz için çaðýrdýk
        Vector2 tempScale = transform.localScale;       //sprite ýn üzerinde deðiþiklik yapacaðýmýz için sprite ýn referansýný aldýk,referansýný aldýðýmýz tempScale deðeri ile x ve y de ki çarpanlarý kameraya göre ayarlýycaz,yani müdahale edeceðimiz scalenin referansýný aldýk

        float spriteGenislik = spriteRenderer.size.x;       // x ekseninde kaç birim uzunluða sahip olduðunu sorguluyoruz
        float ekranYukseklik = Camera.main.orthographicSize * 2.0f;     //cameranýn uzunluðu yukarý ve aþaðý olarak ikiye bölündüðü için çarpý 2 dedik,ekranýn yüksekliðini hesapladýk
        float ekranGenislik = ekranYukseklik / Screen.height * Screen.width;        //kendi kameramýzý referans alarak çalýþan cihaza göre en boy oraný hesapladýk
        tempScale.x = ekranGenislik / spriteGenislik;       //aldýðýmýz sprite referansýnda geniþlik deðerlerimizi oranladýk
        transform.localScale = tempScale;       //objemizin scale deðerini de deðiþtirdiðimiz temp deðiþkenine eþitlememiz lazým
    }
}
