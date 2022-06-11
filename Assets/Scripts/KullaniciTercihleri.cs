using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class KullaniciTercihleri
{                                              // playerprefs kullanýldý


    public static string kolay = "kolay";
    public static string orta = "orta";
    public static string zor = "zor";

    public static string kolayPuan = "kolayPuan";
    public static string ortaPuan = "ortaPuan";
    public static string zorPuan = "zorPuan";

    public static string kolayAltin = "kolayAltin";
    public static string ortaAltin = "ortaAltin";
    public static string zorAltin = "zorAltin";

    public static string muzikAcik = "muzikAcik";


    public static void KolayDegerAta(int kolay)
    {
        PlayerPrefs.SetInt(KullaniciTercihleri.kolay, kolay);
    }
        public static int KolayDegerOku()
        {
            return PlayerPrefs.GetInt(KullaniciTercihleri.kolay);
        }


    public static void OrtaDegerAta(int orta)
    {
        PlayerPrefs.SetInt(KullaniciTercihleri.orta, orta);
    }
        public static int OrtaDegerOku()
        {
            return PlayerPrefs.GetInt(KullaniciTercihleri.orta);
        }


    public static void ZorDegerAta(int zor)
    {
        PlayerPrefs.SetInt(KullaniciTercihleri.zor, zor);
    }
        public static int ZorDegerOku()
        {
            return PlayerPrefs.GetInt(KullaniciTercihleri.zor);
        }




    public static void KolayPuanDegerAta(int kolayPuan)
    {
        PlayerPrefs.SetInt(KullaniciTercihleri.kolayPuan, kolayPuan);
    }
    public static int KolayPuanDegerOku()
    {
        return PlayerPrefs.GetInt(KullaniciTercihleri.kolayPuan);
    }


    public static void OrtaPuanDegerAta(int ortaPuan)
    {
        PlayerPrefs.SetInt(KullaniciTercihleri.ortaPuan, ortaPuan);
    }
    public static int OrtaPuanDegerOku()
    {
        return PlayerPrefs.GetInt(KullaniciTercihleri.ortaPuan);
    }


    public static void ZorPuanDegerAta(int zorPuan)
    {
        PlayerPrefs.SetInt(KullaniciTercihleri.zorPuan, zorPuan);
    }
    public static int ZorPuanDegerOku()
    {
        return PlayerPrefs.GetInt(KullaniciTercihleri.zorPuan);
    }




    public static void KolayAltinDegerAta(int kolayAltin)
    {
        PlayerPrefs.SetInt(KullaniciTercihleri.kolayAltin, kolayAltin);
    }
    public static int KolayAltinDegerOku()
    {
        return PlayerPrefs.GetInt(KullaniciTercihleri.kolayAltin);
    }


    public static void OrtaAltinDegerAta(int ortaAltin)
    {
        PlayerPrefs.SetInt(KullaniciTercihleri.ortaAltin, ortaAltin);
    }
    public static int OrtaAltinDegerOku()
    {
        return PlayerPrefs.GetInt(KullaniciTercihleri.ortaAltin);
    }


    public static void ZorAltinDegerAta(int zorAltin)
    {
        PlayerPrefs.SetInt(KullaniciTercihleri.zorAltin, zorAltin);
    }
    public static int ZorAltinDegerOku()
    {
        return PlayerPrefs.GetInt(KullaniciTercihleri.zorAltin);
    }





    public static void MuzikAcikDegerAta(int muzikAcik)
    {
        PlayerPrefs.SetInt(KullaniciTercihleri.muzikAcik, muzikAcik);
    }
    public static int MuzikAcikDegerOku()
    {
        return PlayerPrefs.GetInt(KullaniciTercihleri.muzikAcik);
    }






    public static bool Kayitvarmi()
    {
        if (PlayerPrefs.HasKey(KullaniciTercihleri.kolay) || PlayerPrefs.HasKey(KullaniciTercihleri.orta) || PlayerPrefs.HasKey(KullaniciTercihleri.zor))
        {
            return true;
        }else
        {
            return false;
        }

    }



    public static bool MuzikAcikKayitvarmi()
    {
        if (PlayerPrefs.HasKey(KullaniciTercihleri.muzikAcik))
        {
            return true;
        }
        else
        {
            return false;
        }

    }


}
