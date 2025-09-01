using Naninovel;
using UnityEngine;

[InitializeAtRuntime]
public class MiniGameService : IEngineService
{
    public bool IsMiniGameCompleted { get; private set; }

    private IUIManager uiManager;

    public UniTask InitializeServiceAsync()
    {
        IsMiniGameCompleted = false;
        uiManager = Engine.GetService<IUIManager>();
        Debug.Log("MiniGameService initialized");
        return UniTask.CompletedTask;
    }

    public async UniTask PlayMemoryCardsAsync()
    {
        Debug.Log("Mini-game started");

        var cardGameUI = uiManager.GetUI("CardGameUI");
        cardGameUI.Show();

        var memoryGame = UnityEngine.Object.FindObjectOfType<MemoryCards>();
        var tcs = new UniTaskCompletionSource();

        memoryGame.OnGameCompleted += () =>
        {
            Debug.Log("Мини-игра завершена!");
            tcs.TrySetResult();
        };

        await tcs.Task;

        cardGameUI.Hide();

        IsMiniGameCompleted = true;
    }

    public void ResetService() { }

    public void DestroyService() { }
}
