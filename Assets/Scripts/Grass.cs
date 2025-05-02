using UnityEngine;

public class Grass : MonoBehaviour
{
    [SerializeField] private GameObject GrassTop, GrassBottom;
    GameManager gm;
    [SerializeField] float speed = 5f;
    private float _grassHeight;

    void Start()
    {
        gm = FindFirstObjectByType<GameManager>();
        _grassHeight = GrassTop.GetComponent<SpriteRenderer>().bounds.size.y;

    }


    void Update()
    {
        MoveGrassDown();
        if (GrassTop.transform.position.y + _grassHeight / 2 < gm.BottomCamBorder)
        {
            MoveGrassUp();
        }
    }
    void MoveGrassDown()
    {
        transform.position += Vector3.down * speed * Time.deltaTime;
    }
    void MoveGrassUp()
    {
        GrassBottom.transform.position = new Vector3(
            GrassBottom.transform.position.x,
            GrassTop.transform.position.y + _grassHeight,
            GrassBottom.transform.position.z
        );
        (GrassTop, GrassBottom) = (GrassBottom, GrassTop);


    }
}