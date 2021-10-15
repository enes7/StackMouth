using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopMouthScr : MonoBehaviour
{
    public GameObject Character;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Character.transform.position.x-0.5f, Character.transform.position.y+2, Character.transform.position.z+5.5f);
    }
}
