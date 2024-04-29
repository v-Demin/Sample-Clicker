using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    [SerializeField] private MapObjectFactory _factory;
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _factory.GenerateBattle();
        }
    }
}
