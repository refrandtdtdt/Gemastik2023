using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour
{
    [SerializeField] private Player player;
    public GameObject anakPanah;
    public float kekuatanLontaran;
    public Transform shotPoint;

    public GameObject titik;
    GameObject[] titik_titik;
    public int banyakTitik;
    public float jarakAntarTitik;
    private Vector2 direction;

    // Start is called before the first frame update
    void Start()
    {
        titik_titik = new GameObject[banyakTitik];
        for (int i = 0; i < banyakTitik; i++)
        {
            titik_titik[i] = Instantiate(titik, shotPoint.position, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 bowPos = transform.position;
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        direction = mousePos - bowPos;

        if (player.MadepMana == Hadap.Kiri)
        {
            direction *= -1;
        }
        transform.right = direction;

        // mengecek apakah klik kiri tetikus sudah ditekan
        if (Input.GetMouseButtonDown(1))
        {
            Shoot();
        }

        // memunculkan titik trajektori
        for (int i = 0; i < banyakTitik; i++)
        {
            titik_titik[i].transform.position = PosisiTitik(i * jarakAntarTitik);
        }
    }

    void Shoot()
    {
        float vektorKecepatan = kekuatanLontaran;
        GameObject panahBaru = Instantiate(anakPanah, shotPoint.position, shotPoint.rotation);
        int damage = panahBaru.GetComponent<Arrow>().Damage = (player.AttackPower * 3)/2;
        Debug.Log("Memunculkan Panah, Kerusakan = " + damage);
        
        if (player.MadepMana == Hadap.Kiri)
            vektorKecepatan *= -1;
        panahBaru.GetComponent<Rigidbody2D>().velocity = transform.right * vektorKecepatan;
        
    }

    Vector2 PosisiTitik(float t)
    {
        float vektorKecepatan = kekuatanLontaran;
        if (player.MadepMana == Hadap.Kiri)
        {
            vektorKecepatan *= -1;
        }
        Vector2 posisi = (Vector2)shotPoint.position + 
            (direction.normalized * vektorKecepatan * t) + 
            0.5f * Physics2D.gravity * t * t;
        return posisi;
    }
}
