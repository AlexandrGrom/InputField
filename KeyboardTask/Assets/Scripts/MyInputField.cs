using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class MyInputField : InputFieldOriginal
{
    private int savedSelectPosition;
    private int savedPosition;
    
    private int Difference => savedSelectPosition - savedPosition == 0 ? -1 : 0;
    
    public void AddString(char s)
    {
        UIAppend(s);
        MoveDirection(1);
    }

    public void BackSpace()
    {
        UIAppend('\0', Difference);
        MoveDirection(Difference);
    }


    public override void OnDeselect(BaseEventData eventData)
    {
        savedSelectPosition = caretSelectPositionInternal;
        savedPosition = caretPositionInternal;
        base.OnDeselect(eventData);
    }

    private void UIAppend(char input, int offset = 0)
    {
        if (savedPosition > savedSelectPosition)
        {
            Switch(ref savedPosition, ref savedSelectPosition);
        }

        
        string newText = "";
        
        for (int i = 0; i < savedPosition + offset; i++)
        {
            newText += m_Text[i];
        }

        if (input != '\0')
        {
            newText += input;
        }

        for (int i = savedSelectPosition; i < m_Text.Length; i++)
        {
            newText += m_Text[i];
        }
        
        Debug.Log(m_Text);

        m_Text = newText;
    }

    public void MoveDirection(int direction)
    {
        StartCoroutine(UpdateInputField(direction));
    }
    
    private IEnumerator UpdateInputField(int direction)
    {
        ActivateInputField();

        yield return new WaitForEndOfFrame();
        
        caretSelectPositionInternal = caretPositionInternal = savedPosition + direction;
        savedPosition = caretSelectPositionInternal;
        savedSelectPosition = caretSelectPositionInternal;
        
        UpdateLabel();
    }
    
    private void Switch(ref int value1, ref int value2)
    {
        var switchValue = value1;
        value1 = value2;
        value2 = switchValue;
    }

}

public static class IntExtensions
{

}