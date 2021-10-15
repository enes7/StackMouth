using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Current;

    public float limitX;
    public float runningspeed;
    private float _currentrunnigspeed;
    public float Xspeed;
    public bool startgm;
    
    public GameObject ridingMiddleMouth,Character,Panel,startbtn;
    public List<AddMouthMiddle> Middles;
    // Start is called before the first frame update
    void Start()
    {
        Current = this;
        _currentrunnigspeed = runningspeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (startgm == true)
        {
            float newX = 0;
            float toucDeltaX = 0;

            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                toucDeltaX = Input.GetTouch(0).deltaPosition.x / Screen.width;
            }
            else if (Input.GetMouseButton(0))
            {
                toucDeltaX = Input.GetAxis("Mouse X");
            }

            newX = transform.position.x + Xspeed * toucDeltaX * Time.deltaTime;
            newX = Mathf.Clamp(newX, -limitX, limitX);
            Vector3 newposition = new Vector3(newX, transform.position.y, transform.position.z + _currentrunnigspeed * Time.deltaTime);
            transform.position = newposition;
        }
        

    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Eat")
        {
           
            AddMiddle(0.1f);
            Destroy(other.gameObject);
        }
        else if (other.tag == "Shrink")
        {
            Panel.gameObject.SetActive(true);
            _currentrunnigspeed = 0;
            startgm = false;
            //Destroy(this.gameObject);
        }
    }
    private void OnTriggerStay(Collider other)
    {
       
    }
    public void AddMiddle(float value)
    {
        CreateMouthMiddle(value);


        if (Middles.Count == 0)
        {
            if (value > 0)
            {
                CreateMouthMiddle(value);
            }
            else
            {
                
                //gameover
            }
        }
        else
        {
            Middles[Middles.Count - 1].IncrementMouth(value);
        }
    }
    public void CreateMouthMiddle(float value)
    {
        AddMouthMiddle createMouth = Instantiate(ridingMiddleMouth, transform).GetComponent<AddMouthMiddle>();
        Middles.Add(createMouth);
        createMouth.IncrementMouth(value);
        //topMouth.transform.position = new Vector3(Character.transform.position.x - 0.4f, Character.transform.position.y + 2, Character.transform.position.z + 5.5f);

    }

    public void DestroyMouth(AddMouthMiddle mouth)
    {
        Middles.Remove(mouth);
        Destroy(mouth.gameObject);
    }

    public void RestartGame()
    {
        Panel.gameObject.SetActive(false);
        SceneManager.LoadScene("MainScene");
        startbtn.gameObject.SetActive(false);
    }
    public void StartGame()
    {
        startbtn.gameObject.SetActive(false);
        startgm = true;
    }
}
