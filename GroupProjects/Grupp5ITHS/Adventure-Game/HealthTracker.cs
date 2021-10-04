namespace Adventure_Game
{
    internal class HealthTracker
    {
        private int currentHealth;

        public HealthTracker(int startingHealth)
        {
            currentHealth = startingHealth;
        }

        public bool PlayerIsDead()
        {
            if (currentHealth == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void TakeDamage(int damage)
        {
            currentHealth -= damage;
        }

        public string GetCurretnHealthString()
        {
            string healthString = " Current player health is: " + currentHealth.ToString();
            return healthString;
        }
    }
}