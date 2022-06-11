using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoystickButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [HideInInspector]  //bu atribute de�i�ken public olsa bile inspector da gizlemek i�in kullan�l�yor 
    public bool tusaBasildi;   //tusa bas�l�p bas�lmad���n� hareket kontrol scriptinden kontrol edicez
    public void OnPointerDown(PointerEventData eventData)  //bu down ve up metodlar� bizim belirtti�imiz i�aret�ilerdeki interaktiviteler ba�lay�nca yada son bulunca �a��r�l�cak yani ekrandaki butonu kullanarak karakterin z�plamas�n� sa�lad�k
    {
        tusaBasildi = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        tusaBasildi = false;
    }
}
