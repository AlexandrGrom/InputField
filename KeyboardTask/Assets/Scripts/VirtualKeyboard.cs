using System.Collections;
using UnityEngine;


public class VirtualKeyboard : MonoBehaviour
{
    [SerializeField] private float tick = 1;
    public MyInputField InputField;
    public void StartPressKey(string s)
    {
        StartCoroutine(nameof(UpdateDataKey), s);
    }

    public void EndPressKey()
    {
        StopCoroutine(nameof(UpdateDataKey));
    }

    public void StartPressArrow(int i)
    {
        StartCoroutine(nameof(UpdateDataArrow), i);
    }

    public void EndPressArrow()
    {
        StopCoroutine(nameof(UpdateDataArrow));
    }
    
    public void StartPressKeyDelete()
    {
        StartCoroutine(nameof(UpdateDataKeyDelete));
    }

    public void EndPressKeyDelete()
    {
        StopCoroutine(nameof(UpdateDataKeyDelete));
    }
    
    private IEnumerator UpdateDataKey(string s)
    {
        while (true)
        {
            InputField.AddString(s[0]);
            yield return new WaitForSeconds(tick);
        }
    }
    
    private IEnumerator UpdateDataArrow(int i)
    {
        while (true)
        {
            InputField.MoveDirection(i);
            yield return new WaitForSeconds(tick);
        }
    }
    
    private IEnumerator UpdateDataKeyDelete()
    {
        while (true)
        {
            InputField.BackSpace();
            yield return new WaitForSeconds(tick);
        }
    }
}
