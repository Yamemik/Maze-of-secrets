using UnityEngine;

public class CameraPlayer : MonoBehaviour
{
    [SerializeField] float sensitivityMouse;
    [SerializeField] Camera player;
    [SerializeField] GameObject playerGameObject;
    [SerializeField] float smoothTime;

    float mouseX;
    float mouseY;
    float mouseXCurrent;
    float mouseYCurrent;
    float currentVelocityX;
    float currentVelocityY;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        MouseMove();
    }

    void MouseMove()
    {
        mouseX += Input.GetAxis("Mouse X") * sensitivityMouse * 0.65f * Time.deltaTime;
        mouseY += Input.GetAxis("Mouse Y") * sensitivityMouse * 0.8f * Time.deltaTime;

        mouseY = Mathf.Clamp(mouseY, -90f, 90f);

        mouseXCurrent = Mathf.SmoothDamp(mouseXCurrent, mouseX, ref currentVelocityX, smoothTime);
        mouseYCurrent = Mathf.SmoothDamp(mouseYCurrent, mouseY, ref currentVelocityY, smoothTime);

        playerGameObject.transform.rotation = Quaternion.Euler(0f, mouseXCurrent, 0f);
        player.transform.rotation = Quaternion.Euler(-mouseYCurrent, mouseXCurrent, 0f);
    }
}
