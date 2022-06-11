using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AyarlarKontrol : MonoBehaviour
{
    public Button kolayButon, ortaButon, zorButon;

    void Start()
    {
        if (KullaniciTercihleri.KolayDegerOku() == 1)
        {
            kolayButon.interactable = false;
            ortaButon.interactable = true;
            zorButon.interactable = true;
        }
        if (KullaniciTercihleri.OrtaDegerOku() == 1)
        {
            kolayButon.interactable = true;
            ortaButon.interactable = false;
            zorButon.interactable = true;
        }
        if (KullaniciTercihleri.ZorDegerOku() == 1)
        {
            kolayButon.interactable = true;
            ortaButon.interactable = true;
            zorButon.interactable = false;
        }
    }
    public void SecenekSecildi(string seviye)
    {
        switch (seviye)
        {
            case "kolay":
                KullaniciTercihleri.KolayDegerAta(1);
                KullaniciTercihleri.OrtaDegerAta(0);
                KullaniciTercihleri.ZorDegerAta(0);
                kolayButon.interactable = false;
                ortaButon.interactable = true;
                zorButon.interactable = true;
                break;
            case "orta":
                KullaniciTercihleri.KolayDegerAta(0);
                KullaniciTercihleri.OrtaDegerAta(1);
                KullaniciTercihleri.ZorDegerAta(0);
                kolayButon.interactable = true;
                ortaButon.interactable = false;
                zorButon.interactable = true;
                break;
            case "zor":
                KullaniciTercihleri.KolayDegerAta(0);
                KullaniciTercihleri.OrtaDegerAta(0);
                KullaniciTercihleri.ZorDegerAta(1);
                kolayButon.interactable = true;
                ortaButon.interactable = true;
                zorButon.interactable = false;
                break;
            default:
                break;
        }
    }

    public void AnaMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
