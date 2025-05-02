using System.Collections;
using UnityEngine;

public class GameSpawner : MonoBehaviour
{
    CarSpawner carSpawner;
    [SerializeField] float SpawnInterval = 2f;
    [SerializeField] float SpeedCar = 10f;
    void Start()
    {
        carSpawner = GetComponent<CarSpawner>();
        StartCoroutine(SpawnCars());
        
    }
    IEnumerator SpawnCars()
    {
        while (true)
        {
            carSpawner.AddCar(SpeedCar);
            yield return new WaitForSeconds(SpawnInterval);
        }
    }


}
