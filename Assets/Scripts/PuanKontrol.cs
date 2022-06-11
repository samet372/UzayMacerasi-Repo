using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PuanKontrol : MonoBehaviour
{

    public Text kolayPuan, kolayAltin, ortaPuan, ortaAltin, zorPuan, zorAltin;
    void Start()
    {
        kolayPuan.text = "Puan: " + KullaniciTercihleri.KolayPuanDegerOku();
        kolayAltin.text = " X " + KullaniciTercihleri.KolayAltinDegerOku();
        ortaPuan.text = "Puan: " + KullaniciTercihleri.OrtaPuanDegerOku();
        ortaAltin.text = " X " + KullaniciTercihleri.OrtaAltinDegerOku();
        zorPuan.text = "Puan: " + KullaniciTercihleri.ZorPuanDegerOku();
        zorAltin.text = " X " + KullaniciTercihleri.ZorAltinDegerOku();

    }
    public void AnaMenu()
    {
        SceneManager.LoadScene("Menu");
    }



}
