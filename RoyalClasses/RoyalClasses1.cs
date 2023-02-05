using System.ComponentModel.DataAnnotations;

namespace RoyalClasses
{
    public class House
    {
        
        [Key]
        public int HouseId { get; set; }
        public string HouseName { get; set; }
        public int FamilyHonor { get; set; }
        public ICollection<Character>? FamilyMembers { get; set; }
    }
    public class Character
    {
        [Key]
        public int CharacterId { get; set; }
        public string CharacterName { get; set; }
        public House? House { get; set; }
        //public Character? Parent1 { get; set; }
        //public Character? Parent2 { get; set; }
        public int Honor { get; set; }
        public int Reputation { get; set; }
        public int Appearance { get; set; }
        public int Extrovertness { get; set; }
        public int Intelligence { get; set; }
        public int Sexuality { get; set; }

        public int Gender { get; set; }
        public int Age { get; set; }
        public bool Alive { get; set; }
        public ICollection<Opinion> Opinions {get; set;}
        public ICollection<MemoryRC> Memories { get; set;}



    }
    public class Opinion
    {
        [Key]
        public int OpinionId { get; set; }
        public Character OpinionHolder { get; set; }
        public string OpinionOf { get; set; }
        public int? OpinionValue { get; set; }

    }
    public class Interaction
    {
        [Key]
        public int InteractionId { get; set; }
        public Character InteractionHolder1 { get; set; }
        public Character? InteractionHolder2 { get; set; }
        public string InteractionText { get; set; }
    }
    public class MemoryRC
    {
        [Key]
        public int MemoryId { get; set;}
        public string MemoryName { get; set;}
        public Interaction? ConnectedInteraction { get; set; }
    }

    public class Court
    {
        [Key]
        public int CourtId { get; set; }
        public string CourtName { get;set;}
        public Character Monarch { get; set; }
        public Palace Palace { get; set; }
        public ICollection<Character> Subjects { get; set; }
    }
    public class Title
    {
        [Key]
        public int TitleId { get; set; }
        public string TitleName { get; set;}
        public Holdings? Holdings { get; set; }
        public Character? Owner { get; set; }


    }
    public class DailyEvent
    {
        
        [Key]
        public int DailyEventId { get; set; }
        public string DailyEventName { get;set; }

        public delegate void EventAction();
        
    }

    public class WeeklyEvent
    {
        [Key]
        public int WeeklyEventId { get; set; }
        public string WeeklyEventName { get; set;}
    }
    public class YearlyEvent
    {
        [Key]
        public int YearlyEventId { get; set; }
        public string YearlyEventName { get; set;}
    }
    public class Room
    {
        [Key]
        public int RoomId { get; set; }
        public string RoomName { get; set;}
    }
    public class Palace
    {
        [Key]
        public int PalaceId { get; set; }
        public string PalaceName { get; set;}
        public ICollection<Room> Rooms { get; set; }

    }
    public class Holdings
    {
        [Key]
        public int HoldingsId { get; set; }
        public string HoldingsName { get; set;}
        //public Title Title { get; set;}

    }
}