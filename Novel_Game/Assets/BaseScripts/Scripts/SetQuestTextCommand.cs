using UnityEngine;
using Naninovel;

[CommandAlias("setQuestText")]
public class SetQuestTextCommand : Command
{
    public StringParameter Text;

    public override UniTask ExecuteAsync(AsyncToken asyncToken = default)
    {
        var uiManager = Engine.GetService<IUIManager>();

        var questUI = uiManager.GetUI<QuestUIController>();
        if (questUI != null)
        {
            Debug.Log("Я зашел setquestText");
            questUI.AddQuest(Text);
        }

        return UniTask.CompletedTask;
    }
}
