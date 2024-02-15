namespace MotorPool.Auth;

public interface AuthService
{

    ValueTask<AuthResult> LoginAsync(LoginDTO loginDTO);

    ValueTask<AuthResult> RegisterAsync(RegisterDTO registerDTO);

}