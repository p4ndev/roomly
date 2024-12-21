namespace Server.Data.Entities;

[Table("Amenities")]
public class AmenityEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id               { get; private set; }

    [Required]
    [MaxLength(50)]
    [Column(TypeName = "varchar(50)")]
    public string Name          { get; private set; } = null!;

    public ICollection<RoomAmenityEntity> RoomAmenities { get; set; } = new List<RoomAmenityEntity>();
}