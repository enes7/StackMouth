using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddMouthMiddle : MonoBehaviour
{
    private bool _filled;
    public float _value;
    public static AddMouthMiddle Currenttwo;
    

    public void Start()
    {
        Currenttwo = this;
    }
    public void IncrementMouth(float value)
    {
        //if (PlayerController.Current.obstacle == true)
        //{
            
        //    PlayerController.Current.DestroyMouth(this);

        //}
        _value += value;
        if (_value > 1)
        {
            float leftValue = _value - 1;
            int muthCount = PlayerController.Current.Middles.Count;
            transform.position = new Vector3(transform.position.x, 0.5f * (muthCount - 1) + 0.2F , transform.position.z); //2f * (muthCount - 1) + 0.2F * _value
            //transform.localScale = new Vector3(0.5f, transform.lossyScale.y, 0.5f);
            PlayerController.Current.CreateMouthMiddle(leftValue);
            

        }
        else if (_value < 0)
        {
            PlayerController.Current.DestroyMouth(this);
        }
        else
        {
            
            int muthCount = PlayerController.Current.Middles.Count;
            transform.localPosition = new Vector3(transform.localPosition.x, 0.5f * (muthCount - 1) + 0.2F * _value, transform.localPosition.z);
            //transform.localScale = new Vector3(0.5f * _value, transform.lossyScale.y, 0.5f * _value);
        }
    }
}
