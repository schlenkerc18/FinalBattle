using System.ComponentModel.DataAnnotations;

namespace FinalBattle.Enums
{
    public enum GearType
    {
        Nothing,
        Sword,
        Dagger,

        [Display(Name = "Vin Fletcher's Bow")]
        Bow
    }
}
