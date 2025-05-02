using UnityEngine;

public class Road : MonoBehaviour
{
    [SerializeField] private GameObject RoadTop, RoadBottom;
    GameManager gm;
    [SerializeField] float speed = 5f;
    private float _roadHeight;
    
    void Start()
    {
        gm = FindFirstObjectByType<GameManager>();
        _roadHeight = RoadTop.GetComponent<SpriteRenderer>().bounds.size.y;

    }

    
    void Update()
    {
        MoveRoadDown();
        if (RoadTop.transform.position.y + _roadHeight / 2 < gm.BottomCamBorder)
        {
            MoveRoadUp();
        }
    }
    void MoveRoadDown()
    {
        transform.position += Vector3.down * speed * Time.deltaTime;
    }
    void MoveRoadUp()
    {
        RoadBottom.transform.position = new Vector3(
            RoadBottom.transform.position.x,
            RoadTop.transform.position.y + _roadHeight,
            RoadBottom.transform.position.z
        );
        (RoadTop, RoadBottom) = (RoadBottom, RoadTop);


    }
}
