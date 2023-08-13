namespace UserManagement.Utility.Token
{
    internal class TokenResponse
    {
        internal string? Token { get; set; }

        internal int ExpiressIn { get; set; }

        internal int RefreshExpiress { get; set; }

        internal string? RefreshToken { get; set; }

        internal string? TokenType { get; set; }

        internal long NotBeforePolicy { get; set; }

        internal string? SessionState { get; set; }

        internal string? Scope { get; set; }
    }
}
