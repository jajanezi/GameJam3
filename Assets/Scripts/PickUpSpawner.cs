using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpSpawner : MonoBehaviour
{
    public Transform prefabToSpawn_1;
    public Transform prefabToSpawn_2;
    public Transform prefabToSpawn_3;
    public Transform prefabToSpawn_4;

    private float pick;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                float xpos = transform.position.x + i * 5;
                float zpos = transform.position.z + j * 5;
                pick = Random.Range(0f, 4f);

                if (pick < 1)
                {
                    Object instanceObj = Instantiate(prefabToSpawn_1, new Vector3(xpos, 0.85f, zpos), Quaternion.identity);
                }
                else if ((pick >= 1) && (pick < 2))
                {
                    Object instanceObj = Instantiate(prefabToSpawn_2, new Vector3(xpos, 0.85f, zpos), Quaternion.identity);
                }
                else if ((pick >= 2) && (pick < 3))
                {
                    Object instanceObj = Instantiate(prefabToSpawn_3, new Vector3(xpos, 0.85f, zpos), Quaternion.identity);
                }else 
                {
                    Object instanceObj = Instantiate(prefabToSpawn_4, new Vector3(xpos, 0.85f, zpos), Quaternion.identity);
                }
                //Debug.Log(Random.Range(0f, 3f));
                //Object instanceObj = Instantiate(prefabToSpawn_1, new Vector3(xpos, 0.85f, zpos), Quaternion.identity);

            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
