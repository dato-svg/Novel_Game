using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CardButton : MonoBehaviour, IPointerClickHandler
{
    public int cardId;
    public Image cardImage;
    public Sprite frontSprite;
    public Sprite backSprite;

    private bool isFlipped = false;
    public MemoryCards gameManager;

    public void Init(MemoryCards manager, int id, Sprite front, Sprite back)
    {
        gameManager = manager;
        cardId = id;
        frontSprite = front;
        backSprite = back;
        cardImage.sprite = backSprite;
        isFlipped = false;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (!isFlipped) Flip();
        gameManager.OnCardSelected(this);
    }

    public void Flip()
    {
        isFlipped = !isFlipped;
        cardImage.sprite = isFlipped ? frontSprite : backSprite;
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public bool IsFlipped() => isFlipped;
}
