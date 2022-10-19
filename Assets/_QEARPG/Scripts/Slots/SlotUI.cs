using UnityEngine;
using QuintaEssenta.Library;

public class SlotUI : BaseBehaviour
{
    [GetComponent]
    protected RectTransform _rectTransform;

    public delegate void FillnessHandler();
    public event FillnessHandler OnFill;
    public event FillnessHandler OnEmpty;

    public bool CheckFullness()
    {
        if (_rectTransform.childCount != 0)
            return true;
        else return false;
    }

    public T ReturnChild<T>()
    {
        if (_rectTransform.childCount != 0)
        {
            if (_rectTransform.GetChild(0).TryGetComponent(out T value))
                return value;

            else return default;
        }
        else return default;
    }

    public bool Fill(RectTransform rectTransform)
    {
        if (CheckFullness() == false)
        {
            rectTransform.SetParent(_rectTransform);
            rectTransform.anchoredPosition = Vector2.zero;
            rectTransform.localScale = Vector3.one;

            OnFill?.Invoke();

            return true;
        }
        else return false;
    }

    public void ToEmpty()
    {
        OnEmpty?.Invoke();
    }
}