using System.ComponentModel.DataAnnotations;

public enum ActionType
{

    DoNothing,
    Punch, // TrueProgrammer standard attack
    Unraveling, // Uncoded one standard attack

    [Display(Name = "Bone Crunch")]
    BoneCrunch, // Skeleton standard attack
    Slash, // sword based attack
    Stab, // dagger based attack
    Equip,
    UsePotion,

    [Display(Name = "Quick Shot")]
    QuickShot,
    Bite
}
