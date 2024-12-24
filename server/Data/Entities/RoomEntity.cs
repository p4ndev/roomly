using Server.Data.Dtos;

namespace Server.Data.Entities;

[Table("Rooms")]
public class RoomEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; private set; }

    public int Capacity { get; private set; }

    [Required]
    [MaxLength(50)]
    [Column(TypeName = "varchar(50)")]
    public string Name { get; private set; } = null!;

    [MaxLength(255)]
    [Column(TypeName = "varchar(255)")]
    public string Description { get; private set; } = null!;

    public RoomEntity() { }

    public RoomEntity(RoomDto model)
    {
        Name = model.Name;
        Capacity = model.Capacity;
        Description = model.Description;
    }

    public ICollection<RoomAmenityEntity> RoomAmenities { get; set; } = new List<RoomAmenityEntity>();

    public ICollection<ReservationEntity> Reservations { get; set; } = new List<ReservationEntity>();
}