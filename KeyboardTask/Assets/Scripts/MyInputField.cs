using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class MyInputField : InputFieldOriginal
{
    private int savedSelectPosition;
    private int savedPosition;
    public void AddString(char s)
    {
        StartCoroutine(LateUpdateLabel(s));
    }

    private IEnumerator LateUpdateLabel(char s)
    {
        Append1(s);
        ActivateInputField();
        yield return null;

        caretSelectPositionInternal = caretPositionInternal = savedPosition + 1;
        savedPosition = caretSelectPositionInternal;
        UpdateLabel();
    }

    public override void OnDeselect(BaseEventData eventData)
    {
        savedSelectPosition = caretSelectPositionInternal;
        savedPosition = caretPositionInternal;
        base.OnDeselect(eventData);
    }

    protected  void Append1(char input)
    {
        string newText = "";
        
        Debug.Log(savedPosition);
        for (int i = 0; i < savedPosition; i++)
        {
            newText += m_Text[i];
        }
        newText += input;

        Debug.Log(savedSelectPosition);
        for (int i = savedSelectPosition; i < m_Text.Length; i++)
        {
            newText += m_Text[i];
        }
        
        m_Text = newText;
    }
}