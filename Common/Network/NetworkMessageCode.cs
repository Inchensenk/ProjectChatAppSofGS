namespace Common.Network
{
    public enum NetworkMessageCode : byte
    {
        SignUpRequestCode,
        SignUpResponseCode,
        SignInRequestCode,
        SignInResponseCode,
        SearcRequestCode,
        SearchResponseCode,
        CreateConversationRequestCode,
        CreateConversationResponseCode,
        SendMessageRequestCode,
        SendMessageResponseCode,
        DeleteMessageRequestCode,
        DeleteMessageResponseCode,
        DeleteConversationRequestCode,
        DeleteConversationResponseCode,
        SignOutRequestCode,
        SignOutResponseCode,
        ReadMessagesRequestCode,
        ReadMessagesResponseCode
    }
}