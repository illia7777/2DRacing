using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float TopCamBorder { get; private set; }
    public float BottomCamBorder { get; private set; }

    private void Start()
    {
        TopCamBorder = Camera.main.ViewportToWorldPoint(new Vector2(0,0)).y;
        BottomCamBorder = Camera.main.ViewportToWorldPoint(new Vector2(0, 1)).y;
    }

    private void Update()
    {

    }
}
   
