using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardManager : MonoBehaviour
{

    public Sprite cardBackSprite;
    public List<Card_SO> listofCards;

    public List<Card_SO> hand;


    public GameObject cardPrefab;
    public GameObject placeholderHand;

    private List<Card_SO> deck;
    private int offset_card = 5;

    void Start()
    {

        deck = listofCards;


        deck.Shuffle();

        DrawHand();
    }

    


    public void DrawHand()
    {

        hand = new List<Card_SO>();

        for (int i = 0; i < 5; i++)
        {
            hand.Add(deck[i]);
        }

        InstantiateCards(hand);

    }
    


    public void InstantiateCards(List<Card_SO> in_hand)
    {

        for (int i = 0; i < in_hand.Count; i++)
        {

            GameObject cardtemp = Instantiate(cardPrefab, new Vector3(placeholderHand.transform.position.x, placeholderHand.transform.position.y + (offset_card * i), 0), Quaternion.identity, placeholderHand.transform);

            if (cardtemp == null)
            {
                Debug.Log("WTFUCK?");
            }

            if (in_hand[i] == null)
            {
                Debug.Log("WTF inhand?");
            }

            cardtemp.GetComponent<Card>().cardValue = in_hand[i].card.cardValue;
            cardtemp.GetComponent<Card>().cardColor = in_hand[i].card.cardColor;

            cardtemp.transform.GetChild(1).GetComponent<Image>().sprite = in_hand[i].cardSprite;



        }


        
    }


}
