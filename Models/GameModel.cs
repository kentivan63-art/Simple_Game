namespace GameApp.Models
{
    public class GameModel
    {
        public int PlayerHP { get; set; } = 100;
        public int EnemyHP { get; set; } = 100;
        public string Message { get; set; } = "A wild monster appears! What will you do?";
        public bool IsGameOver => PlayerHP <= 0 || EnemyHP <= 0;

        public void Attack()
        {
            // Player attacks monster
            int playerDmg = new Random().Next(10, 20);
            EnemyHP -= playerDmg;
            
            if (EnemyHP <= 0)
            {
                EnemyHP = 0;
                Message = $"You dealt {playerDmg} damage. The monster is defeated!";
                return;
            }

            // Monster attacks back
            int enemyDmg = new Random().Next(5, 15);
            PlayerHP -= enemyDmg;
            
            if (PlayerHP <= 0)
            {
                PlayerHP = 0;
                Message = $"The monster hit you for {enemyDmg}. You have fallen...";
            }
            else
            {
                Message = $"You hit for {playerDmg}. Monster hits you back for {enemyDmg}!";
            }
        }

        public void Heal()
        {
            int healAmount = 20;
            PlayerHP += healAmount;
            if (PlayerHP > 100) PlayerHP = 100;

            int enemyDmg = new Random().Next(5, 15);
            PlayerHP -= enemyDmg;

            Message = $"You healed for {healAmount}, but the monster attacked you for {enemyDmg}!";
        }
    }
}