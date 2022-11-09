using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

public class UpButton : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    private Ball _ball;
    
    [Inject]
    private void Construct(Ball ball)
    {
        _ball = ball;
    }
    
    public void OnPointerUp(PointerEventData eventData)
    {
        _ball.Mover.MoveDown();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _ball.Mover.MoveUp();
    }
}
