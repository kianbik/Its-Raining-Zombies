using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoCAmeraRotation : MonoBehaviour
{
    public GameObject player;
    public int x;
    public int y;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player"); // The player
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y + x, player.transform.position.z - y);
    }
}
