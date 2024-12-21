namespace Server.Data.Entities;

[Table("RoomAmenities")]
public class RoomAmenityEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id                   { get; private set; }

    public int RoomId               { get; private set; }

    public int AmenityId            { get; private set; }

    [ForeignKey(nameof(RoomId))]
    public RoomEntity Room          { get; private set; } = null!;

    [ForeignKey(nameof(AmenityId))]
    public AmenityEntity Amenity    { get; private set; } = null!;
}