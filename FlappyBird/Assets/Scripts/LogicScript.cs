using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public int playerScore;

    public Text scoreText;

    public GameObject gameOverScreen;

    public bool birdIsAlive = true;

    //public AudioSource gameOverAudio;


    [ContextMenu("Increase Score")]
    public void addScore(int scoreToAdd) {

        if (!birdIsAlive) return;
            playerScore += scoreToAdd;
            scoreText.text = playerScore.ToString();
        
    }

    public void restartGame() {

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
 
    }

    public void gameOver() {

        gameOverScreen.SetActive(true);
        birdIsAlive = false;
        //gameOverAudio.PlayOneShot(gameOverAudio.clip);

        //Time.timeScale = 0f;

    }


}
