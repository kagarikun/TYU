using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputProvider : MonoBehaviour
{
    bool isLightButton;
    bool isRightButton;
    bool isUpButton;
    bool isDownButton;
    bool isJumpButtonDown;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isLightButton = Input.GetKey(KeyCode.A);
        isRightButton = Input.GetKey(KeyCode.D);
        isUpButton = Input.GetKey(KeyCode.W);
        isDownButton = Input.GetKey(KeyCode.S);
        if (!isJumpButtonDown)
        {
            isJumpButtonDown = Input.GetKeyDown(KeyCode.Space);
        }
    }
    public bool IsLeftButton()
    {
        return isLightButton;
    }
    public bool IsRightButton()
    {
        return isRightButton;
    }
    public bool IsUpButton()
    {
        return isUpButton;
    }
    public bool IsDownButton()
    {
        return isDownButton;
    }
    public bool IsJumpButtonDown()
    {
        if (isJumpButtonDown)
        {
            isJumpButtonDown = false;
            return true;
        }
        return isJumpButtonDown;
    }
}
