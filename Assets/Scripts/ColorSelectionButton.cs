using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorSelectionButton : MonoBehaviour
{
    public Button uiButton;
    public Image paddleReference;

    public bool isColorPlayer = false;

    public void onButtonClick()
    {
        paddleReference.color = uiButton.colors.normalColor;

        if (isColorPlayer)
        {
            //SavedColors.Instance.colorPlayer = paddleReference.color;
        }

        else
        {
            //SavedColors.Instance.colorEnemy = paddleReference.color;
        }
    }
}
