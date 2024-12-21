using Server.Data.Dtos;

namespace Server.Data.Entities;

[Table("Settings")]
public class SettingEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id               { get; private set; }

    [MaxLength(100)]
    [Column(TypeName = "varchar(100)")]
    public string Name          { get; private set; } = null!;

    [Required]
    [Column(TypeName = "ntext")]
    public string Logotype      { get; private set; } = null!;

    [Required]
    [MaxLength(20)]
    [Column(TypeName = "varchar(20)")]
    public string Viewer        { get; private set; } = null!;

    [Required]
    [MaxLength(20)]
    [Column(TypeName = "varchar(20)")]
    public string Coordinator   { get; private set; } = null!;

    [Required]
    [MaxLength(20)]
    [Column(TypeName = "varchar(20)")]
    public string Administrator { get; private set; } = null!;

    [DefaultValue(false)]
    [Column(TypeName = "bit")]
    public bool Shown           { get; private set; } = false;

    public SettingEntity() { }

    public SettingEntity(InstallationDto installationDto, AccessDto accessDto) 
        : this()
    {
        Name            = installationDto.Name;
        Logotype        = installationDto.Logotype;

        Viewer          = accessDto.Viewer;
        Coordinator     = accessDto.Coordinator;
        Administrator   = accessDto.Administrator;
    }

    public void Expose()
        => Shown = true;
}
