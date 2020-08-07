using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    
    public Transform BG1, BG2;
    public float scrollspeed;

    private float bgWidth;//how wide is image


    // Start is called before the first frame update
    void Start()
    {
        bgWidth = BG1.GetComponent<SpriteRenderer>().sprite.bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    {
       BG1.position = new Vector3(BG1.position.x - (scrollspeed * Time.deltaTime), BG1.position.y, BG2.position.z);//Backgroud moving
       //BG2.position = new Vector3(BG2.position.x - (scrollspeed * Time.deltaTime), BG2.position.y, BG1.position.z);
       BG2.position -= new Vector3(scrollspeed * Time.deltaTime, 0f, 0f);

       if(BG1.position.x < -bgWidth - 1)
       {
            BG1.position += new Vector3(bgWidth * 2f, 0f, 0f);//For Background 1
       }
        if (BG2.position.x < -bgWidth - 1)
        {
            BG2.position += new Vector3(bgWidth * 2f, 0f, 0f);//For Background 2
        }

    }
}
