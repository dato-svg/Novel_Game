using UnityEngine;
using TMPro;
using Naninovel.UI;

public class QuestUIController : CustomUI
{
    [SerializeField] private TextMeshProUGUI questText;

    public void SetQuest(string description)
    {
        questText.text = description;
    }

    public void HideAfterCompletion()
    {
        Hide();
    }
}
