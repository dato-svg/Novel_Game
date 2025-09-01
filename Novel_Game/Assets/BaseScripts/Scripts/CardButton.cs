using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class CardButton : MonoBehaviour, IPointerClickHandler
{
    public int cardId;
    public Image cardImage;
    public Sprite frontSprite;
    public Sprite backSprite;

    private bool isFlipped = false;
    public MemoryCards gameManager;

    public event Action<CardButton> OnCardClicked;
    public event Action<CardButton> OnCardFlippedBack;

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

        OnCardClicked?.Invoke(this);

        gameManager.OnCardSelected(this);
    }

    public void Flip()
    {
        isFlipped = !isFlipped;
        cardImage.sprite = isFlipped ? frontSprite : backSprite;

        if (!isFlipped)
            OnCardFlippedBack?.Invoke(this);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public bool IsFlipped() => isFlipped;
}
