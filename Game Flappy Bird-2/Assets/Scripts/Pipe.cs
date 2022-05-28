using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() //gọi trên FPS
    {
        Move();
    }
    //Di chuyển ống từ phải -> trái
    private void Move()
    {
        //Vector3 gồm 3 tham số x,y,z
        //Time.deltaTime=1/FPS
        transform.position += Vector3.left * speed*Time.deltaTime;//(-1,0,0)-->trục x -1 giá trị qua mỗi lần gọi
    }
}
