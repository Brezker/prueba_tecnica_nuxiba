using System.ComponentModel.DataAnnotations.Schema;

namespace TestBackNuxiba.Models;

[Table("ccloglogin")]
public class Login
{
    public long LogLoginId { get; set; }

    public int User_id { get; set; }

    public int Extension { get; set; }

    public int TipoMov { get; set; }

    public DateTime fecha { get; set; }

    // Navigation property
    public User? User { get; set; }
}