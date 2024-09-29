using UnityEngine;

public class Crosshair : MonoBehaviour
{
    [SerializeField]RectTransform crosshair;
    [SerializeField] float sizeState;
    [SerializeField] float sizeMove;
    [SerializeField] float sizeMoveRun;
    [SerializeField] float sizejump;
    [SerializeField] float speedSize;
    
    float sizeCurrent = 50;

    bool IsMoving
    {
        get
        {
            if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
                return true;
            else 
                return false;
        }
    }

    void Update()
    {
        if (IsMoving)
        {
            sizeCurrent = Mathf.Lerp(sizeCurrent,sizeMove,Time.deltaTime * speedSize);

            if (Input.GetKey(KeyCode.LeftShift))
            {
                sizeCurrent = Mathf.Lerp(sizeCurrent, sizeMoveRun, Time.deltaTime * speedSize);
            }
            else
            {
                sizeCurrent = Mathf.Lerp(sizeCurrent, sizeMove, Time.deltaTime * speedSize);
            }
        }
        else
        {
            sizeCurrent = Mathf.Lerp(sizeCurrent, sizeState, Time.deltaTime * speedSize);
        }

        crosshair.sizeDelta = new Vector2(sizeCurrent,sizeCurrent);
    }
}
