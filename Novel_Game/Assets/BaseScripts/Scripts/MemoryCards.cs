using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryCards : MonoBehaviour
{
    public List<CardButton> cards;
    [SerializeField] private float time = 0.5f;
    private CardButton firstCard, secondCard;

    private bool isChecking = false;
    public event Action OnGameCompleted;

    public void OnCardSelected(CardButton card)
    {
        if (isChecking) return;

        if (firstCard != null && card == firstCard) return;

        if (firstCard == null) firstCard = card;
        else if (secondCard == null)
        {
            secondCard = card;
            StartCoroutine(CheckPair());
        }
    }

    private IEnumerator CheckPair()
    {
        SetCardsInteractable(false);

        yield return new WaitForSeconds(time);

        if (firstCard.cardId == secondCard.cardId)
        {
            firstCard.Hide();
            secondCard.Hide();
        }
        else
        {
            firstCard.Flip();
            secondCard.Flip();
            yield return new WaitForSeconds(time);
        }

        firstCard = null;
        secondCard = null;

        SetCardsInteractable(true);

        if (AllCardsCleared())
        {
            Debug.Log("Все карты открыты!");
            OnGameCompleted?.Invoke();
        }
    }

    private void SetCardsInteractable(bool interactable)
    {
        foreach (var card in cards)
        {
            card.enabled = interactable;
        }
    }



    private bool AllCardsCleared()
    {
        foreach (var card in cards)
        {
            if (card.gameObject.activeSelf) return false;
        }
        return true;
    }
}
