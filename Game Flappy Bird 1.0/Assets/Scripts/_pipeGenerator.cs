using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _pipeGenerator : MonoBehaviour
{
    public GameObject pipePrefab;
    private float countdown; //biến đếm ngược
    public float timeDuration;
    public bool enabelGeneratePipe; //cho phep sinh ong

    //Hàm này đc gọi đúng 1 lần khi script đc tạo ra
    public void Awake()
    {
        countdown = 0;
        enabelGeneratePipe = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (enabelGeneratePipe == true)
        {
            countdown -= Time.deltaTime;    //Mỗi frame thì countdown-=1/FPS
                                          
            if (countdown <= 0)//Sinh ra ống
            {
                //Instantiate: Khởi tạo ra 1 GameObj
                Instantiate(pipePrefab, new Vector3(10, Random.Range(-1.2f, 2.1f), 0), Quaternion.identity);
                countdown = timeDuration;
            }
        }
    }
}
