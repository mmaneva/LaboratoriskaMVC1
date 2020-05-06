namespace LaboratoriskaMVC1.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Friend
    {
        public int ID { get; set; }
        [Required]
        [Display (Name = "Friend ID" )]
        [Range(1,200,ErrorMessage ="Vnesete broj od 0 do 200")]
        public int? FriendId { get; set; }

        [Required]
        [Display(Name = "Friend Name")]
        public string Ime { get; set; }

        [Required]
        [Display(Name = "Place")]
        public string MastoZiveenje { get; set; }
    }
}