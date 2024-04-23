using UnityEngine.SceneManagement;

public class MapSceneInitiator
{
    private const string SceneName = "Map";

    public void Resume()
    {
        SceneManager.LoadScene(SceneName);
    }
}
