using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour
{
    [SerializeField] private AudioSource S1;
    [SerializeField] private AudioSource S2;
    [SerializeField] private AudioSource S3;
    [SerializeField] private AudioSource S4;
    [SerializeField] private AudioSource S5;
    [SerializeField] private AudioSource S6;
    [SerializeField] private AudioSource S7;
    [SerializeField] private AudioSource S8;


    public void StartS1() 
    {
        S1.Play();
    }

    public void StartS2()
    {
        S2.Play();
    }
    public void StartS3()
    {
        S3.Play();
    }
    public void StartS4()
    {
        S4.Play();
    }
    public void StartS5()
    {
        S5.Play();
    }
    public void StartS6()
    {
        S6.Play();
    }
    public void StartS7()
    {
        S7.Play();
    }
    public void StartS8()
    {
        S8.Play();
    }
}
