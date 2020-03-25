namespace Miki.Bot.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Settings")]
    public class Setting
    {
        [Key]
        [Column("EntityId", Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long EntityId { get; set; }

        [Key]
        [Column("SettingId", Order = 1)]
        public int SettingId { get; set; }

        [Column("Value", Order = 2)]
        public int Value { get; set; }
    }
}