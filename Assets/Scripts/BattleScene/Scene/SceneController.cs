using UnityEngine;

public class SceneController : MonoBehaviour
{
    [SerializeField] private FallbackBattleSceneController _fallback;
    private void Start()
    {
        _fallback.ValidateSceneStart();
    }
}
