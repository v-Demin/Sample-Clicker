using UnityEngine.SceneManagement;

public class MainMenuSceneInitiator
{
    private const string SceneName = "MainMenu";

    public void LoadScene()
    {
        SceneManager.LoadScene(SceneName);
    }
}
