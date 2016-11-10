using UnityEngine;
using System.Collections;

public class ItemController2 : MonoBehaviour {

    public GameObject carPrefab;
    public GameObject coinPrefab;
    public GameObject conePrefab;
    private int startpos = -160;
    private int goalpos = 120;
    private float posRange = 3.4f;
    private GameObject unitychan;
    private int startItem = -210;   //startposから-50した値を入れる。
    private int distance = 50;  //ユニティちゃんから見て？m先にアイテムを生成するか、その値を入れる。

    // Use this for initialization
    void Start () {
        this.unitychan = GameObject.Find("unitychan");        
    }
	
	// Update is called once per frame
	void Update () {
        if(startpos - distance < unitychan.transform.position.z && unitychan.transform.position.z < goalpos - distance)
        {
            if (startItem < unitychan.transform.position.z)
            {
                int num = Random.Range(0, 10);
                if (num <= 1)
                {
                    for (float j = -1; j <= 1; j += 0.4f)
                    {
                        GameObject cone = Instantiate(conePrefab) as GameObject;
                        cone.transform.position = new Vector3(4 * j, cone.transform.position.y, startItem + distance);
                        
                    }

                    startItem += 15;
                }
                else
                {
                    for (int j = -1; j < 2; j++)
                    {
                        int item = Random.Range(1, 11);
                        int offsetZ = Random.Range(-5, 6);
                        if (1 <= item && item <= 6)
                        {
                            GameObject coin = Instantiate(coinPrefab) as GameObject;
                            coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, startItem + distance + offsetZ);
                        }
                        else if (7 <= item && item <= 9)
                        {
                            GameObject car = Instantiate(carPrefab) as GameObject;
                            car.transform.position = new Vector3(posRange * j, car.transform.position.y, startItem + distance + offsetZ);
                        }

                    }

                    startItem += 15;
                }

            }
        }
        


    }
}
