using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bow : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private GameObject trigger;
    public GameObject anakPanah;
    public float kekuatanLontaran;
    public Transform shotPoint;

    public GameObject titik;
    GameObject[] titik_titik;
    public int banyakTitik;
    public float jarakAntarTitik;
    public float cooldownTimer = 3f;
    private Vector2 direction;
    private bool shot;

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
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        angle = Mathf.Clamp(angle, -90f, 90f);
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        if(cooldownTimer < 3f)
        {
            cooldownTimer += Time.deltaTime;
        }

        // mengecek apakah klik kiri tetikus sudah ditekan
        if (Input.GetMouseButtonDown(1) && (cooldownTimer >= 3f))
        {
            player.Animator.Play("Rama_BowAttack");
            //Shoot();
            cooldownTimer = 0f;
        }

        // memunculkan titik trajektori
        for (int i = 0; i < banyakTitik; i++)
        {
            titik_titik[i].transform.position = PosisiTitik(i * jarakAntarTitik);
        }

        if (trigger.activeSelf)
        {
            if (shot)
            {
                return;
            }
            Shoot();  
            shot = true;
        } 
        else
        {
            shot = false;
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
        // Menghitung sudut rotasi
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        angle = Mathf.Clamp(angle, -90f, 90f);

        // Mendapatkan vektor rotasi berdasarkan sudut
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        Vector2 posisi = (Vector2)shotPoint.position +
            (direction.normalized * vektorKecepatan * t) + 
            0.5f * Physics2D.gravity * t * t;
        return posisi;
    }
}
