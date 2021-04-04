using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public const int BLUE_TEAM = 1;
    public const int RED_TEAM = 2;

    public int health = 0;
    public int armor = 0;
    public int points = 0;

    public int team = RED_TEAM;

    private GameObject healthScore;
    private GameObject armorScore;
    private GameObject pointsScore;

    [SerializeField] private Transform player;
    [SerializeField] private Transform respawnPoint;

    CharacterController controller;

    void Start() {
        this.healthScore = GameObject.Find("HealthScore");
        this.armorScore = GameObject.Find("ArmorScore");
        this.pointsScore = GameObject.Find("PointsScore");

        this.controller = player.GetComponent<CharacterController>();

        if (this.team == BLUE_TEAM) {
            Destroy(gameObject.transform.GetChild(2).gameObject);
        } else {
            Destroy(gameObject.transform.GetChild(1).gameObject);
        }
    }

    void Update()
    {
        this.healthScore.GetComponent<Text>().text = "Health: " + this.health;
        this.armorScore.GetComponent<Text>().text = "Armor: " + this.armor;
        this.pointsScore.GetComponent<Text>().text = "Points: " + this.points;

        if (this.health == 0) {
            this.Respawn();
        }
    }

    public void Respawn()
    {
            controller.enabled = false;
            player.transform.position = this.respawnPoint.transform.position;;
            controller.enabled = true;

            this.health = 100;

            Physics.SyncTransforms();
    }
}
