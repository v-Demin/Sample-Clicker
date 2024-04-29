using UnityEngine;

public abstract class AbstractMapObjectToolTip : MonoBehaviour
{
    protected IMapObject MapObject;

    public void Init(IMapObject mapObject)
    {
        MapObject = mapObject;
    }

    public abstract void Show();
    public abstract void Hide();
}
