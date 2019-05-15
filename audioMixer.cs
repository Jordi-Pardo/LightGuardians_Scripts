using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;


public class audioMixer : MonoBehaviour {
    public AudioMixer masterMixer;
    public AudioMixerGroup bkgGroup;
    public AudioMixerGroup EffectsGroup;
    public Slider volumeBkg;
    public Slider volumeEffects;
    public static float resultado;
    public static float resultadoSetBkgLvl;



    public void Update()
    {
        resultado = resultadoSetBkgLvl;
    }

    public void SetBkgLvl(float bkgLvl)
    {
        masterMixer.SetFloat("MusicVolume", bkgLvl);
        resultadoSetBkgLvl = bkgLvl;
        Debug.Log(resultado);       

    }
    public void SetEffectsLvl(float  EffectsLvl)
    {
        masterMixer.SetFloat("EffectsVolume", EffectsLvl);
        


    }



}
