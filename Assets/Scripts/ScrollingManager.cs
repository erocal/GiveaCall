using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScrollingManager : MonoBehaviour
{

    #region -- 資源參考區 --

    [Header("Script")]
    public ScrollingText scrollingText;

    [Header("TMPro")]
    public TMP_InputField InputField_Text_Color_R;
    public TMP_InputField InputField_Text_Color_G;
    public TMP_InputField InputField_Text_Color_B;
    public TMP_InputField InputField_Text_Color_A;
    public TMP_InputField InputField_Text_Speed;
    public TMP_InputField InputField_Text_ScrollingText;

    [Header("GameObject")]
    public GameObject Scrolling_Text_Group;
    public GameObject Settings;

    [Header("Button")]
    public Button button_Return;

    [Header("Material")]
    public Material fullScreen_ScrollingText;

    #endregion

    void Awake()
    {
        // 防呆檢查：確保面板物件已設置
        if (Scrolling_Text_Group == null)
        {
            Debug.LogError("scrollingText未設置。請在檢視器中拖曳對應的面板物件。");
            enabled = false; // 禁用此腳本以防止錯誤操作
            return;
        }

        if (button_Return != null)
        {
            button_Return.onClick.AddListener(() => ActiveScrollingTextUI(true));
        }

    }

    void Update()
    {

        SetScrollSpeed();
        SetTextColor();
        SetText();

        // 檢測PC上的滑鼠點擊事件
        if (Input.GetMouseButtonDown(0))
        {
            ActiveScrollingTextUI(false);
        }

        // 檢測手機上的觸摸事件
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                ActiveScrollingTextUI(false);
            }
        }

    }

    private void SetScrollSpeed()
    {

        if (scrollingText == null) return;

        if (float.TryParse(InputField_Text_Speed.text, out float scrollSpeed))
            scrollingText.ScrollSpeed = scrollSpeed;

    }

    private void SetTextColor()
    {

        if (scrollingText == null) return;

        if (float.TryParse(InputField_Text_Color_R.text, out float r) &&
        float.TryParse(InputField_Text_Color_G.text, out float g) &&
        float.TryParse(InputField_Text_Color_B.text, out float b) &&
        float.TryParse(InputField_Text_Color_A.text, out float a))
        {
            scrollingText._originalTextMesh.color = new Color(r, g, b, a);
        }

    }

    private void SetText()
    {

        if (scrollingText == null) return;

        scrollingText._originalTextMesh.text = InputField_Text_ScrollingText.text;

    }

    public void ActiveScrollingTextUI(bool isActive)
    {

        Scrolling_Text_Group.SetActive(isActive);
        Settings.SetActive(!isActive);

        if(isActive)
            fullScreen_ScrollingText.EnableKeyword("_DOTON");
        else
            fullScreen_ScrollingText.DisableKeyword("_DOTON");

    }


}
