using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoystickButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [HideInInspector]  //bu atribute değişken public olsa bile inspector da gizlemek için kullanılıyor 
    public bool tusaBasildi;   //tusa basılıp basılmadığını hareket kontrol scriptinden kontrol edicez
    public void OnPointerDown(PointerEventData eventData)  //bu down ve up metodları bizim belirttiğimiz işaretçilerdeki interaktiviteler başlayınca yada son bulunca çağırılıcak yani ekrandaki butonu kullanarak karakterin zıplamasını sağladık
    {
        tusaBasildi = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        tusaBasildi = false;
    }
}
