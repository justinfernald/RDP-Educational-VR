using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundGenerator : MonoBehaviour
{
    public static HashSet<Vector2> placements;
    public Vector2 groundSize;
    public Vector2 location;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("bruh moment");
        for (int i = -1; i <= 1; i++)
        {
            for (int j = -1; j <= 1; j++)
            {
                if (i == 0 && j == 0) continue;
                if (placements.Contains(location + new Vector2(i, j))) continue;
                placements.Add(location + new Vector2(i, j));
                GameObject nGO = Instantiate(gameObject);
                nGO.transform.position += new Vector3(groundSize.x * i, groundSize.y * j, 0);
            }
        }
        
    }
}
