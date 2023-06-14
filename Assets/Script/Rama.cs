using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Rama : Player
{
    // Start is called before the first frame update

    void Start()
    {
        SetId(1);
        SetDescription("Karakter utama dari ini, memiliki senjata panah idk the name lmao");
        SetSpeed(0.05f);
        SetJumpDistance(10);
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame

    void Update()
    {
        base.Move();
        base.Jump();
    }
}
