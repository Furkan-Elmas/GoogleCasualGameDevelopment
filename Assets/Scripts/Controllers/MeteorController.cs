using System.Collections;
using UnityEngine;

public class MeteorController : MeteorGenerator
{
    public MeteorController(GameObject meteor) : base(meteor) // Taking base constructor method from MeteorController
    {
    }

    public IEnumerator MeteorFallCoroutine()
    {
        while (true)
        {
            GameObject meteor = TakeMeteor();

            // Creating random positions
            float randomXZ = Random.Range(Random.Range(-100, -85), Random.Range(85, 100));
            float randomY = Random.Range(Random.Range(-20, -15), Random.Range(15, 20));

            Vector3 randomStartPosition = new Vector3(randomXZ, randomY, randomXZ);

            meteor.transform.position = randomStartPosition;

            Vector3 randomPlanetPosition = MeteorManager.Instance.PlanetPositions[Random.Range(0, MeteorManager.Instance.PlanetPositions.Length)].transform.position;

            Rigidbody meteorRigidbody = meteor.GetComponent<Rigidbody>();

            float destroyTime = 0;
            
            while (destroyTime < 3f) // Meteor will be disappear after 3 seconds 
            {
                destroyTime += Time.deltaTime;

                Vector3 direction = randomPlanetPosition - meteor.transform.position; // Meteor move direction
                meteorRigidbody.AddForce(direction.normalized * MeteorManager.Instance.MeteorSpeed);

                yield return new WaitForEndOfFrame();
            }

            meteor.SetActive(false);

            yield return new WaitForSeconds(3.0f);
        }
    }
}
