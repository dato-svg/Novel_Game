using Naninovel;

[CommandAlias("completeQuest")]
public class CompleteQuestCommand : Command
{
    public StringParameter Text;

    public override UniTask ExecuteAsync(AsyncToken asyncToken = default)
    {
        var uiManager = Engine.GetService<IUIManager>();
        var questUI = uiManager.GetUI<QuestUIController>();
        questUI?.CompleteQuest(Text);

        return UniTask.CompletedTask;
    }
}
