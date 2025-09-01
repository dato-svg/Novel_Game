using UnityEngine;

public class ShowHide : MonoBehaviour
{
    [SerializeField] private GameObject panel;

    private bool active = true;

    public void HideOrShow()
    {
        if (panel == null) return;

        if (active == false)
        {
            panel.transform.localScale = Vector3.zero;
            active = true;
        }
        else
        {
            panel.transform.localScale = Vector3.one;
            active = false;
        }
    }
}
