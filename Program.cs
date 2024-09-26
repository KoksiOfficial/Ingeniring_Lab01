using Heroes01.GameEngine;

var heroes = GameController.Start();
var hero1 = heroes.hero1;
var hero2 = heroes.hero2;

int attackCounter = 0;

while (hero1.alive && hero2.alive)
{
    if (attackCounter % 2 == 0)
    {
        GameController.DisplayCurrentStats(hero1);
        GameController.Attack(atacker: hero1, defender: hero2);
    }
    else
    {
        GameController.DisplayCurrentStats(hero2);
        GameController.Attack(atacker: hero2, defender: hero1);
    }
    attackCounter++;
}

if (hero1.alive)
    GameController.DeathAnnouncer(winner: hero1, looser: hero2);
else
    GameController.DeathAnnouncer(winner: hero2, looser: hero1);

Console.ReadKey();