using UnityEngine;
using TMPro;
public class GameUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI TextCoin;
    private float coinCount = 0;
    
    void Start()
    {
       
    }

  
    public void setCoin(float coin)
    {
        coinCount += coin;
        TextCoin.SetText($"{coinCount}");
    }
}
