using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using InputOutput;
using TechRound_test_task.Damage;

namespace TechRound_test_task.UserInterface
{
    public class ConsoleInterface : IUserInterface
    {
        private readonly CharacterPool _characterPool;
        private ICharacter _currentCharacter;
        private readonly NPCPoll _npcPoll;
        private bool _interfaceWork;

        public ConsoleInterface()
        {
            _characterPool = new CharacterPool();
            _npcPoll = new NPCPoll();
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
                Console.WriteLine("1. Установить персонажа");
                Console.WriteLine("2. Создать персонажа");
                Console.WriteLine("3. Экипировать персонажа");
                Console.WriteLine("4. Подробная информация о персонаже");
                Console.WriteLine("5. Атаковать цель персонажем");
                Console.WriteLine("6. Выйти");
                try
                {
                    switch (SetInputIntRange(ConsoleInput.GetIntValue(), 1, 6))
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
                            ShowDetails();
                            break;
                        case 5:
                            AttackTarget();
                            break;
                        case 6:
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
            if (_characterPool.Characters.Count == 0)
            {
                throw new Exception("Невозможно выбрать персонажа, пока не создан хотя бы один");
            }
            Console.Clear();
            List<ICharacter> characters = _characterPool.Characters;
            ICharacter current;
            for (int i = 0; i < characters.Count; i++)
            {
                current = characters[i];
                Console.WriteLine($"{i + 1}. {current.CharacterName()} " +
                                  $"{(current.GetWeapon() == null ? "" : "c оружием " + current.GetWeapon().Name)}");
            }
            
            _characterPool.SetCurrentCharacter(SetInputIntRange
                (ConsoleInput.GetIntValue(), 1, characters.Count) - 1);
            Console.Clear();
            Console.WriteLine($"Персонаж {_characterPool.GetCurrentCharacter().CharacterName()} установлен");
        }

        private void CreateCharacter()
        {
            Console.Clear();
            Console.WriteLine("Выберите класс персонажа");
            ArrayList enumValues = new ArrayList(Enum.GetValues(typeof(CharacterEnum)));
            for (int i = 0; i < enumValues.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {enumValues[i]?.ToString()}");
            }
            int charClass = SetInputIntRange(ConsoleInput.GetIntValue(), 1, enumValues.Count);

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
            
            _characterPool.CreateCharacter((CharacterEnum)charClass - 1, charHitPoint, charManaPoint, 
                charPower, charAgility, charIntellect);
            
            Console.Clear();
            Console.WriteLine($"Персонаж {_characterPool.Characters[^1].CharacterName()} создан");
        }

        private void SetWeapon()
        {
            _currentCharacter = _characterPool.GetCurrentCharacter();
            if (_currentCharacter == null)
            {
                throw new Exception("Не выбран персонаж для экипировки");
            }
            Console.Clear();
            Console.WriteLine("Выберете, каким оружием экипировать персонажа");

            ArrayList enumValues = new ArrayList(Enum.GetValues(typeof(WeaponEnum)));
            int i = 0;
            for (i = 0; i < enumValues.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {enumValues[i]?.ToString()}");
            }
            
            Console.WriteLine($"{i + 1}. Установить неуязвимость");
            int choice = SetInputIntRange(ConsoleInput.GetIntValue(),
                1, enumValues.Count + 1);
            Console.Clear();
            if (choice == i + 1)
            {
                _characterPool.SetInvulnerability();
                Console.WriteLine("Неуязвимость установлена");
            }
            else
            {
                _characterPool.SetWeapon((WeaponEnum)choice - 1);
                Console.WriteLine($"Оружие {_currentCharacter.GetWeapon().Name} экипировано на персонажа " +
                                  $"{_currentCharacter.CharacterName()}");
            }
            
            
            
            
        }

        private void PrintCurrentCharacter()
        {
            ICharacter currentCharacter = _characterPool.GetCurrentCharacter();
            Console.Write("Текущий персонаж: ");
            Console.WriteLine(currentCharacter == null ? "не установлен" : currentCharacter.CharacterName());
        }

        private void ShowDetails()
        {
            _currentCharacter = _characterPool.GetCurrentCharacter();
            if (_currentCharacter == null)
            {
                throw new Exception("Не выбран персонаж для отображения подробностей");
            }
            Console.Clear();
            Console.WriteLine($"Имя: {_currentCharacter.CharacterName()}");
            Console.WriteLine($"Жив: {(_currentCharacter.Alive()? "да" : "нет")}");
            Console.WriteLine($"Здоровье: {_currentCharacter.HitPoints()}");
            Console.WriteLine($"Мана: {_currentCharacter.ManaPoints()}");
            Console.WriteLine($"Основные хар. персонажа: {_currentCharacter.GetMainFeatures().ToString()}");
            Weapon characterWeapon = _currentCharacter.GetWeapon();
            if (characterWeapon == null) return;
            Console.WriteLine($"Оружие: {characterWeapon.Name}");
            Console.WriteLine($"Урон оружия: {characterWeapon.Damage}");
            Console.WriteLine($"Требования к оружию: {_currentCharacter.GetWeapon()?.RequiredFeatures.ToString()}");
        }

        private void AttackTarget()
        {
            _currentCharacter = _characterPool.GetCurrentCharacter();
            if (_currentCharacter == null)
            {
                throw new Exception("Не выбран персонаж для атаки");
            }
            if (_characterPool.Characters.Count == 0 || _npcPoll.NPCs.Count == 0)
            {
                throw new Exception("Нет целей для атаки");
            }
            Console.Clear();
            Console.WriteLine("Выберите цель для атаки");
            ArrayList damaged = new ArrayList();
            int i = 0;
            foreach (var character in _characterPool.Characters)
            {
                Console.WriteLine($"{i+1}. {character.CharacterName()}{(character == _currentCharacter?"(Вы)":"")}");
                damaged.Add(character);
                i++;
            }

            foreach (var npc in _npcPoll.NPCs)
            {
                Console.WriteLine($"{i+1}. {npc.Name}");
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

        private static int SetInputIntRange(int value, int minValue = int.MinValue, int maxValue = int.MaxValue)
        {
            if (value >= minValue && value <= maxValue) return value;
            throw new Exception("Неверный ввод");
        }
    }
}