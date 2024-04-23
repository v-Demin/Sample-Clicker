using UnityEngine.SceneManagement;

public class BattleSceneInitiator
{
    private const string SceneName = "Battle";
    public BattleRequestData Data;
    
    public void StartBattle(BattleRequestData data)
    {
        Data = data;
        SceneManager.LoadScene(SceneName);
    }
}
