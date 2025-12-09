using Oracle.ManagedDataAccess.Client;

public class DB
{
    public static string strConn =
        "User Id=gywn;Password=3988;Data Source=localhost:1521/xe;";

    public static OracleConnection GetConn()
    {
        return new OracleConnection(strConn);
    }
}
