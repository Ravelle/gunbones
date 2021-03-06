using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VaudinGames.Audio;

public class AnimationEventHandler : MonoBehaviour
{
    private RandomAudioPlayer randomAudioPlayer;
    private void Awake()
    {
        randomAudioPlayer = GetComponentInParent<RandomAudioPlayer>();
    }
    public void PlayAudio(string library)
    {
        randomAudioPlayer.Play(library);
    }
}
