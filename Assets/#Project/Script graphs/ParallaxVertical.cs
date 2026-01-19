using UnityEngine;

public class ParallaxVertical : MonoBehaviour
{
    [SerializeField] private float scrollSpeed = 1f;
    [SerializeField] private bool infiniteScroll = true;

    private float spriteHeight; 

    void Start()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        if (sr != null)
        {
            // On récupère la hauteur du sprite au lieu de la largeur
            spriteHeight = sr.bounds.size.y;
        }
    }

    void LateUpdate()
    {
        // Application du mouvement sur l'axe Y
        transform.position += Vector3.down * scrollSpeed * Time.deltaTime;

        if (!infiniteScroll || spriteHeight <= 0f)
            return;

        if (transform.position.y <= -spriteHeight)
        {
            transform.position += Vector3.up * spriteHeight * 2f;
        }
    }
}