using UnityEngine;

public class OpenCloseUI : MonoBehaviour
{
    [SerializeField] private GameObject panel;

    public void HideOrShow()
    {
        if (panel == null) return;

        panel.SetActive(!panel.activeSelf);
    }
}
