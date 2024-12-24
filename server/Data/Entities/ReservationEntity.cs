namespace Server.Data.Entities;

[Table("Reservations")]
public class ReservationEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; private set; }

    public int RoomId { get; private set; }

    [Required]
    [Column(TypeName = "datetime")]
    public DateTime StartsAt { get; private set; }

    [Required]
    [Column(TypeName = "datetime")]
    public DateTime EndsAt { get; private set; }

    [MaxLength(255)]
    [Column(TypeName = "varchar(255)")]
    public string Description { get; private set; } = null!;

    [ForeignKey(nameof(RoomId))]
    public RoomEntity Room { get; private set; } = null!;
}