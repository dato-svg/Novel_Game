using UnityEngine;

[RequireComponent(typeof(CardButton), typeof(AudioSource))]
public class CardAudio : MonoBehaviour
{
    [SerializeField] private AudioClip clickSound;
    [SerializeField] private AudioClip flipBackSound;

    private CardButton cardButton;
    private AudioSource audioSource;

    private void Awake()
    {
        cardButton = GetComponent<CardButton>();
        audioSource = GetComponent<AudioSource>();

        cardButton.OnCardClicked += HandleCardClicked;
        cardButton.OnCardFlippedBack += HandleCardFlippedBack;
    }

    private void OnDestroy()
    {
        cardButton.OnCardClicked -= HandleCardClicked;
        cardButton.OnCardFlippedBack -= HandleCardFlippedBack;
    }

    private void HandleCardClicked(CardButton card)
    {
        PlaySound(clickSound);
    }

    private void HandleCardFlippedBack(CardButton card)
    {
        PlaySound(flipBackSound);
    }

    private void PlaySound(AudioClip clip)
    {
        if (clip != null)
            audioSource.PlayOneShot(clip);
    }
}
