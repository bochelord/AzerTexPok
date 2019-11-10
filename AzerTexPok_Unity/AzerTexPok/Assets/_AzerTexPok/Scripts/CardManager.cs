using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardManager : MonoBehaviour
{

    public Sprite cardBackSprite;
    public List<Card_SO> listofCards;

    public List<GameObject> hand_prefabs;
    public List<Card> hand_cards;

    public GameObject cardPrefab;
    public GameObject placeholderHand;

    public int offset_card = 5;


    #region cached variables

    private int num_hand = 0;
    
    private GameObject cardTempObj;

    #endregion


    void Start()
    {
        Button_StartShow();
    }

    

    public void Button_StartShow()
    {

        hand_cards.Clear();
        hand_prefabs.Clear();

        listofCards.Shuffle();

        DrawHand(num_hand++);


        PokerHand pk = new PokerHand();



        pk.setPokerHand(hand_cards.ToArray());
        Debug.Log(pk.printResult());
    }




    public void DrawHand(int num_hand)
    {

        

        for (int i = 0; i < 5; i++)
        {
            InstantiateCard(listofCards[i],i,num_hand);

        }

        

    }
    

    private void InstantiateCard(Card_SO sO, int num_card, int num_hand)
    {


        cardTempObj = Instantiate(cardPrefab, new Vector3(placeholderHand.transform.position.x + (offset_card * num_card), placeholderHand.transform.position.y - (2 * offset_card * num_hand), 0), Quaternion.identity, placeholderHand.transform);

        

        cardTempObj.GetComponent<Card>().cardValue = sO.cardValue;
        cardTempObj.GetComponent<Card>().cardColor = sO.cardColor;
        cardTempObj.name = sO.cardValue.ToString() + sO.cardColor.ToString();
        cardTempObj.transform.GetChild(1).GetComponent<Image>().sprite = sO.cardSprite;

        hand_prefabs.Add(cardTempObj);
        hand_cards.Add(cardTempObj.GetComponent<Card>());
    }



    //public void InstantiateCards(List<Card_SO> in_hand)
    //{

    //    for (int i = 0; i < in_hand.Count; i++)
    //    {

    //        GameObject cardtemp = Instantiate(cardPrefab, new Vector3(placeholderHand.transform.position.x, placeholderHand.transform.position.y + (offset_card * i), 0), Quaternion.identity, placeholderHand.transform);

    //        if (cardtemp == null)
    //        {
    //            Debug.Log("WTFUCK?");
    //        }

    //        if (cardtemp.GetComponent<Card>() == null)
    //        {
    //            Debug.Log("WTFUCK? component");
    //        }


    //        if (in_hand[i].card == null)
    //        {
    //            Debug.Log("WTF inhand?");
    //        }

    //        cardtemp.GetComponent<Card>().cardValue = in_hand[i].card.cardValue;
    //        cardtemp.GetComponent<Card>().cardColor = in_hand[i].card.cardColor;

    //        cardtemp.transform.GetChild(1).GetComponent<Image>().sprite = in_hand[i].cardSprite;



    //    }


        
    //}


}
