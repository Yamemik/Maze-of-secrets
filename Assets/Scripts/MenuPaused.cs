using UnityEngine;

public class MenuPaused : MonoBehaviour
{
    [SerializeField] GameObject menuPaused;
    [SerializeField] Crosshair crosshair;
    [SerializeField] KeyCode keyCode;

    bool isActiveMenu = false;

    void Start()
    {
        menuPaused.SetActive(false);
    }

    void Update()
    {
        ActiveMenu();
    }

    void ActiveMenu()
    {
        if (Input.GetKeyDown(keyCode))
        {
            isActiveMenu = !isActiveMenu;
        }

        if (isActiveMenu)
        {
            menuPaused.SetActive(true);
            crosshair.enabled = false;
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0f;
            Cursor.visible = true;
        }
        else
        {
            menuPaused.SetActive(false);
            crosshair.enabled = true;
            Cursor.lockState = CursorLockMode.Locked;
            Time.timeScale = 1f;
            Cursor.visible = false;
        }
    }

    public void BtnContinum_click()
    {
        isActiveMenu = false;
    }

    public void BtnSetting_click()
    {
        isActiveMenu = false;
    }

    public void BtnMenu_click()
    {
        isActiveMenu = false;
    }
}
