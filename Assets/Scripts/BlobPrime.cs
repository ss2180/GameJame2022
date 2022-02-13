using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlobPrime : MonoBehaviour
{
    public static BlobPrime instance;
    
    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);
    }

    public int particleCount = 5;
    public GameObject particle;

    public float moveSpeed = 5f;
    public Rigidbody2D rb;

    public List<GameObject> particles = new List<GameObject>();

    Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < particleCount; i++)
        {
            Vector3 pos = gameObject.transform.position + new Vector3(Random.Range(-3.0f, 3.0f), Random.Range(-3.0f, 3.0f), 0);

            
            if (Physics.CheckSphere(pos, particle.transform.localScale.x / 2))
            {
                i--;
            }
            else
            {
                particles.Add(Instantiate(particle, pos, gameObject.transform.rotation));
            }
        }
        StartCoroutine(WaitAndUpdateColor());
    }

    IEnumerator WaitAndUpdateColor()
    {
        yield return new WaitForSeconds(0.25f);
        var skin = 2;
        if (PlayerPrefs.HasKey("Skin"))
            skin = PlayerPrefs.GetInt("Skin");

        SkinController.instance.ChangeSkin(skin);
    }

    public void SpawnParticle()
    {
        Vector3 pos = gameObject.transform.position;
        particles.Add(Instantiate(particle, pos, gameObject.transform.rotation));
    }


    // Update is called once per frame
    void Update()
    {
        //Input
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");

        if(Input.GetKeyDown(KeyCode.Space))
        {
            for (int i = 0; i < 250; i++)
            {
                SpawnParticle();
            }
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
