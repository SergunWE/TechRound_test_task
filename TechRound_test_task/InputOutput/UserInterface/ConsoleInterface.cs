using System;
using System.Collections;
using InputOutput;

namespace TechRound_test_task.UserInterface
{
    public class ConsoleInterface : IUserInterface
    {
        private static readonly string[] MainMenuItems =
        {
            "Установить персонажа",
            "Создать персонажа",
            "Экипировать оружие",
            "Экипировать защиту",
            "Экипировать бижутерию",
            "Подробная информация о персонаже",
            "Атаковать цель персонажем",
            "Выйти"
        };

        private const string CharacterNotSelectedError = "Персонаж не выбран";

        private ICharacter _currentCharacter;
        private bool _interfaceWork;

        public ConsoleInterface()
        {
            _interfaceWork = true;
        }

        public void Run()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            MainMenu();
        }

        private void MainMenu()
        {
            while (_interfaceWork)
            {
                PrintCurrentCharacter();
                for (int index = 0; index < MainMenuItems.Length; index++)
                {
                    Console.WriteLine($"{index + 1}. {MainMenuItems[index]}");
                }

                try
                {
                    switch (SetInputIntRange(ConsoleInput.GetIntValue(), 1, 7))
                    {
                        case 1:
                            SetCharacter();
                            break;
                        case 2:
                            CreateCharacter();
                            break;
                        case 3:
                            SetWeapon();
                            break;
                        case 4:
                            SetProtection();
                            break;
                        case 5:
                            SetJewelry();
                            break;
                        case 6:
                            ShowDetails();
                            break;
                        case 7:
                            AttackTarget();
                            break;
                        case 8:
                            _interfaceWork = false;
                            break;
                    }
                }
                catch (Exception e)
                {
                    ErrorWriter.PrintError(e);
                }
            }
        }

        private void SetCharacter()
        {
            if (CharacterPool.CharacterCount == 0)
            {
                throw new Exception("Невозможно выбрать персонажа, пока не создан хотя бы один");
            }

            Console.Clear();
            Console.WriteLine("Выберите персонажа");
            int i = 0;
            PrintBasedCharacters(ref i);
            PrintCustomCharacters(ref i);

            CharacterPool.SetCurrentCharacter(SetInputIntRange
                (ConsoleInput.GetIntValue(), 1, i) - 1);
            Console.Clear();
            Console.WriteLine($"Персонаж {CharacterPool.GetCurrentCharacter().CharacterName()} установлен");
        }

        private void CreateCharacter()
        {
            Console.Clear();
            Console.WriteLine("Выберите класс персонажа");
            int i = 0;
            PrintBasedCharacters(ref i);

            CharacterClass charClass =
                CharacterPool.BasedCharacters[SetInputIntRange(ConsoleInput.GetIntValue(), 1, i) - 1]
                    .GetCharacterClass();

            Console.Write("Укажите здоровье персонажа: ");
            int charHitPoint = SetInputIntRange(ConsoleInput.GetIntValue());

            Console.Write("Укажите ману персонажа: ");
            int charManaPoint = SetInputIntRange(ConsoleInput.GetIntValue());

            Console.Write("Укажите силу персонажа: ");
            int charPower = SetInputIntRange(ConsoleInput.GetIntValue());

            Console.Write("Укажите ловкость персонажа: ");
            int charAgility = SetInputIntRange(ConsoleInput.GetIntValue());

            Console.Write("Укажите интеллект персонажа: ");
            int charIntellect = SetInputIntRange(ConsoleInput.GetIntValue());

            CharacterPool.CreateCharacter(charClass, null, charHitPoint, charManaPoint,
                charPower, charAgility, charIntellect);

            Console.Clear();
            Console.WriteLine($"Персонаж {CharacterPool.CustomCharacters[^1].CharacterName()} создан");
        }

        private void SetWeapon()
        {
            UpdateCurrentCharacter();

            Console.Clear();
            Console.WriteLine("Выберете, каким оружием экипировать персонажа");

            int i = 0;
            foreach (var weapon in WeaponPool.BasedWeapons)
            {
                Console.WriteLine($"{++i}. {weapon.Name}");
            }

            // ArrayList enumValues = new ArrayList(Enum.GetValues(typeof(WeaponEnum)));
            // for (int i = 0; i < enumValues.Count; i++)
            // {
            //     Console.WriteLine($"{i + 1}. {enumValues[i]}");
            // }

            CharacterPool.SetWeapon(WeaponPool.BasedWeapons[SetInputIntRange(ConsoleInput.GetIntValue(),
                1, WeaponPool.BasedCount) - 1]);
            Console.Clear();
            Console.WriteLine($"Оружие {_currentCharacter.GetWeapon().Name} экипировано на персонажа " +
                              $"{_currentCharacter.CharacterName()}");
        }

