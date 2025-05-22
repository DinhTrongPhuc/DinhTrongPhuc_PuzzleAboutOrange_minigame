using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadManagerButton : MonoBehaviour
{
    public void IsClickPlayGame()
    {
        SceneManager.LoadScene("HowToPlayScene");
    }

    public void IsClickBack()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void IsClickNext()
    {
        SceneManager.LoadScene("LevelScene");
    }

    public void IsClickReset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void IsClickHome()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
