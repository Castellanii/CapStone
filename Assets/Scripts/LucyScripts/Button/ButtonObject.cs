
using UnityEngine;
using UnityEngine.UI;

public abstract class ButtonObject : MonoBehaviour
{

    protected string Name;
    public virtual void OnClickEnter()
    {
        MenuUI.Instance.UIPanel.SetActive(false);
    }
    public virtual void OnHoverEnter()
    {
        MenuUI.Instance.UIPanel.SetActive(true);
        MenuUI.Instance.UIText.text = Name;
    }
    public virtual void OnHoverExit()
    {
        MenuUI.Instance.UIPanel.SetActive(false);
    }
}
