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

    public void IsClickLevel1()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void IsClickLevel2()
    {
        SceneManager.LoadScene("Level 2");
    }
    public void IsClickLevel3()
    {
        SceneManager.LoadScene("Level 3");
    }
}
