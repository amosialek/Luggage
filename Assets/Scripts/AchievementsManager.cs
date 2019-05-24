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
        public Sprite stars0;
        public Sprite stars1;
        public Sprite stars2;
        public Sprite stars3;

        private int GetStars()
        {
            int stars = 0;
            if (collectedItems >= ItemsToCollect)
                stars++;
            if (enemiesEaten >= EnemiesToEat)
                stars++;
            if (deaths == 0)
                stars++;
            return stars;
        }

        public Sprite GetStarsToBeShown()
        {
            int stars = GetStars();
            switch (stars)
            {
                case 0: return stars0;
                case 1: return stars1;
                case 2: return stars2;
                case 3: return stars3;
            }
            return null;
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
