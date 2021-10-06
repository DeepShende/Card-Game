using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
   
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("Hi I am working!");
    }

    // Update is called once per frame
    void Update()
    {

    }
    class Card
    {
        int CardNumber;
        public Card(int _CardNumber)
        {
            if ((_CardNumber > 13 || _CardNumber <= 0))
            {
                CardNumber = UnityEngine.Random.Range(1, 13);
            }
            else
            CardNumber = _CardNumber;
        }
        public int cardnumber
        {
            get
            {
                    return CardNumber;
            }
        }
    
    }
    class Deck
    {
        public static List<Card> cards = new List<Card>();
        //static Card[] cards = new Card[13];
        public Deck()
         {
         }
         public void Push(int _CardNumber)
         {
                 cards.Add(new Card(_CardNumber));
                 //cards[++top] = new Card(_CardNumber);
                 Debug.Log("Adding " + _CardNumber + " at position " + (cards.Count-1));
         }
         public int Pop()
         {
            if(cards.Count<=0)
            {
                Debug.Log("Stack Underflow");
                return 0;
            }
            else
            {
                int value = cards[cards.Count-1].cardnumber;
                cards.RemoveAt(cards.Count-1);
                //int value = cards[top--].cardnumber;
                Debug.Log("Removing card with value " + value);
                return value;
            
            }
         }
        public int Peek()
        {
            if(cards==null)
            {
                Debug.Log("Deck is Empty!");
                return 0;
            }
            Debug.Log("The Card at top is: " + cards[cards.Count - 1].cardnumber);
            return cards[cards.Count - 1].cardnumber;
        }
        public void Shuffle()
        {
            int currLastIndex = cards.Count-1;
            int randomInt;
            int index = 0;
            for (int i=currLastIndex;currLastIndex>0;currLastIndex--)
            {
                randomInt = UnityEngine.Random.Range(0, currLastIndex);
                Debug.Log("Swapping Card number "+cards[randomInt].cardnumber+" with card number "+ cards[currLastIndex].cardnumber);
                Card temp = cards[randomInt];
                cards[randomInt] = cards[currLastIndex];
                cards[currLastIndex] = temp;
            }
            Debug.Log("After Shuffle!");
            foreach(Card c in cards)
            {
                Debug.Log("The cards at index: "+ index +" is: " +c.cardnumber);
                index++;
            }
        }
        bool alreadyExists(int n)
        {
            foreach(Card c in cards)
            {
                if(n==c.cardnumber)
                {
                    return true;
                }
            }
            return false;
        }
        
    }
    public void Main()
    {
        Deck deck = new Deck();
        deck.Push(10);
        deck.Push(2);
        deck.Push(4);
        deck.Push(4);
        deck.Push(9);
        deck.Push(8);
        deck.Shuffle();
        deck.Push(2);
        deck.Push(3);
        deck.Push(7);
        deck.Push(1);
        deck.Push(12);
        deck.Push(15);
        deck.Pop();
        deck.Pop();
        deck.Pop();
        deck.Pop();
        deck.Peek();
        deck.Shuffle();
        
    }

}

