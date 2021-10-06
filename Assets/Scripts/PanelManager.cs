using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelManager : MonoBehaviour
{
    
    static int CardCounter;
    public Text CounterText;

    // Start is called before the first frame update
    private void Awake()
    {
        CardCounter = 0;
        CounterText.text = "The number of cards in stack are: "+CardCounter;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnEnable()
    {
        StackManager.OnCardAdded += IncreaseDeckCounter;
        StackManager.OnCardRemoved += DecreaseDeckCounter;
    }
    private void OnDisable()
    {
        StackManager.OnCardAdded -= IncreaseDeckCounter;
        StackManager.OnCardRemoved -= DecreaseDeckCounter;
    }
    void IncreaseDeckCounter()
    {
        CardCounter++;
        CounterText.text = "The number of cards in stack are: " + CardCounter;
    }
    void DecreaseDeckCounter()
    {
        CardCounter--;
        CounterText.text = "The number of cards in stack are: " + CardCounter;
    }

}
