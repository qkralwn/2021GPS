using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class NodePiece : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public int value;
    public Point index;

    [HideInInspector]
    public Vector2 pos;
    
    [HideInInspector]
    public RectTransform rect;

    bool isUpdating;
    Image img;

    public void Initialize(int v, Point p, Sprite piece) {
        img = GetComponent<Image>();
        rect = GetComponent<RectTransform>();

        value = v;
        SetIndex(p);
        img.sprite = piece;
    }


    public void SetIndex(Point p) {
        index = p;
        ResetPosition();
        UpdateName();
    }

    public void ResetPosition() {
        pos = new Vector2(32 + (64 * index.x), -32 - (64 * index.y)); //////노드 좌표에
    }

    public void MovePosition(Vector2 move) {
        rect.anchoredPosition += move * Time.deltaTime * 16f;
    }

    public void MovePositionTo(Vector2 move) {
        rect.anchoredPosition = Vector2.Lerp(rect.anchoredPosition, move, Time.deltaTime * 16f);
    }

    public bool UpdatePiece() {
        if(Vector3.Distance(rect.anchoredPosition, pos) > 1) {
            MovePositionTo(pos);
            isUpdating = true;

            return true;
        }

        else {
            rect.anchoredPosition = pos;
            isUpdating = false;
            return false;
        }
        //return true; //안움직일땐false반환
    }

    void UpdateName() {
        transform.name = "Node [" + index.x + ", " + index.y + "]";
    }

    public void OnPointerDown(PointerEventData eventData) {
        if (isUpdating) {
            return;
        }
        MovePiece.instance.MovePieces(this);
    }

    public void OnPointerUp(PointerEventData eventData) {
        MovePiece.instance.DropPieces();
    }
}