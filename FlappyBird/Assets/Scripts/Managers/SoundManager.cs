using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [Header("Audio Sources")]
    public AudioSource sfxSource;
    public AudioSource musicSource;

    [Header("Clips")]
    public AudioClip backgroundMusic;
    public AudioClip jump;
    public AudioClip score;
    public AudioClip hit;
    public AudioClip gameOver;
    //usage: AudioManager.instance.PlaySFX(AudioManager.instance.gameOver);


    //multiple sounds for different sound in death or any event
    [Header("Game Over SFX")]
    public AudioClip[] gameOverClips;
    //usage: AudioManager.instance.PlayRandomGameOver();

    [Header("Jump SFX")]
    public AudioClip[] jumpClips;
    //usage: AudioManager.instance.PlayRandomJump();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }


    //play random random Game Over SFX
    public void PlayRandomGameOver()
    {
        if (gameOverClips.Length == 0) return;

        int index = Random.Range(0, gameOverClips.Length);
        sfxSource.PlayOneShot(gameOverClips[index]);
    }

    //play specific requested SFX
    public void PlaySFX(AudioClip clip, float volume = 1f)
    {
        sfxSource.PlayOneShot(clip, volume);
    }

    //play background music
    public void PlayBackgroundMusic(AudioClip clip)
    {
        if (musicSource.clip == clip && musicSource.isPlaying)
            return;

        musicSource.Stop();
        musicSource.clip = clip;
        musicSource.loop = true;
        musicSource.pitch = 1f;
        musicSource.Play();
    }


    public void SetPitch(float pitch)
    {
        sfxSource.pitch = pitch;
        musicSource.pitch = pitch;
    }

    public void StopMusic()
    {
        musicSource.Stop();
    }

    public void ResetAudio()
    {
        sfxSource.pitch = 1f;
        musicSource.pitch = 1f;
    }
    public IEnumerator JamAndStopMusic(float duration, float pitch)
    {
        float startPitch = pitch;
        float time = 0f;

        while (time < duration)
        {
            time += Time.unscaledDeltaTime;
            musicSource.pitch = Mathf.Lerp(startPitch, 0.3f, time / duration);
            yield return null;
        }

        musicSource.Stop();
        musicSource.pitch = 1f;
    }

}
