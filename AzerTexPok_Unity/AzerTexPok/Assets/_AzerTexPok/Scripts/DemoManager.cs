using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DemoManager : MonoBehaviour
{

    public List<Card_SO> deck;

    public GameObject cardPrefab;
    public List<Card_SO> listofCards;

    public int offset_card = 50;

    #region placeholders variables
    public GameObject placeholderBoard;
    public GameObject placeholderHand;

    public GameObject[] placeholderPlayerHands;
    public GameObject[] compare_Buttons;
    #endregion

    public List<Card> board_cards;
    public List<Card>[] player_cards = new List<Card>[4];

    private GameObject cardTempObj;

    private int num_hand = 1;
    private int num_cards_board = 0;
    

    void Start()
    {
        //Initialize the Array
        for (int i = 0; i < player_cards.Length; i++)
        {
            player_cards[i] = new List<Card>();
        }



        deck = listofCards;
    }

    /// <summary>
    /// Button to draw the 3 first cards. Any consecutive call will draw one card till there are 5
    /// </summary>
    public void Button_DrawFLop()
    {
        deck.Shuffle();

        if (num_cards_board < 3) //if there's less than 3 we haven't started yet, so we draw "The Flop", 3 cards on the board
        {
            for (int i = 0; i < 3; i++)
            {
                var cardObj = InstantiateCard(deck[i], placeholderBoard.transform.position, placeholderHand.transform, i);
                //num_hand++;
                board_cards.Add(cardObj.GetComponent<Card>());
                deck.Remove(deck[i]);
                num_cards_board++;
            }
        }
        else if (num_cards_board<5) //We drew the flop already and we need to draw two other cards on the board
        {
            var cardObj = InstantiateCard(deck[0], placeholderBoard.transform.position, placeholderHand.transform, num_cards_board++);

            board_cards.Add(cardObj.GetComponent<Card>());
            deck.Remove(deck[0]);
        }
        


        

    }

    /// <summary>
    /// Draws 2 card per player for 4 players.
    /// </summary>
    public void Button_Draw4PlayerHands()
    {

        if (player_cards[0].Count == 0)
        {
            deck.Shuffle();

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    var cardObj = InstantiateCard(deck[j], placeholderPlayerHands[i].transform.position, placeholderPlayerHands[i].transform, j);


                    

                    player_cards[i].Add(cardObj.GetComponent<Card>());
                    deck.Remove(deck[j]);
                }
                compare_Buttons[i].SetActive(true);
            }
        }

        

    }

    /// <summary>
    /// Checks what kind of match you have onyour hand and writes it to the UI
    /// </summary>
    /// <param name="player_num"></param>
    public void CompareHand(int player_num)
    {
        List<Card> handToCompare = new List<Card>();

        //cards on the board
        for (int i = 0; i < board_cards.Count; i++)
        {
            handToCompare.Add(board_cards[i]);
        }

        //cards on the hand of player
        for (int i = 0; i < player_cards[player_num].Count; i++)
        {
            handToCompare.Add(player_cards[player_num][i]);
        }

        PokerHand pk = new PokerHand();

        //compare them out
        pk.setPokerHand(handToCompare.ToArray());

        compare_Buttons[player_num].transform.GetChild(1).GetComponent<TMPro.TextMeshProUGUI>().text = pk.printResult();

    }

    /// <summary>
    /// Instantiates a card 
    /// </summary>
    /// <param name="sO">scriptable object with card data</param>
    /// <param name="pos">position where to instantiate it</param>
    /// <param name="parent">parent gameobject</param>
    /// <param name="num_card">number of card in hand</param>
    /// <returns>Card as a Gameobject</returns>
    private GameObject InstantiateCard(Card_SO sO, Vector3 pos, Transform parent, int num_card)
    {


        cardTempObj = Instantiate(cardPrefab, new Vector3(pos.x + (offset_card * num_card), pos.y - (2 * offset_card), 0), Quaternion.identity, parent);



        cardTempObj.GetComponent<Card>().cardValue = sO.cardValue;
        cardTempObj.GetComponent<Card>().cardColor = sO.cardColor;
        cardTempObj.name = sO.cardValue.ToString() + sO.cardColor.ToString();
        cardTempObj.transform.GetChild(1).GetComponent<Image>().sprite = sO.cardSprite;

        
        return cardTempObj;
        
    }

}
