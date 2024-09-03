using UnityEngine;
using UnityEngine.UI;

public class UISwitcher : MonoBehaviour
{
    public GameObject scrollingText;
    public GameObject Settings;
    public Button button_Return;

    void Awake()
    {
        // 防呆檢查：確保面板物件已設置
        if (scrollingText == null)
        {
            Debug.LogError("scrollingText未設置。請在檢視器中拖曳對應的面板物件。");
            enabled = false; // 禁用此腳本以防止錯誤操作
            return;
        }

        if(button_Return != null)
        {
            button_Return.onClick.AddListener(() => ToggleUI(true));
        }

    }

    void Update()
    {
        // 檢測PC上的滑鼠點擊事件
        if (Input.GetMouseButtonDown(0))
        {
            ToggleUI(false);
        }

        // 檢測手機上的觸摸事件
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                ToggleUI(false);
            }
        }
    }

    public void ToggleUI(bool isActive)
    {

        scrollingText.SetActive(isActive);
        Settings.SetActive(!isActive);

    }
}
