using UnityEngine;

public class MusicStarter : MonoBehaviour
{
    public AudioClip backgroundMusic;

    void Start()
    {
        AudioManager.instance.ResetAudio();
        AudioManager.instance.PlayBackgroundMusic(backgroundMusic);
    }
}
