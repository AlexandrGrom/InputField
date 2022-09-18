﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VirtualKeyboard : MonoBehaviour {

    public MyInputField InputField;

    public void KeyPress(string c)
    {
        InputField.AddString(c[0]);
    }

    public void KeyLeft()
    {
        InputField.MoveDirection(-1);
    }

    public void KeyRight()
    {
        InputField.MoveDirection(1);
    }

    public void KeyDelete()
    {
        InputField.BackSpace();
    }
}
