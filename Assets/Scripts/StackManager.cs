using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StackManager : MonoBehaviour
{
    public GameObject CardPrefab;
    static float yposition = 0.5f;
    public AudioSource audioSource;
    public AudioClip ClickClip,AddClip,DiscardClip,FlipClip,ErrorClip;
    public delegate void OnCardAction();
    public static event OnCardAction OnCardAdded;
    public static event OnCardAction OnCardRemoved;

    // Start is called before the first frame update
    void Start()
    {
    }
    private void OnEnable()
    {
        OnCardAdded += Push;
        OnCardRemoved += Pop;
    }
    private void OnDisable()
    {
        OnCardAdded -= Push;
        OnCardRemoved -= Pop;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("a"))
        {
            //Push();
            //EventManager.OnCardAdded();
        }
        else if (Input.GetKeyDown("d"))
        {
            //Pop();
            //EventManager.OnCardRemoved();
        }
        else if (Input.GetKeyDown("s"))
            Peek();
    }
    
    public static List<GameObject> cards=new List<GameObject>();

    public StackManager()
    {
    }
    public void Push()
    {
        var tmp = Instantiate(CardPrefab, new Vector3(0, yposition, 0), Quaternion.identity);
        audioSource.PlayOneShot(AddClip);
        cards.Add(tmp);
        tmp.GetComponent<Card>().setCardNumber(cards.Count-1);
        yposition += 0.02f;
    }
    public void Pop()
    {
            var tmp = cards[cards.Count - 1].GetComponent<Card>();
            int value = tmp.cardnumber;
            cards.RemoveAt(cards.Count - 1);
            audioSource.PlayOneShot(DiscardClip);
            tmp.OnPop();
            yposition -= 0.02f;
            Debug.Log("Removing card with value " + value);
    }
    bool IsDeckEmpty()
    {
        if(cards.Count<=0)
        {
            audioSource.PlayOneShot(ErrorClip);
            Debug.Log("Stack Underflow");
            return true;
        }
        return false;
    }
    public int Peek()
    {
        if (cards.Count==0)
        {
            audioSource.PlayOneShot(ErrorClip);
            Debug.Log("Deck is Empty!");
            return 0;
        }
        var tmp = cards[cards.Count - 1].GetComponent<Card>();
        audioSource.PlayOneShot(FlipClip);
        tmp.OnPeek();
        Debug.Log("The Card at top is: " + tmp.cardnumber);
        return tmp.cardnumber;
    }
    public void ButtonController(Button button)
    {
        //audioSource.PlayOneShot(ClickClip);
        if (button.name == "Add" && OnCardAdded !=null)
        {
            OnCardAdded();
        }
        else if (button.name == "Remove" && OnCardRemoved!=null)
        {
            if (!IsDeckEmpty())
                OnCardRemoved();
        }
        else if(button.name=="Reveal")
            Peek();
    }
    /*public void Shuffle()
    {
        int currLastIndex = cards.Count - 1;
        int randomInt;
        int index = 0;
        for (int i = currLastIndex; currLastIndex > 0; currLastIndex--)
        {
            randomInt = UnityEngine.Random.Range(0, currLastIndex);
            Debug.Log("Swapping Card number " + cards[randomInt].cardnumber + " with card number " + cards[currLastIndex].cardnumber);
            Card temp = cards[randomInt];
            cards[randomInt] = cards[currLastIndex];
            cards[currLastIndex] = temp;
        }
        Debug.Log("After Shuffle!");
        foreach (Card c in cards)
        {
            Debug.Log("The cards at index: " + index + " is: " + c.cardnumber);
            index++;
        }
    }*/

}

