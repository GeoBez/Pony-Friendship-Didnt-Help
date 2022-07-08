using System.Collections.Generic;
using UnityEngine;
using System;
using System.Reflection;
using System.Linq;
using sRandom = System.Random;

public static class GenerateCardUpgrade
{
    static GenerateCardUpgrade()
    {
        Reset();
        Type[] CardClass = Assembly.GetExecutingAssembly().GetTypes().Where(t => t.Namespace == nameof(Upgrades) && !t.Name.Contains("<>")).ToArray();
        foreach (Type CardClassType in CardClass)
        {
            object Object = Activator.CreateInstance(Type.GetType(CardClassType.FullName));
            if (Enum.TryParse(typeof(TypeUpgrade), Object.GetType().Name, out object typeUpgrage) && Object is ICardUpgrade card)
            {
                card.TypeUpgrade = (TypeUpgrade)typeUpgrage;
                CardUpgrade.Add((TypeUpgrade)typeUpgrage, card);
            }
            else
                Debug.LogError($"Error: Was not found Type of Object {Object}");
        }
    }
    private static Dictionary<TypeUpgrade, ICardUpgrade> CardUpgrade = new();
    private static List<string> Used { get; set; }

    public static int CountTypeUpgrade { get { return Used.Count - 1; } }

    private static sRandom random = new sRandom();

    private static Sprite GetSpriteByType(TypeUpgrade typeUpgrade)
    {
        return Resources.Load<Sprite>($"Upgrade\\{typeUpgrade}");
    }

    /// <summary>
    /// Задает изначальное количество карточек. Обязательно вызвать при смене сцены.
    /// </summary>
    public static void Reset()
    {
        Used = Enum.GetNames(typeof(TypeUpgrade)).ToList();
        random = new sRandom();
    }

    public static void UsedUpgrade(TypeUpgrade type)
    {
        if(CardBlocking.ContainsKey(type))
        foreach (TypeUpgrade upgrades in CardBlocking[type])
        {
            Used.Remove(upgrades.ToString());
        }
        if (type == TypeUpgrade.None) return;
        PlayerStatistics.GiveOneCard();
        CardUpgrade[type].Function();
            Used.Remove(type.ToString());
    }
    /// <summary>
    ///Добавь карту, которая заблокирует другие карточки.
    ///</summary>
    private static Dictionary<TypeUpgrade, TypeUpgrade[]> CardBlocking = new Dictionary<TypeUpgrade, TypeUpgrade[]>
    {
      //  [TypeUpgrade. Тип Блокирующий ] = new TypeUpgrade[] { TypeUpgrade. Тип Блокируемые },

    };

    /// <summary>
    ///Выдает рандомное улучшение из доступных.
    ///При этом выданное улучшение не будет входить в рандом в последствии.
    ///получаете информацию о кнпке вызова типа улучшения.
    ///Добавлять или менять что либо нельзя!
    ///</summary>
    public static ButtonCard GetCardRandom()
    {
        TypeUpgrade randomUpgrade;
        do
        {
            randomUpgrade = Used.Count == 1? TypeUpgrade.None : (TypeUpgrade)Enum.Parse(typeof(TypeUpgrade), Used[random.Next(1, Used.Count)]);
        }
        while (!Used.Contains(randomUpgrade.ToString()));
        return GetCardAt(randomUpgrade);
    }
    /// <summary>
    ///Выдает карту по параметру типа улучшения
    ///</summary>
    public static ButtonCard GetCardAt(TypeUpgrade Type)
    {
        Card card = CardUpgrade[Type].Card;
        return new ButtonCard(
            GetSpriteByType(Type),
            card.name,
            card.description,
            Type
            );
    }

    
    
}
public enum TypeUpgrade
{
    None,
    AddCoins,
    DoubleCoin,
    AddMaxHealth1,
    AddMaxHealth2,
    AddPower,
    DoublPower,
    AttackFrequency,
    AttackOfTowers,
    AttackRadius,
    FurtherBattle,
    Luck,
    Magnet,
    SpeedBoost,
    TimeCoin,
    TowerHealth,
    Treatment
}

[System.Serializable]
public class ButtonCard
{
    public ButtonCard(Sprite _Avatar, string _Name, string _Description, TypeUpgrade type)
    {
        Avatar = _Avatar;
        Name = _Name;
        Description = _Description;
        typeUpgrade = type;
    }
    public Sprite Avatar;
    public string Name;
    public string Description;
    public TypeUpgrade typeUpgrade;
}