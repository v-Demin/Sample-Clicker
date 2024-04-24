using UnityEngine.SceneManagement;

public class MapSceneInitiator
{
    private const string SceneName = "Map";

    public void LoadScene()
    {
        SceneManager.LoadScene(SceneName);
    }

    public void Resume()
    {
        SceneManager.LoadScene(SceneName);
    }
}
