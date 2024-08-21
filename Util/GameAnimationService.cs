public class GameAnimationService
{
    public bool IsHeroTurn { get; private set; }
    public bool HeroIsAtt { get; private set; }
    public bool EnemyIsAtt { get; private set; }

    public bool IsEnemyTurn { get; private set; }
    public bool HeroIsHealing { get; private set; }
    public bool EnemyIsHealing { get; private set; }
    public bool HeroUpgradeArmor { get; private set; }
    public bool EnemyUpgradeArmor { get; private set; }
    public bool HeroIsGettingDmg { get; private set; }
    public bool EnemyIsGettingDmg { get; private set; }
    public bool HeroIsBessing { get; private set; }
    public bool EnemyIsBessing { get; private set; }


    public void SetTurn(bool isHeroTurn)
    {
        IsHeroTurn = isHeroTurn;
        IsEnemyTurn = !isHeroTurn;
    }

    public void SetBessing(bool isHero, bool isBlessing)
    {
        if (isHero)
            HeroIsBessing = isBlessing;
        else
            EnemyIsBessing = isBlessing;
    }
    public void SetHealing(bool isHero, bool isHealing)
    {
        if (isHero)
            HeroIsHealing = isHealing;
        else
            EnemyIsHealing = isHealing;
    }
    public void SetIsAtt(bool isHero, bool isAtt)
    {
        if (isHero)
            HeroIsAtt = isAtt;
        else
            EnemyIsAtt = isAtt;
    }

    public void SetUpgradeArmor(bool isHero, bool isUpgrading)
    {
        if (isHero)
            HeroUpgradeArmor = isUpgrading;
        else
            EnemyUpgradeArmor = isUpgrading;
    }

    public void SetGettingDamage(bool isHero, bool isGettingDamage)
    {
        if (isHero)
            HeroIsGettingDmg = isGettingDamage;
        else
            EnemyIsGettingDmg = isGettingDamage;
    }

    public async Task ResetStatus(int delay = 1000)
    {
        await Task.Delay(delay);
        HeroIsHealing = false;
        EnemyIsHealing = false;
        HeroUpgradeArmor = false;
        EnemyUpgradeArmor = false;
        HeroIsGettingDmg = false;
        EnemyIsGettingDmg = false;
        HeroIsAtt = false;
        EnemyIsAtt = false;
        HeroIsBessing = false;
        EnemyIsBessing = false;

    }
}