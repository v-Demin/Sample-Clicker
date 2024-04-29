using UnityEngine;

public class MapUI : MonoBehaviour
{
    [SerializeField] private Transform _root;

    public Transform Root => _root;

    public void AttachObject(MapObjectView mapObjectView)
    {
        mapObjectView.transform.SetParent(_root);
    }
}
