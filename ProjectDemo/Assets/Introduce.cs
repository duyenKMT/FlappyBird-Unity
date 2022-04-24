using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Introduce : MonoBehaviour
{
    int[] data = new int[10];

    // Start is called before the first frame update
    void Start()
    {
        //Biến
        Debug.Log("Hí lô!");
        int a = Random.Range(10, 50);
        Debug.Log(a);
        //Mảng
        if (a < 30)
        {
            Debug.Log("Xuất mảng: ");
            for (int i = 0; i < data.Length; i++)
            {
                data[i] = Random.Range(1, 100);
            }
            for (int i = 0; i < data.Length; i++)
            {
                Debug.Log("" + data[i]);
            }
        }
        else
        {
            Debug.Log("Byee!");
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
