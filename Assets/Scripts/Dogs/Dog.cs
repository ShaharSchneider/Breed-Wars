using UnityEngine;

public abstract class Dog
{
    protected int health;
    protected int attack;
    public GameObject gameObject;

    public Dog(string dogName, int health, int attack)
    {
        this.health = health;
        this.attack = attack;

        createDogGameObject(dogName);
        createHealthGameObject();
        createAttackGameObject();
    }

    private void createDogGameObject(string dogName)
    {
        Texture2D dogTexture = Resources.Load<Texture2D>("Characters/" + dogName);
        Sprite dogSprite = Sprite.Create(dogTexture, new Rect(0,0, dogTexture.width, dogTexture.height), Vector2.zero);

        gameObject = new GameObject(dogName);
        gameObject.AddComponent<SpriteRenderer>().sprite = dogSprite;
        gameObject.AddComponent<BoxCollider2D>();
        gameObject.AddComponent<DragObject>();
    }

    private void createHealthGameObject()
    {
        GameObject heart = new GameObject("heart");
        heart.transform.parent = gameObject.transform;
        heart.transform.position = new Vector2(3f, -0.5f);

        Texture2D heartTexture = Resources.Load<Texture2D>("heart");
        Sprite heartSprite = Sprite.Create(heartTexture, new Rect(0, 0, heartTexture.width, heartTexture.height), Vector2.zero);
        SpriteRenderer sr = heart.AddComponent<SpriteRenderer>();
        sr.sprite = heartSprite;
        
        //TODO: change picture size
        sr.transform.localScale = new Vector2(0.1f, 0.1f);

        GameObject heartCount = new GameObject("heartCount");
        heartCount.transform.parent = gameObject.transform;
        TextMesh textMesh = heartCount.AddComponent<TextMesh>();
        textMesh.text = health.ToString();
        textMesh.anchor = TextAnchor.MiddleCenter;
        textMesh.fontSize = 55;

        heartCount.transform.localScale = new Vector2(0.1f, 0.1f);
        heartCount.transform.position = new Vector2(2.85f, -0.27f);
    }

    private void createAttackGameObject()
    {
        GameObject sword = new GameObject("sword");
        sword.transform.parent = gameObject.transform;
        sword.transform.position = new Vector2(1.4f, -0.5f);

        Texture2D swordTexture = Resources.Load<Texture2D>("sword");
        Sprite swordSprite = Sprite.Create(swordTexture, new Rect(0, 0, swordTexture.width, swordTexture.height), Vector2.zero);
        SpriteRenderer sr = sword.AddComponent<SpriteRenderer>();
        sr.sprite = swordSprite;

        //TODO: change picture size
        sr.transform.localScale = new Vector2(0.2f, 0.2f);

        GameObject swordCount = new GameObject("swordCount");
        swordCount.transform.parent = gameObject.transform;
        TextMesh textMesh = swordCount.AddComponent<TextMesh>();
        textMesh.text = attack.ToString();
        textMesh.anchor = TextAnchor.MiddleCenter;
        textMesh.fontSize = 55;

        swordCount.transform.localScale = new Vector2(0.1f, 0.1f);
        swordCount.transform.position = new Vector2(1.2f, -0.27f);
    }
}
