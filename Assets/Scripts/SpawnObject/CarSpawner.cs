using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    [SerializeField] Transform[] transformSpawner;
    [SerializeField] GameObject[] PrefabCar;
    public void AddCar(float speed)
    {
        var random = Random.Range(0, transformSpawner.Length);
        var random_car = Random.Range(0, PrefabCar.Length);
        GameObject car = Instantiate(PrefabCar[random_car], transformSpawner[random].position, Quaternion.identity) as GameObject;
               

            
        SpriteRenderer carSprite = car.GetComponent<SpriteRenderer>();
       


        car.transform.position = new Vector3(car.transform.position.x, car.transform.position.y, -2f);
        if (car != null )
        {
            CarMove carMove = car.GetComponent<CarMove>();
            if ( carMove != null )
            {
                carMove.speed = speed;
            }
        }

    }
   
    
}
