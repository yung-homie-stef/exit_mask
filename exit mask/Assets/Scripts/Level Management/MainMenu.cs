using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Animator animator;

    public void FadeToLevel()
    {
        animator.SetTrigger("Fade_Out");
        
    }

    public void OnFadeComplete()
    {
        PlayGame();
    }

    public void PlayGame()
    {
        // this advances the current scene in the game to the next on the queue
        // to check the scene queue, go to build settings 
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
