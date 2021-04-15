using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePiece : MonoBehaviour
{
    public static MovePiece instance;
    Match game;
    NodePiece moving;
    Point newIndex;
    Vector2 mouseStart;

    private void Awake() {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        game = GetComponent<Match>();
    }

    // Update is called once per frame
    void Update()
    {
        if(moving != null) {
            Vector2 dir = ((Vector2)Input.mousePosition - mouseStart);
            Vector2 nDir = dir.normalized;
            Vector2 aDir = new Vector2(Mathf.Abs(dir.x), Mathf.Abs(dir.y));

            newIndex = Point.clone(moving.index);

            Point add = Point.zero;

            if(dir.magnitude > 32) { //마우스가 32픽셀 넘어가 잇을경우
                //(1,0) or (-1,0 ) (0,1 ) (0,-1)
                if(aDir.x > aDir.y) {
                    add = (new Point((nDir.x > 0) ? 1 : -1, 0));
                }
                else if(aDir.y > aDir.x) {
                    add = (new Point(0, (nDir.y > 0) ? -1 : 1)); //y좌표가 위로 가면(0보다크면) 아래에 잇는 모양이랑 바뀌어야하니까 위로갓을때 -1
                }
            }
            newIndex.add(add);

            Vector2 pos = game.getPositionFromPoint(moving.index);
            if (!newIndex.Equals(moving.index)) {
                pos += Point.mult(new Point(add.x, -add.y), 16).ToVector();
            }

            moving.MovePositionTo(pos);
        }
    }

    public void MovePieces(NodePiece piece) {
        if(moving != null) {
            return;
        }

        moving = piece;
        mouseStart = Input.mousePosition;
    }

    /// ////////////////////
    public void DropPieces() {
        if(moving == null) {
            return;
        }
        //Debug.Log("Dropped");

        if (!newIndex.Equals(moving.index)) {
            game.FlipPieces(moving.index, newIndex, true);
        }
        else {
            game.ResetPiece(moving);
        }

        moving = null;
    }
}
