using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnotherAudio : MonoBehaviour
{
    public AudioSource audio;
    public void playContinueButton(){
        audio.Play();
    } 
}
