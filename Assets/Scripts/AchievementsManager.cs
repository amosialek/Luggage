using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public class AchievementsManager : MonoBehaviour
    {
        private int collectedItems;
        private int enemiesEaten;
        private int deaths;
        public int ItemsToCollect;
        public int EnemiesToEat;
        public GameManager gameManager;
        

        private int GetStars()
        {
            int stars = 0;
            if (collectedItems >= ItemsToCollect)
                stars++;
            if (enemiesEaten >= EnemiesToEat)
                stars++;
            if (deaths > 0)
                stars++;
            return stars;
        }

        public void CollectItem()
        {
            collectedItems++;
        }
        public void EatEnemy()
        {
            enemiesEaten++;
        }
        public void Die()
        {
            deaths++;
        }
    }
}
