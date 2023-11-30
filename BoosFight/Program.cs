namespace BoosFight
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var hero = new GameCharacter("Hero", 100, 40, 20);
            var boss = new GameCharacter("Boss", 400, 10, 30);

            bool winCond = false;
            bool loseCond = false;
            int dmg;
            int dmgBoss;
            bool noobieSave = true;
            do
            {
                Console.WriteLine($"Hp: {hero.HP}    Stamina: {hero.Stamina}   Strengh: {hero.Dmg}");

                Console.WriteLine();
                //Player Actions
                Console.WriteLine("1. Attack   2. Recharge");
                var userInp = Console.ReadLine();

                if (userInp == "1")
                {
                    dmg = hero.Attack();
                    if (dmg == -1 && noobieSave)
                    {
                        //failsafe
                        Console.WriteLine("You are out of stamina");
                        Console.WriteLine("Automatic refil");
                        hero.Stamina = hero.StaminaMax;
                        noobieSave = false;
                    }
                    else if (dmg == -1 && !noobieSave)
                    {
                        dmg = 0;
                        Console.WriteLine($"You've dealt {dmg}dmg to the boss! Boss has {boss.HP}hp left!!");
                    }
                    else
                    {
                        boss.HP -= dmg;
                        Console.WriteLine($"You've dealt {dmg}dmg to the boss! Boss has {boss.HP}hp left!!");
                    }
                }
                else if (userInp == "2")
                {
                    if (hero.Stamina == hero.StaminaMax)
                    {
                        Console.WriteLine("Congrats, you have just wasted a turn, your stamina was already max :'");
                    }
                    else
                    {
                        hero.Stamina = hero.StaminaMax;
                        Console.WriteLine("You feel well rested....");
                    }
                }
                //
                //Boss from here on

                if (boss.HP <= 0) winCond = true;
                else
                {
                    Thread.Sleep(1000);
                    if (boss.Stamina == 0)
                    {
                        boss.Recharge();
                        Console.WriteLine("Boss rests...");
                    }
                    else
                    {
                        dmgBoss = boss.Attack();
                        hero.HP -= dmgBoss;
                        Console.WriteLine("Boss attacks you for {0}, you have {1}Hp left...", dmgBoss, hero.HP);
                    }
                }

                if (hero.HP <= 0) loseCond = true;
                Thread.Sleep(2000);
                Console.Clear();
            } while (!winCond && !loseCond);

            if (winCond)
            {
                Console.WriteLine("Congrats you won!");
            }
            else Console.WriteLine("Game over");
        }
    }
}