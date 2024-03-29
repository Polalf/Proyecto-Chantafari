using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterBattle : MonoBehaviour
{
    //Variables
    [SerializeField] protected float life;

    //Properties
    public float Life => life;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected abstract void Death();
}
