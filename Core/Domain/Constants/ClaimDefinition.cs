namespace Domain.Constants;

public class ClaimDefinition
{
    #region Constants
    private const string PREFIX = "CLAIM_";
    private const string IDENTITY_PREFIX = $"{PREFIX}IDENTITY_";
    private const string SUFIX_GETALL = ":GETALL";
    private const string SUFIX_GETLIST = ":GETLIST";
    private const string SUFIX_GETBYID = ":GETBYID";
    #endregion

    #region Identity/USER
    public const string IDENTITY_USER_GETALL = $"{IDENTITY_PREFIX}USER{SUFIX_GETALL}";
    public const string IDENTITY_USER_GETLIST = $"{IDENTITY_PREFIX}USER{SUFIX_GETBYID}";
    public const string IDENTITY_USER_GETBYID = $"{IDENTITY_PREFIX}USER{SUFIX_GETLIST}";
    #endregion
    #region Identity/ROLE
    public const string IDENTITY_ROLE_GETALL = $"{IDENTITY_PREFIX}ROLE{SUFIX_GETALL}";
    public const string IDENTITY_ROLE_GETLIST = $"{IDENTITY_PREFIX}ROLE{SUFIX_GETBYID}";
    public const string IDENTITY_ROLE_GETBYID = $"{IDENTITY_PREFIX}ROLE{SUFIX_GETLIST}";
    #endregion
    #region Identity/ROLECLAIM
    public const string IDENTITY_ROLECLAIM_GETALL = $"{IDENTITY_PREFIX}ROLECLAIM{SUFIX_GETALL}";
    public const string IDENTITY_ROLECLAIM_GETLIST = $"{IDENTITY_PREFIX}ROLECLAIM{SUFIX_GETBYID}";
    public const string IDENTITY_ROLECLAIM_GETBYID = $"{IDENTITY_PREFIX}ROLECLAIM{SUFIX_GETLIST}";
    #endregion
    #region Identity/USERCLAIM
    public const string IDENTITY_USERCLAIM_GETALL = $"{IDENTITY_PREFIX}USERCLAIM{SUFIX_GETALL}";
    public const string IDENTITY_USERCLAIM_GETLIST = $"{IDENTITY_PREFIX}USERCLAIM{SUFIX_GETBYID}";
    public const string IDENTITY_USERCLAIM_GETBYID = $"{IDENTITY_PREFIX}USERCLAIM{SUFIX_GETLIST}";
    #endregion
    #region Identity/USERLOGIN
    public const string IDENTITY_USERLOGIN_GETALL = $"{IDENTITY_PREFIX}USERLOGIN{SUFIX_GETALL}";
    public const string IDENTITY_USERLOGIN_GETLIST = $"{IDENTITY_PREFIX}USERLOGIN{SUFIX_GETBYID}";
    public const string IDENTITY_USERLOGIN_GETBYID = $"{IDENTITY_PREFIX}USERLOGIN{SUFIX_GETLIST}";
    #endregion
    #region Identity/USERROLE
    public const string IDENTITY_USERROLE_GETALL = $"{IDENTITY_PREFIX}USERROLE{SUFIX_GETALL}";
    public const string IDENTITY_USERROLE_GETLIST = $"{IDENTITY_PREFIX}USERROLE{SUFIX_GETBYID}";
    public const string IDENTITY_USERROLE_GETBYID = $"{IDENTITY_PREFIX}USERROLE{SUFIX_GETLIST}";
    #endregion
    #region Identity/USERTOKEN
    public const string IDENTITY_USERTOKEN_GETALL = $"{IDENTITY_PREFIX}USERTOKEN{SUFIX_GETALL}";
    public const string IDENTITY_USERTOKEN_GETLIST = $"{IDENTITY_PREFIX}USERTOKEN{SUFIX_GETBYID}";
    public const string IDENTITY_USERTOKEN_GETBYID = $"{IDENTITY_PREFIX}USERTOKEN{SUFIX_GETLIST}";
    #endregion

    #region Application/APPFILE
    public const string IDENTITY_APPFILE_GETALL = $"{IDENTITY_PREFIX}APPFILE{SUFIX_GETALL}";
    public const string IDENTITY_APPFILE_GETLIST = $"{IDENTITY_PREFIX}APPFILE{SUFIX_GETBYID}";
    public const string IDENTITY_APPFILE_GETBYID = $"{IDENTITY_PREFIX}APPFILE{SUFIX_GETLIST}";

    #endregion
}
