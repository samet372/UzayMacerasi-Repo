using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Altin : MonoBehaviour
{
    [SerializeField]
    GameObject altin;
    public void AltinAc()
    {
        altin.SetActive(true);
    }

    public void AltinKapat()
    {
        altin.SetActive(false);
    }
}
