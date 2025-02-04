using UnityEngine;

namespace SpaceMobile
{
    public class AbilitiesSpawner : Spawner
    {
        [SerializeField] private CollectableAbility[] _Abilities;

        protected override void Spawn()
        {
            if (startTimer <= startDelay)
            {
                startTimer += Time.deltaTime;
                return;
            }

            timeAfterLastSpawn += Time.deltaTime;

            if (timeAfterLastSpawn >= spawnDelay)
            {
                Vector2 spawnPositon = new Vector2(Random.Range(-scatterInX, scatterInX), transform.position.y);

                CollectableAbility ability = _Abilities[Random.Range(0, _Abilities.Length)];

                Instantiate(ability, spawnPositon, Quaternion.identity, transform);

                timeAfterLastSpawn = 0;
            }
        }
    }
}
