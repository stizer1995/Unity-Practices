using System.Collections;
using UnityEditor.Rendering.LookDev;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LogicScript : MonoBehaviour
{
    public int playerScore;

    public Text scoreText;

    public GameObject gameOverScreen;

    public bool birdIsAlive = true;

    public CameraShake cameraShake;

    public ScreenFlash screenFlash;

    [ContextMenu("Increase Score")]
    public void addScore(int scoreToAdd) {

        if (!birdIsAlive) return;

        playerScore += scoreToAdd;
        scoreText.text = playerScore.ToString();
        AudioManager.instance.PlaySFX(AudioManager.instance.score, 0.7f);

    }

    public void restartGame() {

        Time.timeScale = 1f;
        Time.fixedDeltaTime = 0.02f;

        if (AudioManager.instance != null)
            AudioManager.instance.SetPitch(1f);

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
 
    }

    public void gameOver() {

        if (!birdIsAlive) return;
        birdIsAlive = false;

        StartCoroutine(GameOverSequence());
    }

    private IEnumerator GameOverSequence()
    {
        // 🎵 Play death sound
        AudioManager.instance.PlaySFX(AudioManager.instance.hit, 1.5f);
        AudioManager.instance.PlayRandomGameOver();

        // ⚡ Screen flash
        screenFlash.Flash();
        // 📸 Camera shake
        StartCoroutine(cameraShake.Shake(0.35f, 0.4f));

        // 🐌 Slow motion
        Time.timeScale = 0.2f;
        Time.fixedDeltaTime = 0.02f * Time.timeScale;

        // 🎧 Audio pitch drop (jam effect)
        AudioManager.instance.SetPitch(0.6f);

        // 🔇 Stop music completely
        StartCoroutine(AudioManager.instance.JamAndStopMusic(10f, 0.5f));

        // ⏱ Wait in REAL time
        yield return new WaitForSecondsRealtime(1f);


        // ❄ Freeze game
        Time.timeScale = 0f;

        // 🧾 Show UI
        gameOverScreen.SetActive(true);
    }


}
