﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharSoundController : MonoBehaviour
{

    public AudioClip jump;

    private AudioSource audioPlayer;

    private void Start()
    {
        audioPlayer = GetComponent<AudioSource>();
    }

    public void PlayJump()
    {
        audioPlayer.PlayOneShot(jump);
    }

    public AudioClip scoreHighlight;

    public void PlayScoreHighlight()
    {
        audioPlayer.PlayOneShot(scoreHighlight);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}