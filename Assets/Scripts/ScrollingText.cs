using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class ScrollingText : MonoBehaviour
{

	#region -- 資源參考區 --

	public TMP_InputField InputField_Text_Color_R;
    public TMP_InputField InputField_Text_Color_G;
    public TMP_InputField InputField_Text_Color_B;
    public TMP_InputField InputField_Text_Color_A;
	public TMP_InputField InputField_Text_Speed;

    #endregion

    #region -- 變數參考區 --

    private Image Image_ScrollingText;
	private Material Material_ScrollingText;

    float r, g, b, a, speed;

    #endregion

    #region -- 初始化/運作 --

    private void Awake()
	{

        Image_ScrollingText = this.GetComponent<Image>();
        Material_ScrollingText = Image_ScrollingText.material;

    }

	private void Update()
	{

        if (float.TryParse(InputField_Text_Color_R.text, out r) &&
        float.TryParse(InputField_Text_Color_G.text, out g) &&
        float.TryParse(InputField_Text_Color_B.text, out b) &&
        float.TryParse(InputField_Text_Color_A.text, out a) &&
        float.TryParse(InputField_Text_Speed.text, out speed))
        {
            Image_ScrollingText.color = new Color(r, g, b, a);
            Material_ScrollingText.SetFloat("_MoveSpeed", speed);
        }
        else
        {
            Debug.LogError("One or more inputs are invalid.");
        }


    }

	#endregion
	
	#region -- 方法參考區 --

	#endregion
	
}
