using System.ComponentModel.DataAnnotations;

namespace Hyden.Api.Core.Requests.Users;

public class UploadProfilePictureRequest
{
    [Required(ErrorMessage = "O id do usuário é obrigatório")]
    public string UserId { get; set; } = string.Empty;

    [Required(ErrorMessage = "A foto de perfil é obrigatória")]
    public string Base64 { get; set; } = null!;

    [Required(ErrorMessage = "O MIME type é obrigatório")]
    public string Mime { get; set; } = null!;

    [Required(ErrorMessage = "O nome da imagem é obrigatório")]
    public string PictureName { get; set; } = null!;
}
