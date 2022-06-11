using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OyunKontrol : MonoBehaviour
{
    public GameObject oyunBittiPanel;
    public GameObject joystick;
    public GameObject ziplamaButonu;
    public GameObject tabela;
    public GameObject menuButonu;
    public GameObject slider;

    void Start()
    {
        oyunBittiPanel.SetActive(false);
        U�Ac();
    }

    public void OyunuBitir()
    {
        FindObjectOfType<SesKontrol>().OyunBittiSes();
        oyunBittiPanel.SetActive(true);
        FindObjectOfType<Puan>().OyunBitti();
        FindObjectOfType<OyuncuHareket>().OyunBitti();
        FindObjectOfType<KameraHareket>().OyunBitti();
        U�Kapat();
    }

    public void AnaMenuyeDon()
    {
        SceneManager.LoadScene("Menu");
    }

    public void TekrarOyna()
    {
        SceneManager.LoadScene("Oyun");
    }

    void U�Ac()
    {
        joystick.SetActive(true);
        ziplamaButonu.SetActive(true);
        tabela.SetActive(true);
        menuButonu.SetActive(true);
        slider.SetActive(true);
    }

    void U�Kapat()
    {
        joystick.SetActive(false);
        ziplamaButonu.SetActive(false);
        tabela.SetActive(false);
        menuButonu.SetActive(false);
        slider.SetActive(false);
    }
}
