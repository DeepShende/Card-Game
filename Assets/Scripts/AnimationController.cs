using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    Card cardRef;

    private void Awake()
    {
        cardRef = GetComponentInParent<Card>();
        //cardRef = GetComponent<Card>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void onPeekAnimationComplete()
    {
        cardRef.onPeekComplete();
    }
    void OnPopAnimationComplete()
    {
        cardRef.OnPopComplete();
    }
    

}
