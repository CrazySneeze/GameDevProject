using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Player player;
    void Start()
    {
        player = new Player(transform.position);
    }
}
