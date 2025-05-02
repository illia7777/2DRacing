using UnityEngine;

public class CarMove : MonoBehaviour
{
    public float speed {  get; set; }
    
    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);

    }
}
