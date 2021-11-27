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
    }

    private void createDogGameObject(string dogName)
    {
        Texture2D dogTexture = Resources.Load<Texture2D>(dogName);
        Sprite dogSprite = Sprite.Create(dogTexture, new Rect(0,0, dogTexture.width, dogTexture.height), Vector2.zero);

        gameObject = new GameObject(dogName);
        gameObject.AddComponent<SpriteRenderer>().sprite = dogSprite;
    }
}
