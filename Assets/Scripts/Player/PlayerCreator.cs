using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCreator : MonoBehaviour
{
    [SerializeField] private Player _player;

    void Start()
    {
        Instantiate(_player, new Vector3(-7,-0.38f,0), Quaternion.identity);
        
    }

    
}
