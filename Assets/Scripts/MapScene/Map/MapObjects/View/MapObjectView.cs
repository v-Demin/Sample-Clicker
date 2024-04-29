using UnityEngine;
using UnityEngine.EventSystems;

//[Todo]: возможно стоит переделать на генерики

public class MapObjectView : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler
{
    private IMapObject _mapObject;

    public void Init(IMapObject mapObject)
    {
        _mapObject = mapObject;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        _mapObject.Interact();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //[Todo]: изменение цвета
    }
    
    public void OnPointerUp(PointerEventData eventData)
    {
        //[Todo]: возвращение цвета обратно
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        //[Todo]: вывод окошка с подсказкой
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //[Todo]: выключение окошка с подсказкой 
    }
}
