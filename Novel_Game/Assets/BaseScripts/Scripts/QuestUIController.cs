using UnityEngine;
using TMPro;
using Naninovel.UI;
using System.Collections.Generic;

public class QuestUIController : CustomUI
{
    [SerializeField] private Transform questParent;
    [SerializeField] private GameObject textSlotPrefab;

    private class Quest
    {
        public string Description;
        public bool Completed;
        public TextMeshProUGUI TextObject;
    }

    private readonly List<Quest> quests = new();

    public void AddQuest(string description)
    {
        var questGO = Instantiate(textSlotPrefab, questParent);
        var textComponent = questGO.GetComponentInChildren<TextMeshProUGUI>();
        Debug.Log("Я зашел в AddQuest");
        var quest = new Quest
        {
            Description = description,
            Completed = false,
            TextObject = textComponent
        };

        quests.Add(quest);
        RefreshQuestUI(quest);
    }


    public void CompleteQuest(string description)
    {
        var quest = quests.Find(q => q.Description == description);
        if (quest != null)
        {
            quest.Completed = true;
            RefreshQuestUI(quest);
        }
    }

    private void RefreshQuestUI(Quest quest)
    {
        string text = quest.Description;

        if (quest.Completed)
            text = $"<s>{text}</s>";

        if (quest == quests[quests.Count - 1] && !quest.Completed)
            text = $"<b>{text}</b>";

        quest.TextObject.text = text;
    }

}
