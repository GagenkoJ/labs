using System;
using System.Collections.Generic;

namespace MageBattleLaba5
{
    public interface ISpell
    {
        string Name { get; }
        void Cast(Mage caster, Mage target);
    }
    
    public abstract class Mage
    {
        public string Name { get; set; }
        public int MagicLevel { get; set; }
        public int Health { get; set; }
        public List<ISpell> Spells { get; set; }

        public delegate void MageActionEventHandler(object sender, MageActionEventArgs e);
        public event MageActionEventHandler OnAction;

        public Mage(string name, int magicLevel, int health)
        {
            Name = name;
            MagicLevel = magicLevel;
            Health = health;
            Spells = new List<ISpell>();
        }

        public abstract void Attack(Mage target, ISpell spell);
        public abstract void Defend();

        public void TakeDamage(int damage)
        {
            Health -= damage;
            if (Health < 0) Health = 0;
            PerformAction($"{Name} отримав {damage} шкоди.");
        }

        public bool IsAlive()
        {
            return Health > 0;
        }

        public void PerformAction(string actionDescription)
        {
            OnAction?.Invoke(this, new MageActionEventArgs(actionDescription));
        }
    }

    public class MageActionEventArgs : EventArgs
    {
        public string ActionDescription { get; }

        public MageActionEventArgs(string actionDescription)
        {
            ActionDescription = actionDescription;
        }
    }

    public class FireMage : Mage
    {
        public FireMage(string name) : base(name, 100, 100)
        {
            Spells.Add(new Fireball());
            Spells.Add(new FireShield());
        }

        public override void Attack(Mage target, ISpell spell)
        {
            PerformAction($"{Name} атакує {target.Name} використовуючи {spell.Name}!");
            spell.Cast(this, target);
        }

        public override void Defend()
        {
            PerformAction($"{Name} захищається!");
        }
    }

    public class WaterMage : Mage
    {
        public WaterMage(string name) : base(name, 100, 100)
        {
            Spells.Add(new WaterSplash());
            Spells.Add(new WaterShield());
        }

        public override void Attack(Mage target, ISpell spell)
        {
            PerformAction($"{Name} атакує {target.Name} використовуючи {spell.Name}!");
            spell.Cast(this, target);
        }

        public override void Defend()
        {
            PerformAction($"{Name} захищається!");
        }
    }

    public class EarthMage : Mage
    {
        public EarthMage(string name) : base(name, 100, 100)
        {
            Spells.Add(new Earthquake());
            Spells.Add(new EarthShield());
        }

        public override void Attack(Mage target, ISpell spell)
        {
            PerformAction($"{Name} атакує {target.Name} використовуючи {spell.Name}!");
            spell.Cast(this, target);
        }

        public override void Defend()
        {
            PerformAction($"{Name} захищається!");
        }
    }

    public class Fireball : ISpell
    {
        public string Name => "Fireball";

        public void Cast(Mage caster, Mage target)
        {
            int damage = caster.MagicLevel / 2;
            caster.PerformAction($"{target.Name} отримує {damage} шкоди від {Name}!");
            target.TakeDamage(damage);
        }
    }

    public class FireShield : ISpell
    {
        public string Name => "Fire Shield";

        public void Cast(Mage caster, Mage target)
        {
            int shield = caster.MagicLevel / 4;
            caster.PerformAction($"{caster.Name} захищений на {shield} від {Name}!");
            caster.TakeDamage(-shield);
        }
    }

    public class WaterSplash : ISpell
    {
        public string Name => "Water Splash";

        public void Cast(Mage caster, Mage target)
        {
            int damage = caster.MagicLevel / 2;
            caster.PerformAction($"{target.Name} отримує {damage} шкоди від {Name}!");
            target.TakeDamage(damage);
        }
    }

    public class WaterShield : ISpell
    {
        public string Name => "Water Shield";

        public void Cast(Mage caster, Mage target)
        {
            int shield = caster.MagicLevel / 4;
            caster.PerformAction($"{caster.Name} захищений на {shield} від {Name}!");
            caster.TakeDamage(-shield);
        }
    }

    public class Earthquake : ISpell
    {
        public string Name => "Earthquake";

        public void Cast(Mage caster, Mage target)
        {
            int damage = caster.MagicLevel / 2;
            caster.PerformAction($"{target.Name} отримує {damage} шкоди від {Name}!");
            target.TakeDamage(damage);
        }
    }

    public class EarthShield : ISpell
    {
        public string Name => "Earth Shield";

        public void Cast(Mage caster, Mage target)
        {
            int shield = caster.MagicLevel / 4;
            caster.PerformAction($"{caster.Name} захищений на {shield} від {Name}!");
            caster.TakeDamage(-shield);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Mage player1 = CreateMage("Гравець 1");
            Mage player2 = CreateMage("Гравець 2");

            player1.OnAction += HandleMageAction;
            player2.OnAction += HandleMageAction;

            Console.WriteLine("Бій починається!");

            while (player1.IsAlive() && player2.IsAlive())
            {
                PlayerTurn(player1, player2);
                if (!player2.IsAlive())
                {
                    Console.WriteLine($"{player1.Name} виграв!");
                    break;
                }

                PlayerTurn(player2, player1);
                if (!player1.IsAlive())
                {
                    Console.WriteLine($"{player2.Name} виграв!");
                    break;
                }
            }

            Console.WriteLine("Гра закінчена!");
        }

        static Mage CreateMage(string playerName)
        {
            Console.WriteLine($"{playerName}, оберіть стихію магії:");
            Console.WriteLine("1. Вогняний маг");
            Console.WriteLine("2. Водний маг");
            Console.WriteLine("3. Земляний маг");

            Mage mage = null;
            switch (Console.ReadLine())
            {
                case "1":
                    mage = new FireMage(playerName);
                    break;
                case "2":
                    mage = new WaterMage(playerName);
                    break;
                case "3":
                    mage = new EarthMage(playerName);
                    break;
                default:
                    Console.WriteLine("Невірний вибір, оберіть ще раз.");
                    mage = CreateMage(playerName);
                    break;
            }
            return mage;
        }

        static void PlayerTurn(Mage attacker, Mage defender)
        {
            Console.WriteLine($"{attacker.Name}, оберіть дію:");
            Console.WriteLine("1. Атака");
            Console.WriteLine("2. Захист");

            switch (Console.ReadLine())
            {
                case "1":
                    ChooseSpell(attacker, defender);
                    break;
                case "2":
                    attacker.Defend();
                    break;
                default:
                    Console.WriteLine("Невірний вибір, оберіть ще раз.");
                    PlayerTurn(attacker, defender);
                    break;
            }
        }

        static void ChooseSpell(Mage attacker, Mage defender)
        {
            Console.WriteLine("Оберіть закляття:");
            for (int i = 0; i < attacker.Spells.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {attacker.Spells[i].Name}");
            }

            int spellIndex;
            if (int.TryParse(Console.ReadLine(), out spellIndex) && spellIndex > 0 && spellIndex <= attacker.Spells.Count)
            {
                attacker.Attack(defender, attacker.Spells[spellIndex - 1]);
            }
            else
            {
                Console.WriteLine("Невірний вибір, оберіть ще раз.");
                ChooseSpell(attacker, defender);
            }
        }

        static void HandleMageAction(object sender, MageActionEventArgs e)
        {
            Console.WriteLine(e.ActionDescription);
        }
    }
}
