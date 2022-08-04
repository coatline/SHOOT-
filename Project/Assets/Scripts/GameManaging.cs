using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Sprites;

public class GameManaging : MonoBehaviour
{

    public GameObject Tank;
    public Vector2 eneSpawnPos;
    public Vector2 playerSpawnPos;
    public GameObject bullet;
    public int enemyCount;

    void Start()
    {

        //player
        var player = Instantiate(Tank);

        player.name = "Player";

        player.tag = "Player";

        player.transform.position = playerSpawnPos;

        player.AddComponent<PlayerMove>();

        var playerMovescript = player.GetComponent<PlayerMove>();

        playerMovescript.bullet = bullet;

        playerMovescript.jumpHeight = 300;

        //enemy
        for (int i = 0; i < enemyCount; i++)
        {
            var eneTank = Instantiate(Tank);

            eneTank.name = "Enemy";

            eneTank.tag = "Enemy";

            eneTank.transform.position = eneSpawnPos + new Vector2(i, 0);

            var sr = eneTank.GetComponent<SpriteRenderer>();

            sr.flipX = true;

            sr.color = new Color32(140, 140, 200, 255);

            eneTank.AddComponent<EnemyMove>();

            var enemyMoveScript = eneTank.GetComponent<EnemyMove>();

        }
    }
}
