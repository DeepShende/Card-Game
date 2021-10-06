using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    public TextMeshPro NumberText;
    Animator animator;
    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        //animator = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    int CardNumber;
    public void setCardNumber(int ind)
    {
        CardNumber = Random.Range(1, 13);
        NumberText.text = CardNumber.ToString();
        Debug.Log("Adding " + CardNumber + " at position " + ind);
    }
    public int cardnumber
    {
        get
        {
            return CardNumber;
        }
    }
    public void OnPop()
    {
        animator.SetBool("RemovingCard", true);
    }
    public void OnPeek()
    {
        animator.SetTrigger("ShowingTrigger");
        //animator.SetBool("isShowing", true);
        //Debug.Log("Event triggered!!");
        //this.gameObject.transform.rotation =Quaternion.Euler(0,0,180);
    }
    public void onPeekComplete()
    {
        //animator.SetFloat("Direction", -1f);
        //animator.SetBool("isShowing", false);
        //bool state = animator.GetBool("isShowing");
        //Debug.Log(state);
    }
    public void OnPopComplete()
    {
        Destroy(this.gameObject);
    }

}
