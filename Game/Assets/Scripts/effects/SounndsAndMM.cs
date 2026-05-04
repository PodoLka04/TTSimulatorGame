using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SounndsAndMM : MonoBehaviour
{
    [SerializeField] private AudioSource BgMMmusic;
    [SerializeField] private AudioSource Tapsound;


    void Start()
    {
        BgMMmusic.Play();
    }

    public void TapSound()
    {
        Tapsound.Play();
    }
    
}
