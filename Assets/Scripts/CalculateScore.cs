using UnityEngine;
using TMPro; 

public class ScoreManager : MonoBehaviour
{
    public TMP_Text myText; 
    void Update()
    {
      
        myText.text = "" + Coin.coinsCount;
    }
}