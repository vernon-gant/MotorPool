namespace MotorPool.Auth;

public class AuthResult
{

    public bool IsSuccess { get; set; }

    public string? Token { get; set; }

    public string? Error { get; set; }

    public static AuthResult Success(string token) => new () { IsSuccess = true, Token = token };

    public static AuthResult Failure() => new () { IsSuccess = false };

    public static AuthResult Failure(string error) => new () { IsSuccess = false, Error = error };

}