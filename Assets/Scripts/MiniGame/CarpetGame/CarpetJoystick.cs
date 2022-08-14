using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CarpetJoystick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    public CarpetPlayer cp;
    public GameObject smallCircle;
    public Vector2 smallCircle_Direction;
    Vector2 localCursor;
    float smallCircle_positionLimits = 100f;

    public void OnPointerDown(PointerEventData eventData)
    {
        if (!RectTransformUtility.ScreenPointToLocalPointInRectangle(GetComponent<RectTransform>(), eventData.position, eventData.pressEventCamera, out localCursor))
            return;
        smallCircle.transform.localPosition = localCursor;
        //cm._characterstate = CharacterState.move;
    }
    public void OnDrag(PointerEventData eventData)
    {
        if (!RectTransformUtility.ScreenPointToLocalPointInRectangle(GetComponent<RectTransform>(), eventData.position, eventData.pressEventCamera, out localCursor))
            return;
        SetSmallCirclePosition();
        smallCircle_Direction = smallCircle.transform.localPosition.normalized;
        //cp.move_dir = new Vector3(smallCircle_Direction.x, 0, 0);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        //cm._characterstate = CharacterState.none;
        smallCircle.transform.localPosition = new Vector2(0, 0);
    }

    void SetSmallCirclePosition()
    {
        Vector2 smallCircle_pos = localCursor;
        smallCircle_pos = Vector2.ClampMagnitude(smallCircle_pos, smallCircle_positionLimits);
        smallCircle.transform.localPosition = smallCircle_pos;
    }
}