        private void SetProtection()
        {
            UpdateCurrentCharacter();

            Console.Clear();
            Console.WriteLine("Выберите экипировку");

            int i = 0;
            foreach (var protection in ProtectionPool.BasedProtections)
            {
                Console.WriteLine($"{++i}. {protection.Name}");
            }

            CharacterPool.SetProtection(ProtectionPool.BasedProtections[SetInputIntRange(ConsoleInput.GetIntValue(),
                1, ProtectionPool.ProtectionCount) - 1]);
            Console.Clear();
            Console.WriteLine($"Предмет экипирован на персонажа {_currentCharacter.CharacterName()}");
        }

        private void SetJewelry()
        {
            UpdateCurrentCharacter();

            Console.Clear();
            Console.WriteLine("Выберите экипировку");

            int i = 0;
            foreach (var jewelry in JewelryPool.BasedJewelries)
            {
                Console.WriteLine($"{++i}. {jewelry.Name}");
            }

            CharacterPool.SetJewelry(JewelryPool.BasedJewelries[SetInputIntRange(ConsoleInput.GetIntValue(),
                1, ProtectionPool.ProtectionCount) - 1]);
            Console.Clear();
            Console.WriteLine($"Предмет экипирован на персонажа {_currentCharacter.CharacterName()}");
        }

        private void PrintCurrentCharacter()
        {
            ICharacter currentCharacter = CharacterPool.GetCurrentCharacter();
            Console.Write("Текущий персонаж: ");
            Console.WriteLine(currentCharacter == null ? "не установлен" : currentCharacter.CharacterName());
        }

        private void ShowDetails()
        {
            UpdateCurrentCharacter();

            Console.Clear();
            Console.WriteLine($"Имя: {_currentCharacter.CharacterName()}");
            Console.WriteLine($"Класс: {_currentCharacter.CharacterName()}");
            Console.WriteLine($"Жив: {(_currentCharacter.Alive() ? "да" : "нет")}");
            Console.WriteLine($"Здоровье: {_currentCharacter.HitPoints()}");
            Console.WriteLine($"Мана: {_currentCharacter.ManaPoints()}");
            Console.WriteLine($"Основные хар. персонажа: {_currentCharacter.GetMainFeatures().ToString()}");

            Weapon characterWeapon = _currentCharacter.GetWeapon();
            if (characterWeapon != null)
            {
                Console.WriteLine($"Оружие: {characterWeapon.Name}");
                Console.WriteLine(
                    $"Урон оружия основной/особый: {characterWeapon.Damage}/{characterWeapon.SpecialDamage}");
                Console.WriteLine($"Требования к оружию: {_currentCharacter.GetWeapon()?.RequiredFeatures.ToString()}");
            }

            foreach (var protection in _currentCharacter.GetProtection())
            {
                if (protection == null) continue;
                Console.WriteLine($"Название экипировки: {protection.Name}");
                Console.WriteLine($"Характеристика\n{protection.Features.ToString()}");
            }

            Console.WriteLine(
                $"Бижутерия: {(_currentCharacter.GetJewelry() != null ? _currentCharacter.GetJewelry().Name : "нет")}");
        }

        private void AttackTarget()
        {
            UpdateCurrentCharacter();
            if (CharacterPool.BasedCharacters.Count == 0 || NPCPoll.NPCs.Count == 0)
            {
                throw new Exception("Нет целей для атаки");
            }

            Console.Clear();
            Console.WriteLine("Выберите цель для атаки");
            ArrayList damaged = new ArrayList();
            int i = 0;
            foreach (var character in CharacterPool.BasedCharacters)
            {
                Console.WriteLine(
                    $"{i + 1}. {character.CharacterName()}{(character == _currentCharacter ? "(Вы)" : "")}");
                damaged.Add(character);
                i++;
            }

            foreach (var npc in NPCPoll.NPCs)
            {
                Console.WriteLine($"{i + 1}. {npc.Name}");
                damaged.Add(npc);
                i++;
            }

            object target = damaged[
                SetInputIntRange(ConsoleInput.GetIntValue(), 1, damaged.Count) - 1];
            Console.Clear();
            if (_currentCharacter is IDamageable attacker && attacker.Attack(target))
            {
                Console.WriteLine("Успешная атака");
            }
            else
            {
                Console.WriteLine("Атаки не произошло");
            }
        }

        private void PrintBasedCharacters(ref int i)
        {
            foreach (var character in CharacterPool.BasedCharacters)
            {
                Console.WriteLine($"{++i}. {character.CharacterName()}");
            }
        }

        private void PrintCustomCharacters(ref int i)
        {
            foreach (var character in CharacterPool.CustomCharacters)
            {
                Console.WriteLine($"{++i}. {character.CharacterName()}");
            }
        }

        private static int SetInputIntRange(int value, int minValue = int.MinValue, int maxValue = int.MaxValue)
        {
            if (value >= minValue && value <= maxValue) return value;
            throw new Exception("Неверный ввод");
        }

        private void UpdateCurrentCharacter()
        {
            _currentCharacter = CharacterPool.GetCurrentCharacter();
            if (_currentCharacter == null)
            {
                throw new Exception(CharacterNotSelectedError);
            }
        }
    }
}