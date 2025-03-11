using UnityEngine;
using TMPro;
using System.Collections.Generic;
using System.Linq;

public class DeckManager : MonoBehaviour
{
    public static DeckManager Instance;

    public GameObject cardPrefab;
    public Transform handPanel;

    private List<Card> allCards = new List<Card>();
    private List<Card> playableDeck = new List<Card>();
    private List<Card> playerHand = new List<Card>();

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        GenerateAllCards();
        SelectPlayableDeck();
        DrawStartingHand();
        DisplayHand();
    }

    private void GenerateAllCards()
    {
        for (int i = 0; i < 90; i++)
        {
            Card newCard = new Card(i, GetFamily(i));
            allCards.Add(newCard);
        }
    }

    private void SelectPlayableDeck()
    {
        List<Card> shuffledDeck = new List<Card>(allCards);
        Shuffle(shuffledDeck);
        playableDeck = shuffledDeck.GetRange(0, 60);
    }

    public void DrawStartingHand()
    {
        playerHand.Clear();
        for (int i = 0; i < 3; i++)
        {
            if (playableDeck.Count > 0)
            {
                playerHand.Add(playableDeck[0]);
                playableDeck.RemoveAt(0);
            }
        }
    }

    // affiche les cartes
    private void DisplayHand()
    {
        foreach (Card card in playerHand)
        {
            GameObject newCard = Instantiate(cardPrefab, handPanel);
            newCard.GetComponentInChildren<TextMeshProUGUI>().text = $"{card.family}\nID: {card.id}";
        }
    }

    private void Shuffle(List<Card> list)
    {
        for (int i = list.Count - 1; i > 0; i--)
        {
            int j = Random.Range(0, i + 1);
            (list[i], list[j]) = (list[j], list[i]);
        }
    }

    private string GetFamily(int cardId)
    {
        return "Famille " + (cardId % 6 + 1);
    }
}
