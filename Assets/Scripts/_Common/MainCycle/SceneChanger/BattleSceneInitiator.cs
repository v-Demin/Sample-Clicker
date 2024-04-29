using System.Collections.Generic;
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

public class BattleRequestData
{
    public List<Enemy> Enemies;

    public BattleRequestData(List<Enemy> enemies)
    {
        Enemies = enemies;
    }
}
