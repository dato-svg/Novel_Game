using Naninovel;

[CommandAlias("playMiniGame")]
public class PlayMiniGameCommand : Command
{
    public StringParameter GameName;

    public override async UniTask ExecuteAsync(AsyncToken asyncToken = default)
    {
        //    if (GameName == "MemoryCards")
        await Engine.GetService<MiniGameService>().PlayMemoryCardsAsync();
    }
}
