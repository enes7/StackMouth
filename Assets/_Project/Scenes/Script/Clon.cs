using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clon : MonoBehaviour
{
    public float rihgt = -2;
    
    public float left = 2;
    public float middlee = 0;
    public GameObject eat,trap;
    public Transform character;
    // Start is called before the first frame update
    public void Clones()
    {
        int number = Random.Range(0, 100);
        CreateObj(eat, 0.5f);
        if (number > 0 && number < 300)
        {

            CreateObj(trap, 0.5f);
        }
        
    }

    public void CreateObj(GameObject obje, float top)
    {
        GameObject newclone = Instantiate(obje);
        int number = Random.Range(0, 100);

        if (number < 70)
        {
            newclone.transform.position = new Vector3(rihgt, top, character.position.z + 5f);


        }
        if (number > 70)
        {
            newclone.transform.position = new Vector3(left, top, character.position.z + 5f);
        }
        if (number < 30)
        {
            newclone.transform.position = new Vector3(middlee, top, character.position.z + 5f);
        }
    }
    void Start()
    {
        InvokeRepeating("Clones", 0, 3.0f);
    }
    // Update is called once per frame
    void Update()
    {
        
            
    }
}

