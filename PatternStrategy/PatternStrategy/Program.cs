using System;
using System.Collections.Generic;

namespace PatternStrategy
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            List<Character> chacacterlList = new List<Character>();

            bool isExit = true;


            
            while(isExit)
            {
                Console.WriteLine("Какого персонажа вы хотите создать?");
                Console.WriteLine("1. Короля \n2. Королеву\n3. Рыцаря\n4. Тролля");
                bool success = Int32.TryParse(Console.ReadLine(), out int n);
                if (success)
                {

                    switch (n)
                    {
                        case 1:
                            {
                                chacacterlList.Add(new Character());
                                chacacterlList[chacacterlList.Count - 1].SetCharacterBehavior(new KingBehavior());
                                break;
                            }
                        case 2:
                            {
                                chacacterlList.Add(new Character());
                                chacacterlList[chacacterlList.Count - 1].SetCharacterBehavior(new QueenBehavior());
                                break;
                            }
                        case 3:
                            {
                                chacacterlList.Add(new Character());
                                chacacterlList[chacacterlList.Count - 1].SetCharacterBehavior(new KnightBehavior());
                                break;
                            }
                        case 4:
                            {
                                chacacterlList.Add(new Character());
                                chacacterlList[chacacterlList.Count - 1].SetCharacterBehavior(new TrollBehavior());
                                break;
                            }
                        default:
                            isExit = false;
                            continue;
                    }
                }

                Console.WriteLine("Выберите оружие!");
                Console.WriteLine("1. Меч \n2. Лук\n3. Арбалет\n");

                success = Int32.TryParse(Console.ReadLine(), out int i);
                if (success)
                {
                    switch (i)
                    {
                        case 1:
                            {
                                chacacterlList[chacacterlList.Count - 1].SetWeapon(new Sword());
                                break;
                            }
                        case 2:
                            {
                                chacacterlList[chacacterlList.Count - 1].SetWeapon(new BowArrow());
                                break;
                            }
                        case 3:
                            {
                                chacacterlList[chacacterlList.Count - 1].SetWeapon(new Crossbow());
                                break;
                            }
                        default:
                            isExit = false;
                            continue;
                    }
                }

                Console.WriteLine("Выберите команду!");
                Console.WriteLine("1. Красные \n2. Синие\n3. Зеленые\n4. Желтые");

                success = Int32.TryParse(Console.ReadLine(), out int j);
                if (success)
                {
                    switch (j)
                    {
                        case 1:
                            {
                                chacacterlList[chacacterlList.Count - 1].SetTeam(new RedTeam()); ;
                                break;
                            }
                        case 2:
                            {
                                chacacterlList[chacacterlList.Count - 1].SetTeam(new BlueTeam());
                                break;
                            }
                        case 3:
                            {
                                chacacterlList[chacacterlList.Count - 1].SetTeam(new GreenTeam());
                                break;
                            }
                        case 4:
                            {
                                chacacterlList[chacacterlList.Count - 1].SetTeam(new YellowTeam());
                                break;
                            }
                        default:
                            isExit = false;
                            continue;
                    }
                }
            }

            
            foreach(var item in chacacterlList)
            {
                item.ChacterInfo();
            }
        }

        class Character
        {
            private CharacterBehavior _characterBehavior;
            private Weapon _weapon;
            private Team _team;
            
            public void SetCharacterBehavior(CharacterBehavior characterBehavior)
            {
                this._characterBehavior = characterBehavior;
            }

            public void SetWeapon(Weapon weapon)
            {
                this._weapon = weapon;
            }

            public void SetTeam(Team team)
            {
                this._team = team;
            }

            public void ChacterInfo()
            {
                this._characterBehavior.Behavior();
                this._weapon.WeaponBehavior();
                this._team.TeamBehavior();
            }
        }


        abstract class CharacterBehavior
        {
            public abstract void Behavior();
        }

        class KingBehavior : CharacterBehavior
        {
            public override void Behavior()
            {
                Console.WriteLine("King is ruling");
            }
        }

        class QueenBehavior : CharacterBehavior
        {
            public override void Behavior()
            {
                Console.WriteLine("Queen is crying");
            }
        }

        class KnightBehavior : CharacterBehavior
        {
            public override void Behavior()
            {
                Console.WriteLine("Knight is fighting");
            }
        }

        class TrollBehavior : CharacterBehavior
        {
            public override void Behavior()
            {
                Console.WriteLine("Troll is rumbling");
            }
        }



        abstract class Weapon
        {
            public abstract void WeaponBehavior();

        }

        class BowArrow : Weapon
        {
            public override void WeaponBehavior()
            {
                Console.WriteLine("With bow and arrow");
            }

        }

        class Sword : Weapon
        {
            public override void WeaponBehavior()
            {
                Console.WriteLine("With sword");
            }

        }

        class Crossbow : Weapon
        {
            public override void WeaponBehavior()
            {
                Console.WriteLine("With crossbow");
            }

        }

        abstract class Team
        {
            public abstract void TeamBehavior();
        }

        class RedTeam : Team
        {
            public override void TeamBehavior()
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Red Team");
                Console.ResetColor();
            }
        }

        class BlueTeam : Team
        {
            public override void TeamBehavior()
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Blue Team");
                Console.ResetColor();
            }
        }

        class GreenTeam : Team
        {
            public override void TeamBehavior()
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Green Team");
                Console.ResetColor();
            }
        }

        class YellowTeam : Team
        {
            public override void TeamBehavior()
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Yellow Team");
                Console.ResetColor();
            }
        }


    }
}
