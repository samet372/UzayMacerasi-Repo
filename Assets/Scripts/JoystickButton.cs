using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoystickButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [HideInInspector]  //bu atribute deðiþken public olsa bile inspector da gizlemek için kullanýlýyor 
    public bool tusaBasildi;   //tusa basýlýp basýlmadýðýný hareket kontrol scriptinden kontrol edicez
    public void OnPointerDown(PointerEventData eventData)  //bu down ve up metodlarý bizim belirttiðimiz iþaretçilerdeki interaktiviteler baþlayýnca yada son bulunca çaðýrýlýcak yani ekrandaki butonu kullanarak karakterin zýplamasýný saðladýk
    {
        tusaBasildi = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        tusaBasildi = false;
    }
}
